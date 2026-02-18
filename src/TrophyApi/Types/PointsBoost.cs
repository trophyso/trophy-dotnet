using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsBoost
{
    /// <summary>
    /// The ID of the points boost
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the points boost
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The status of the points boost
    /// </summary>
    [JsonPropertyName("status")]
    public required PointsBoostStatus Status { get; set; }

    /// <summary>
    /// The start date of the points boost
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The end date of the points boost
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The multiplier of the points boost
    /// </summary>
    [JsonPropertyName("multiplier")]
    public required double Multiplier { get; set; }

    /// <summary>
    /// The rounding method of the points boost
    /// </summary>
    [JsonPropertyName("rounding")]
    public required PointsBoostRounding Rounding { get; set; }

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
