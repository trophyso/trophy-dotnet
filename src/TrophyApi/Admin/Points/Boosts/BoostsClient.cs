using System.Net.Http;
using System.Text.Json;
using System.Threading;
using global::System.Threading.Tasks;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

public partial class BoostsClient
{
    private RawClient _client;

    internal BoostsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Create points boosts for multiple users.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Boosts.CreateAsync(
    ///     new CreatePointsBoostsRequest
    ///     {
    ///         SystemKey = "xp",
    ///         Boosts = new List&lt;CreatePointsBoostsRequestBoostsItem&gt;()
    ///         {
    ///             new CreatePointsBoostsRequestBoostsItem
    ///             {
    ///                 UserId = "user-123",
    ///                 Name = "Double XP Weekend",
    ///                 Start = "2024-01-01",
    ///                 End = "2024-01-03",
    ///                 Multiplier = 2,
    ///             },
    ///             new CreatePointsBoostsRequestBoostsItem
    ///             {
    ///                 UserId = "user-456",
    ///                 Name = "Holiday Bonus",
    ///                 Start = "2024-12-25",
    ///                 Multiplier = 1.5,
    ///                 Rounding = CreatePointsBoostsRequestBoostsItemRounding.Up,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreatePointsBoostsResponse> CreateAsync(
        CreatePointsBoostsRequest request,
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
                    Path = "points/boosts",
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
                return JsonUtils.Deserialize<CreatePointsBoostsResponse>(responseBody)!;
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
    /// Archive multiple points boosts by ID.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Boosts.BatchArchiveAsync(new BoostsBatchArchiveRequest());
    /// </code></example>
    public async Task<ArchivePointsBoostsResponse> BatchArchiveAsync(
        BoostsBatchArchiveRequest request,
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
                    Path = "points/boosts",
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
                return JsonUtils.Deserialize<ArchivePointsBoostsResponse>(responseBody)!;
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
    /// Archive a points boost by ID.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Boosts.ArchiveAsync("id");
    /// </code></example>
    public async global::System.Threading.Tasks.Task ArchiveAsync(
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "points/boosts/{0}",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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
}
