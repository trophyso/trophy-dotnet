using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PatchPointsBoostsRequestItem
{
    /// <summary>
    /// The UUID of the boost to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Updated name for the boost.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Updated start date (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("start")]
    public string? Start { get; set; }

    /// <summary>
    /// Updated end date (YYYY-MM-DD) or null to remove end date.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// Updated points multiplier.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public double? Multiplier { get; set; }

    /// <summary>
    /// Updated rounding strategy.
    /// </summary>
    [JsonPropertyName("rounding")]
    public PatchPointsBoostsRequestItemRounding? Rounding { get; set; }

    /// <summary>
    /// Updated user attribute filters. Cannot be set on user-specific boosts. Set to null to clear.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<PatchPointsBoostsRequestItemUserAttributesItem>? UserAttributes { get; set; }

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
