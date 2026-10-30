using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UsersRewardsRequest
{
    /// <summary>
    /// When set, only return rewards that have or have not been redeemed.
    /// </summary>
    [JsonIgnore]
    public bool? Redeemed { get; set; }

    /// <summary>
    /// Inclusive start of the awarded-at range, as YYYY-MM-DD in UTC.
    /// </summary>
    [JsonIgnore]
    public string? StartDate { get; set; }

    /// <summary>
    /// Inclusive end of the awarded-at range, as YYYY-MM-DD in UTC.
    /// </summary>
    [JsonIgnore]
    public string? EndDate { get; set; }

    /// <summary>
    /// Number of rewards to skip. Defaults to 0.
    /// </summary>
    [JsonIgnore]
    public int? Skip { get; set; }

    /// <summary>
    /// Maximum number of rewards to return. Defaults to 100 and cannot exceed 100.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
