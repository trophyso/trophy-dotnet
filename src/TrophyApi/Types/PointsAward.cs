using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsAward : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the trigger award
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The points awarded by this trigger
    /// </summary>
    [JsonPropertyName("awarded")]
    public int? Awarded { get; set; }

    /// <summary>
    /// The date these points were awarded, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    /// <summary>
    /// The user's total points after this award occurred.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("trigger")]
    public PointsTrigger? Trigger { get; set; }

    /// <summary>
    /// Array of points boosts that applied to this award.
    /// </summary>
    [JsonPropertyName("boosts")]
    public IEnumerable<PointsBoost>? Boosts { get; set; }

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
