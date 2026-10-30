using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record RewardsRedeemRequest
{
    /// <summary>
    /// The user redeeming the reward. The user must already exist.
    /// </summary>
    [JsonPropertyName("user")]
    public required UpsertedUser User { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
