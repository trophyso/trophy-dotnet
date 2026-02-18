using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A successfully created points boost returned from the create endpoint.
/// </summary>
[Serializable]
public record CreatedPointsBoost
{
    /// <summary>
    /// The UUID of the created boost.
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
    public required CreatedPointsBoostStatus Status { get; set; }

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
    public required CreatedPointsBoostRounding Rounding { get; set; }

    /// <summary>
    /// The customer ID of the user the boost was created for.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

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
