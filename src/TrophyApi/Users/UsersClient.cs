using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TrophyApi.Core;

namespace TrophyApi;

public partial class UsersClient
{
    private RawClient _client;

    internal UsersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Get a single user's progress against all active metrics.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.AllmetricsAsync("userId");
    /// </code>
    /// </example>
    public async Task<IEnumerable<MetricResponse>> AllmetricsAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .MakeRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = $"users/{userId}/metrics",
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
                return JsonUtils.Deserialize<IEnumerable<MetricResponse>>(responseBody)!;
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

    /// <summary>
    /// Get a user's progress against a single active metric.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.SinglemetricAsync("userId", "key");
    /// </code>
    /// </example>
    public async Task<MetricResponse> SinglemetricAsync(
        string userId,
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .MakeRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = $"users/{userId}/metrics/{key}",
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
                return JsonUtils.Deserialize<MetricResponse>(responseBody)!;
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

    /// <summary>
    /// Get all of a user's completed achievements.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.AllachievementsAsync("userId");
    /// </code>
    /// </example>
    public async Task<IEnumerable<AchievementResponse>> AllachievementsAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .MakeRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = $"users/{userId}/achievements",
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
                return JsonUtils.Deserialize<IEnumerable<AchievementResponse>>(responseBody)!;
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
