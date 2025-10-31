using System.Net.Http;
using System.Text.Json;
using System.Threading;
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
    /// Get all achievements and their completion stats.
    /// </summary>
    /// <example><code>
    /// await client.Achievements.AllAsync(
    ///     new AchievementsAllRequest { UserAttributes = "plan-type:premium,region:us-east" }
    /// );
    /// </code></example>
    public async Task<IEnumerable<AchievementWithStatsResponse>> AllAsync(
        AchievementsAllRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.UserAttributes != null)
        {
            _query["userAttributes"] = request.UserAttributes;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Api,
                    Method = HttpMethod.Get,
                    Path = "achievements",
                    Query = _query,
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
                return JsonUtils.Deserialize<IEnumerable<AchievementWithStatsResponse>>(
                    responseBody
                )!;
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

    /// <summary>
    /// Mark an achievement as completed for a user.
    /// </summary>
    /// <example><code>
    /// await client.Achievements.CompleteAsync(
    ///     "finish-onboarding",
    ///     new AchievementsCompleteRequest
    ///     {
    ///         User = new UpsertedUser
    ///         {
    ///             Email = "user@example.com",
    ///             Tz = "Europe/London",
    ///             Id = "user-id",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<AchievementCompletionResponse> CompleteAsync(
        string key,
        AchievementsCompleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Api,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "achievements/{0}/complete",
                        ValueConvert.ToPathParameterString(key)
                    ),
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
                return JsonUtils.Deserialize<AchievementCompletionResponse>(responseBody)!;
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
}
