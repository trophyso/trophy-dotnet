using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record RedeemRewardResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("reward")]
    public required RewardSummary Reward { get; set; }

    /// <summary>
    /// The awards redeemed by this request, oldest first.
    /// </summary>
    [JsonPropertyName("redemptions")]
    public IEnumerable<RedeemedReward> Redemptions { get; set; } = new List<RedeemedReward>();

    /// <summary>
    /// Points granted by a points reward, keyed by points system key. Includes one award per redemption.
    /// </summary>
    [JsonPropertyName("points")]
    public Dictionary<string, MetricEventPointsResponse>? Points { get; set; }

    /// <summary>
    /// A map of leaderboards by key. Only contains leaderboards that were affected by the points this request granted.
    /// </summary>
    [JsonPropertyName("leaderboards")]
    public Dictionary<string, MetricEventLeaderboardResponse> Leaderboards { get; set; } =
        new Dictionary<string, MetricEventLeaderboardResponse>();

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
