using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi.Admin.Points;

[Serializable]
public record CreatePointsBoostsRequestBoostsItem
{
    /// <summary>
    /// The ID of the user to create a boost for.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    /// <summary>
    /// The name of the boost.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The start date of the boost (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The end date of the boost (YYYY-MM-DD). If null, the boost has no end date.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The points multiplier. Must be greater than 0, not equal to 1, and less than 100.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public required double Multiplier { get; set; }

    /// <summary>
    /// How to round the boosted points. Defaults to 'down'.
    /// </summary>
    [JsonPropertyName("rounding")]
    public CreatePointsBoostsRequestBoostsItemRounding? Rounding { get; set; }

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
