using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UserRewardResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the reward redemption.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("awardedAt")]
    public required DateTime AwardedAt { get; set; }

    [JsonPropertyName("redeemed")]
    public required bool Redeemed { get; set; }

    [JsonPropertyName("redeemedAt")]
    public DateTime? RedeemedAt { get; set; }

    [JsonPropertyName("reward")]
    public required RewardSummary Reward { get; set; }

    [JsonPropertyName("trigger")]
    public UserRewardTrigger? Trigger { get; set; }

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
