using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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
    /// <example>
    /// <code>
    /// await client.Metrics.EventAsync(
    ///     "words-written",
    ///     new MetricsEventRequest
    ///     {
    ///         User = new EventRequestUser
    ///         {
    ///             Id = "18",
    ///             Email = "jk.rowling@harrypotter.com",
    ///             Tz = "Europe/London",
    ///         },
    ///         Value = 750,
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<EventResponse> EventAsync(
        string key,
        MetricsEventRequest request,
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
                    Path = $"metrics/{key}/event",
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
                return JsonUtils.Deserialize<EventResponse>(responseBody)!;
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
