using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsRange : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The start of the points range. Inclusive.
    /// </summary>
    [JsonPropertyName("from")]
    public required int From { get; set; }

    /// <summary>
    /// The end of the points range. Inclusive.
    /// </summary>
    [JsonPropertyName("to")]
    public required int To { get; set; }

    /// <summary>
    /// The number of users in this points range.
    /// </summary>
    [JsonPropertyName("users")]
    public required int Users { get; set; }

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
