using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points system to create. Optionally include sub-entities.
/// </summary>
[Serializable]
public record CreatePointsSystemRequestItem
{
    /// <summary>
    /// The points system name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The points system key. Only alphanumeric characters, hyphens, and underscores are permitted.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// A short description of the points system.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// An optional badge for the points system.
    /// </summary>
    [JsonPropertyName("badge")]
    public CreatePointsSystemRequestItemBadge? Badge { get; set; }

    /// <summary>
    /// Optional maximum points a user can earn.
    /// </summary>
    [JsonPropertyName("maxPoints")]
    public int? MaxPoints { get; set; }

    /// <summary>
    /// Optional array of levels to create alongside the system.
    /// </summary>
    [JsonPropertyName("levels")]
    public IEnumerable<CreatePointsLevelRequestItem>? Levels { get; set; }

    /// <summary>
    /// Optional array of boosts to create alongside the system.
    /// </summary>
    [JsonPropertyName("boosts")]
    public IEnumerable<CreatePointsBoostRequestItem>? Boosts { get; set; }

    /// <summary>
    /// Optional array of triggers to create alongside the system.
    /// </summary>
    [JsonPropertyName("triggers")]
    public IEnumerable<CreatePointsTriggerRequestItem>? Triggers { get; set; }

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
