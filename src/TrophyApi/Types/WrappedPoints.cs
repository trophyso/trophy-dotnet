using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user's points data for a wrapped period.
/// </summary>
[Serializable]
public record WrappedPoints : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
