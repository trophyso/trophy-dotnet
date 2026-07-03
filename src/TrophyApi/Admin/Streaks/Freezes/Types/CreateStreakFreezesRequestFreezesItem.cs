using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

[Serializable]
public record CreateStreakFreezesRequestFreezesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the user to create a freeze for.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

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
