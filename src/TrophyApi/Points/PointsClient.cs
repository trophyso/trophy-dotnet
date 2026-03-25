using System.Net.Http;
using System.Text.Json;
using System.Threading;
using TrophyApi.Core;

namespace TrophyApi;

public partial class PointsClient
{
    private RawClient _client;

    internal PointsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Get a breakdown of the number of users with points in each range.
    /// </summary>
    /// <example><code>
    /// await client.Points.SummaryAsync(
    ///     "points-system-key",
    ///     new PointsSummaryRequest { UserAttributes = "plan-type:premium,region:us-east" }
    /// );
    /// </code></example>
    public async Task<IEnumerable<PointsRange>> SummaryAsync(
        string key,
        PointsSummaryRequest request,
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
                    Path = string.Format(
                        "points/{0}/summary",
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
                return JsonUtils.Deserialize<IEnumerable<PointsRange>>(responseBody)!;
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

    /// <summary>
    /// Get a points system with its triggers.
    /// </summary>
    /// <example><code>
    /// await client.Points.SystemAsync("points-system-key");
    /// </code></example>
    public async Task<PointsSystemResponse> SystemAsync(
        string key,
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
                    Path = string.Format("points/{0}", ValueConvert.ToPathParameterString(key)),
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
                return JsonUtils.Deserialize<PointsSystemResponse>(responseBody)!;
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
    /// Get all global boosts for a points system. Finished boosts are excluded by default.
    /// </summary>
    /// <example><code>
    /// await client.Points.BoostsAsync(
    ///     "points-system-key",
    ///     new PointsBoostsRequest { IncludeFinished = true }
    /// );
    /// </code></example>
    public async Task<IEnumerable<PointsBoost>> BoostsAsync(
        string key,
        PointsBoostsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.IncludeFinished != null)
        {
            _query["includeFinished"] = JsonUtils.Serialize(request.IncludeFinished.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Api,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "points/{0}/boosts",
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
                return JsonUtils.Deserialize<IEnumerable<PointsBoost>>(responseBody)!;
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
    /// Get all levels for a points system.
    /// </summary>
    /// <example><code>
    /// await client.Points.LevelsAsync("points-system-key");
    /// </code></example>
    public async Task<IEnumerable<PointsLevel>> LevelsAsync(
        string key,
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
                    Path = string.Format(
                        "points/{0}/levels",
                        ValueConvert.ToPathParameterString(key)
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
                return JsonUtils.Deserialize<IEnumerable<PointsLevel>>(responseBody)!;
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
    /// Get a breakdown of the number of users at each level in a points system.
    /// </summary>
    /// <example><code>
    /// await client.Points.LevelSummaryAsync("points-system-key");
    /// </code></example>
    public async Task<IEnumerable<PointsLevelSummaryResponseItem>> LevelSummaryAsync(
        string key,
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
                    Path = string.Format(
                        "points/{0}/level-summary",
                        ValueConvert.ToPathParameterString(key)
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
                return JsonUtils.Deserialize<IEnumerable<PointsLevelSummaryResponseItem>>(
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
