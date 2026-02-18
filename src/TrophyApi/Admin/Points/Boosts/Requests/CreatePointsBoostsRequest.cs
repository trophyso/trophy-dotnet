using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

[Serializable]
public record CreatePointsBoostsRequest
{
    /// <summary>
    /// The key of the points system to create boosts for.
    /// </summary>
    [JsonPropertyName("systemKey")]
    public required string SystemKey { get; set; }

    /// <summary>
    /// Array of boosts to create. Maximum 1,000 boosts per request.
    /// </summary>
    [JsonPropertyName("boosts")]
    public IEnumerable<CreatePointsBoostsRequestBoostsItem> Boosts { get; set; } =
        new List<CreatePointsBoostsRequestBoostsItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
