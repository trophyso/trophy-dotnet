using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A daily leaderboard snapshot entry representing the user's rank/value state and the previous persisted state.
/// </summary>
[Serializable]
public record LeaderboardEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The leaderboard snapshot date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    /// <summary>
    /// Deprecated ISO timestamp for the snapshot day boundary. Use `date` instead.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// The user's rank before this event, or null if they were not on the leaderboard.
    /// </summary>
    [JsonPropertyName("previousRank")]
    public int? PreviousRank { get; set; }

    /// <summary>
    /// The user's rank after this event, or null if they are no longer on the leaderboard.
    /// </summary>
    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    /// <summary>
    /// The user's value before this event, or null if they were not on the leaderboard.
    /// </summary>
    [JsonPropertyName("previousValue")]
    public int? PreviousValue { get; set; }

    /// <summary>
    /// The user's value after this event, or null if they are no longer on the leaderboard.
    /// </summary>
    [JsonPropertyName("value")]
    public int? Value { get; set; }

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
