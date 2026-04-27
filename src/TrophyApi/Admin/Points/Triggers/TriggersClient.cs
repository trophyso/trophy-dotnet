using System.Net.Http;
using System.Text.Json;
using System.Threading;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

public partial class TriggersClient
{
    private RawClient _client;

    internal TriggersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// List points triggers for a system.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Triggers.ListAsync(
    ///     "550e8400-e29b-41d4-a716-446655440000",
    ///     new TriggersListRequest { Limit = 1, Skip = 1 }
    /// );
    /// </code></example>
    public async Task<IEnumerable<AdminPointsTrigger>> ListAsync(
        string systemId,
        TriggersListRequest request,
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
                    Path = string.Format(
                        "points/{0}/triggers",
                        ValueConvert.ToPathParameterString(systemId)
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
                return JsonUtils.Deserialize<IEnumerable<AdminPointsTrigger>>(responseBody)!;
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
    /// Create points triggers in bulk. Maximum 100 triggers per request.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Triggers.CreateAsync(
    ///     "550e8400-e29b-41d4-a716-446655440000",
    ///     new List&lt;CreatePointsTriggerRequestItem&gt;()
    ///     {
    ///         new CreatePointsTriggerRequestItem
    ///         {
    ///             Type = CreatePointsTriggerRequestItemType.Metric,
    ///             Points = 10,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreatePointsTriggersResponse> CreateAsync(
        string systemId,
        IEnumerable<CreatePointsTriggerRequestItem> request,
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
                    Path = string.Format(
                        "points/{0}/triggers",
                        ValueConvert.ToPathParameterString(systemId)
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
                return JsonUtils.Deserialize<CreatePointsTriggersResponse>(responseBody)!;
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
    /// Delete (archive) points triggers by ID. Maximum 100 trigger IDs per request.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Triggers.DeleteAsync(new TriggersDeleteRequest());
    /// </code></example>
    public async Task<DeletePointsTriggersResponse> DeleteAsync(
        string systemId,
        TriggersDeleteRequest request,
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
                    Path = string.Format(
                        "points/{0}/triggers",
                        ValueConvert.ToPathParameterString(systemId)
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
                return JsonUtils.Deserialize<DeletePointsTriggersResponse>(responseBody)!;
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
    /// Update points triggers in bulk. Maximum 100 triggers per request. Only provided fields are updated; omitted fields are preserved.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Triggers.UpdateAsync(
    ///     "550e8400-e29b-41d4-a716-446655440000",
    ///     new List&lt;PatchPointsTriggersRequestItem&gt;() { new PatchPointsTriggersRequestItem { Id = "id" } }
    /// );
    /// </code></example>
    public async Task<PatchPointsTriggersResponse> UpdateAsync(
        string systemId,
        IEnumerable<PatchPointsTriggersRequestItem> request,
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
                    Path = string.Format(
                        "points/{0}/triggers",
                        ValueConvert.ToPathParameterString(systemId)
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
                return JsonUtils.Deserialize<PatchPointsTriggersResponse>(responseBody)!;
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
    /// Get a single points trigger by ID.
    /// </summary>
    /// <example><code>
    /// await client.Admin.Points.Triggers.GetAsync(
    ///     "550e8400-e29b-41d4-a716-446655440000",
    ///     "660f9500-f30c-42e5-b827-557766550001"
    /// );
    /// </code></example>
    public async Task<AdminPointsTrigger> GetAsync(
        string systemId,
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
                        "points/{0}/triggers/{1}",
                        ValueConvert.ToPathParameterString(systemId),
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
                return JsonUtils.Deserialize<AdminPointsTrigger>(responseBody)!;
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
