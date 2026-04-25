using System.Net.Http;
using System.Text.Json;
using System.Threading;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin;

public partial class LeaderboardsClient
{
    private RawClient _client;

    internal LeaderboardsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// List leaderboards.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Leaderboards.ListAsync(new LeaderboardsListRequest { Limit = 1, Skip = 1 });
    /// </code></example>
    public async Task<IEnumerable<AdminLeaderboard>> ListAsync(
        LeaderboardsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Skip != null)
        {
            _query["skip"] = request.Skip.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Admin,
                    Method = HttpMethod.Get,
                    Path = "leaderboards",
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
                return JsonUtils.Deserialize<IEnumerable<AdminLeaderboard>>(responseBody)!;
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
    /// Create leaderboards. Maximum 100 leaderboards per request.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Leaderboards.CreateAsync(
    ///     new List&lt;CreateLeaderboardRequestItem&gt;()
    ///     {
    ///         new CreateLeaderboardRequestItem
    ///         {
    ///             Name = "Revenue Champions",
    ///             Key = "revenue-champions",
    ///             Status = CreateLeaderboardRequestItemStatus.Inactive,
    ///             RankBy = CreateLeaderboardRequestItemRankBy.Metric,
    ///             MetricId = "550e8400-e29b-41d4-a716-446655440000",
    ///             MaxParticipants = 100,
    ///             Start = "2026-04-20",
    ///             BreakdownAttributes = new List&lt;string&gt;() { "550e8400-e29b-41d4-a716-446655440010" },
    ///             RunUnit = CreateLeaderboardRequestItemRunUnit.Month,
    ///             RunInterval = 1,
    ///         },
    ///         new CreateLeaderboardRequestItem
    ///         {
    ///             Name = "Streak Legends",
    ///             Key = "streak-legends",
    ///             Status = CreateLeaderboardRequestItemStatus.Scheduled,
    ///             RankBy = CreateLeaderboardRequestItemRankBy.Streak,
    ///             Start = "2026-04-27",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateLeaderboardsResponse> CreateAsync(
        IEnumerable<CreateLeaderboardRequestItem> request,
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
                    Path = "leaderboards",
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
                return JsonUtils.Deserialize<CreateLeaderboardsResponse>(responseBody)!;
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
    /// Delete leaderboards by ID.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Leaderboards.DeleteAsync(new LeaderboardsDeleteRequest());
    /// </code></example>
    public async Task<DeleteLeaderboardsResponse> DeleteAsync(
        LeaderboardsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["ids"] = request.Ids;
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Admin,
                    Method = HttpMethod.Delete,
                    Path = "leaderboards",
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
                return JsonUtils.Deserialize<DeleteLeaderboardsResponse>(responseBody)!;
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
    /// Update leaderboards by ID. Updating `status` behaves the same as activating, scheduling, deactivating, or finishing a leaderboard in the dashboard.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Leaderboards.UpdateAsync(
    ///     new List&lt;UpdateLeaderboardRequestItem&gt;()
    ///     {
    ///         new UpdateLeaderboardRequestItem
    ///         {
    ///             Id = "550e8400-e29b-41d4-a716-446655440100",
    ///             Name = "Monthly Revenue Champions",
    ///             Description = "Ranked by monthly revenue",
    ///             Status = UpdateLeaderboardRequestItemStatus.Active,
    ///         },
    ///         new UpdateLeaderboardRequestItem
    ///         {
    ///             Id = "550e8400-e29b-41d4-a716-446655440101",
    ///             Status = UpdateLeaderboardRequestItemStatus.Finished,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateLeaderboardsResponse> UpdateAsync(
        IEnumerable<UpdateLeaderboardRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Admin,
                    Method = HttpMethodExtensions.Patch,
                    Path = "leaderboards",
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
                return JsonUtils.Deserialize<UpdateLeaderboardsResponse>(responseBody)!;
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
    /// Get a leaderboard by ID.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Leaderboards.GetAsync("550e8400-e29b-41d4-a716-446655440100");
    /// </code></example>
    public async Task<AdminLeaderboard> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Admin,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "leaderboards/{0}",
                        ValueConvert.ToPathParameterString(id)
                    ),
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
                return JsonUtils.Deserialize<AdminLeaderboard>(responseBody)!;
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
