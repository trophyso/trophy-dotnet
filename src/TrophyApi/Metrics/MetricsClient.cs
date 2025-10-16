using System.Net.Http;
using System.Text.Json;
using System.Threading;
using TrophyApi.Core;

namespace TrophyApi;

public partial class MetricsClient
{
    private RawClient _client;

    internal MetricsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Increment or decrement the value of a metric for a user.
    /// </summary>
    /// <example><code>
    /// await client.Metrics.EventAsync(
    ///     "words-written",
    ///     new MetricsEventRequest
    ///     {
    ///         IdempotencyKey = "e4296e4b-8493-4bd1-9c30-5a1a9ac4d78f",
    ///         User = new UpsertedUser
    ///         {
    ///             Email = "user@example.com",
    ///             Name = "User",
    ///             Tz = "Europe/London",
    ///             DeviceTokens = new List&lt;string&gt;() { "token1", "token2" },
    ///             SubscribeToEmails = true,
    ///             Attributes = new Dictionary&lt;string, string&gt;()
    ///             {
    ///                 { "department", "engineering" },
    ///                 { "role", "developer" },
    ///             },
    ///             Id = "18",
    ///         },
    ///         Value = 750,
    ///         Attributes = new Dictionary&lt;string, string&gt;()
    ///         {
    ///             { "category", "writing" },
    ///             { "source", "mobile-app" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<EventResponse> EventAsync(
        string key,
        MetricsEventRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = new Headers(new Dictionary<string, string>() { });
        if (request.IdempotencyKey != null)
        {
            _headers["Idempotency-Key"] = request.IdempotencyKey;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Api,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "metrics/{0}/event",
                        ValueConvert.ToPathParameterString(key)
                    ),
                    Body = request,
                    Headers = _headers,
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
                return JsonUtils.Deserialize<EventResponse>(responseBody)!;
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
