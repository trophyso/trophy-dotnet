using System.Net.Http;
using System.Text.Json;
using System.Threading;
using TrophyApi;
using TrophyApi.Admin.Streaks;
using TrophyApi.Core;

namespace TrophyApi.Admin;

public partial class StreaksClient
{
    private RawClient _client;

    internal StreaksClient(RawClient client)
    {
        _client = client;
        Freezes = new FreezesClient(_client);
    }

    public FreezesClient Freezes { get; }

    /// <summary>
    /// Restore streaks for multiple users to the maximum length in the last 90 days (in the case of daily streaks), one year (in the case of weekly streaks), or two years (in the case of monthly streaks).
    /// </summary>
    /// <example><code>
    /// await client.Admin.Streaks.RestoreAsync(
    ///     new RestoreStreaksRequest
    ///     {
    ///         UserIds = new List&lt;string&gt;() { "user-123", "user-456" },
    ///     }
    /// );
    /// </code></example>
    public async Task<RestoreStreaksResponse> RestoreAsync(
        RestoreStreaksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Admin,
                    Method = HttpMethod.Post,
                    Path = "streaks/restore",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<RestoreStreaksResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new TrophyApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
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
}
