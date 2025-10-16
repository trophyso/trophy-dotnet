using System.Net.Http;
using System.Text.Json;
using System.Threading;
using TrophyApi.Core;

namespace TrophyApi;

public partial class LeaderboardsClient
{
    private RawClient _client;

    internal LeaderboardsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Get all active leaderboards for your organization.
    /// </summary>
    /// <example><code>
    /// await client.Leaderboards.AllAsync();
    /// </code></example>
    public async Task<IEnumerable<LeaderboardsAllResponseItem>> AllAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Api,
                    Method = HttpMethod.Get,
                    Path = "leaderboards",
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
                return JsonUtils.Deserialize<IEnumerable<LeaderboardsAllResponseItem>>(
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
    /// Get a specific leaderboard by its key.
    /// </summary>
    /// <example><code>
    /// await client.Leaderboards.GetAsync(
    ///     "weekly-words",
    ///     new LeaderboardsGetRequest
    ///     {
    ///         Offset = 1,
    ///         Limit = 1,
    ///         Run = "2025-01-15",
    ///         UserId = "user-123",
    ///     }
    /// );
    /// </code></example>
    public async Task<LeaderboardResponseWithRankings> GetAsync(
        string key,
        LeaderboardsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Offset != null)
        {
            _query["offset"] = request.Offset.Value.ToString();
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Run != null)
        {
            _query["run"] = request.Run;
        }
        if (request.UserId != null)
        {
            _query["userId"] = request.UserId;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Api,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "leaderboards/{0}",
                        ValueConvert.ToPathParameterString(key)
                    ),
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
                return JsonUtils.Deserialize<LeaderboardResponseWithRankings>(responseBody)!;
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
