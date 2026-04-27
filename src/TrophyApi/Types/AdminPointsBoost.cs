using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points boost as returned from admin endpoints.
/// </summary>
[Serializable]
public record AdminPointsBoost
{
    /// <summary>
    /// The UUID of the boost.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the boost.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The status of the boost.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminPointsBoostStatus Status { get; set; }

    /// <summary>
    /// The start date (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The end date (YYYY-MM-DD) or null if no end date.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The points multiplier.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public required double Multiplier { get; set; }

    /// <summary>
    /// How boosted points are rounded.
    /// </summary>
    [JsonPropertyName("rounding")]
    public required AdminPointsBoostRounding Rounding { get; set; }

    /// <summary>
    /// The customer ID of the user the boost was created for, or null for global/attribute-filtered boosts.
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>
    /// User attribute filters applied to the boost. Only present for non-user-specific boosts (i.e. when `userId` is null). Empty array if no filters are set.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<AdminPointsBoostUserAttributesItem>? UserAttributes { get; set; }

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
