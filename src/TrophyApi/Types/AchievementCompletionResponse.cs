using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record AchievementCompletionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the completion.
    /// </summary>
    [JsonPropertyName("completionId")]
    public required string CompletionId { get; set; }

    [JsonPropertyName("achievement")]
    public required UserAchievementResponse Achievement { get; set; }

    /// <summary>
    /// A map of points systems by key that were affected by this achievement completion.
    /// </summary>
    [JsonPropertyName("points")]
    public Dictionary<string, MetricEventPointsResponse> Points { get; set; } =
        new Dictionary<string, MetricEventPointsResponse>();

    /// <summary>
    /// A map of leaderboards by key. Only contains leaderboards that were affected by this achievement completion.
    /// </summary>
    [JsonPropertyName("leaderboards")]
    public Dictionary<string, MetricEventLeaderboardResponse> Leaderboards { get; set; } =
        new Dictionary<string, MetricEventLeaderboardResponse>();

    /// <summary>
    /// Rewards awarded as a result of this achievement completion.
    /// </summary>
    [JsonPropertyName("rewards")]
    public IEnumerable<UserRewardResponse> Rewards { get; set; } = new List<UserRewardResponse>();

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
