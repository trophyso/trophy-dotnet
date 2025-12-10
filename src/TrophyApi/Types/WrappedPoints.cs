using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user's points data for a wrapped period.
/// </summary>
[Serializable]
public record WrappedPoints
{
    /// <summary>
    /// The name of the points system.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The description of the points system.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The user's current total points.
    /// </summary>
    [JsonPropertyName("currentTotal")]
    public required double CurrentTotal { get; set; }

    /// <summary>
    /// The change in points during the period.
    /// </summary>
    [JsonPropertyName("changeThisPeriod")]
    public required double ChangeThisPeriod { get; set; }

    /// <summary>
    /// The percentage change in points during the period.
    /// </summary>
    [JsonPropertyName("percentChange")]
    public required double PercentChange { get; set; }

    /// <summary>
    /// The user's percentile rank for this points system during the period. Only included for weekly, monthly, and yearly aggregation periods.
    /// </summary>
    [JsonPropertyName("percentileThisPeriod")]
    public double? PercentileThisPeriod { get; set; }

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
