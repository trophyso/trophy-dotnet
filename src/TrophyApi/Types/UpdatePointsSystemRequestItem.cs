using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points system update object. Only id is required; all other fields are optional.
/// </summary>
[Serializable]
public record UpdatePointsSystemRequestItem
{
    /// <summary>
    /// The UUID of the points system to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Updated name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Updated description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Updated badge. Set to null to remove.
    /// </summary>
    [JsonPropertyName("badge")]
    public UpdatePointsSystemRequestItemBadge? Badge { get; set; }

    /// <summary>
    /// Updated max points. Set to null to remove.
    /// </summary>
    [JsonPropertyName("maxPoints")]
    public int? MaxPoints { get; set; }

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
