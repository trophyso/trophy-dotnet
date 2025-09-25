using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

public partial class FreezesClient
{
    private RawClient _client;

    internal FreezesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Create streak freezes for multiple users.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Admin.Streaks.Freezes.CreateAsync(
    ///     new CreateStreakFreezesRequest
    ///     {
    ///         Freezes = new List&lt;CreateStreakFreezesRequestFreezesItem&gt;()
    ///         {
    ///             new CreateStreakFreezesRequestFreezesItem { UserId = "user-123" },
    ///             new CreateStreakFreezesRequestFreezesItem { UserId = "user-456" },
    ///             new CreateStreakFreezesRequestFreezesItem { UserId = "user-123" },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<CreateStreakFreezesResponse> CreateAsync(
        CreateStreakFreezesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .MakeRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.Environment.Admin,
                    Method = HttpMethod.Post,
                    Path = "streaks/freezes",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<CreateStreakFreezesResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new TrophyApiException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorBody>(responseBody));
                case 401:
                    throw new UnauthorizedError(JsonUtils.Deserialize<ErrorBody>(responseBody));
                case 422:
                    throw new UnprocessableEntityError(
                        JsonUtils.Deserialize<ErrorBody>(responseBody)
                    );
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new TrophyApiApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }
}
