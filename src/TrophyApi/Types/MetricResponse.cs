using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record MetricResponse
{
    /// <summary>
    /// The unique ID of the metric.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The unique key of the metric.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The name of the metric.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The status of the metric.
    /// </summary>
    [JsonPropertyName("status")]
    public required MetricStatus Status { get; set; }

    /// <summary>
    /// The user's current total for the metric.
    /// </summary>
    [JsonPropertyName("current")]
    public required double Current { get; set; }

    /// <summary>
    /// A list of the metric's achievements and the user's progress towards each.
    /// </summary>
    [JsonPropertyName("achievements")]
    public IEnumerable<CompletedAchievementResponse> Achievements { get; set; } =
        new List<CompletedAchievementResponse>();

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
