using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin.Streaks;

[Serializable]
public record CreateStreakPausesRequestPausesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the user to create a pause for.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    /// <summary>
    /// The first date the pause covers, in YYYY-MM-DD format. Must not be before today in the user's timezone.
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The last date the pause covers, in YYYY-MM-DD format. Must be on or after start.
    /// </summary>
    [JsonPropertyName("end")]
    public required string End { get; set; }

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
