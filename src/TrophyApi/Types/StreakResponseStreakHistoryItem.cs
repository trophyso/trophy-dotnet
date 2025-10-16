using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An object representing a past streak period.
/// </summary>
[Serializable]
public record StreakResponseStreakHistoryItem
{
    /// <summary>
    /// The date this streak period started.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public required string PeriodStart { get; set; }

    /// <summary>
    /// The date this streak period ended.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public required string PeriodEnd { get; set; }

    /// <summary>
    /// The length of the user's streak during this period.
    /// </summary>
    [JsonPropertyName("length")]
    public required int Length { get; set; }

    /// <summary>
    /// Whether the user used a streak freeze during this period. Only present if the organization has enabled streak freezes.
    /// </summary>
    [JsonPropertyName("usedFreeze")]
    public bool? UsedFreeze { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
