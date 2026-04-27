using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PatchPointsBoostsRequestItemUserAttributesItem
{
    /// <summary>
    /// The UUID of the user attribute.
    /// </summary>
    [JsonPropertyName("attributeId")]
    public required string AttributeId { get; set; }

    /// <summary>
    /// The value to match.
    /// </summary>
    [JsonPropertyName("attributeValue")]
    public required string AttributeValue { get; set; }

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
