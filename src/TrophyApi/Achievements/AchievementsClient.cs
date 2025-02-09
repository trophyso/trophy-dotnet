using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TrophyApi.Core;

namespace TrophyApi;

public partial class AchievementsClient
{
    private RawClient _client;

    internal AchievementsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Mark an achievement as completed for a user.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Achievements.CompleteAsync(
    ///     "finish-onboarding",
    ///     new AchievementsCompleteRequest
    ///     {
    ///         User = new EventRequestUser
    ///         {
    ///             Id = "18",
    ///             Email = "jk.rowling@harrypotter.com",
    ///             Tz = "Europe/London",
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<AchievementCompletionResponse> CompleteAsync(
        string key,
        AchievementsCompleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .MakeRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = $"achievements/{key}/complete",
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
                return JsonUtils.Deserialize<AchievementCompletionResponse>(responseBody)!;
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
                case 401:
                    throw new UnauthorizedError(JsonUtils.Deserialize<ErrorBody>(responseBody));
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorBody>(responseBody));
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
