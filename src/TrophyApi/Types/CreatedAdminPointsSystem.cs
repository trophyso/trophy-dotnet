using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points system returned from the creation endpoint. Extends AdminPointsSystem with optional sub-entity arrays that are present when those sub-entities were included in the creation request.
/// </summary>
[Serializable]
public record CreatedAdminPointsSystem
{
    /// <summary>
    /// Levels created alongside the system. Present when levels were provided in the request.
    /// </summary>
    [JsonPropertyName("levels")]
    public IEnumerable<AdminPointsLevel>? Levels { get; set; }

    /// <summary>
    /// Boosts created alongside the system. Present when boosts were provided in the request.
    /// </summary>
    [JsonPropertyName("boosts")]
    public IEnumerable<AdminPointsBoost>? Boosts { get; set; }

    /// <summary>
    /// Triggers created alongside the system. Present when triggers were provided in the request.
    /// </summary>
    [JsonPropertyName("triggers")]
    public IEnumerable<AdminPointsTrigger>? Triggers { get; set; }

    /// <summary>
    /// The UUID of the points system.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The points system name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The points system key.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The points system description.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The points system status.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminPointsSystemStatus Status { get; set; }

    /// <summary>
    /// The badge for the points system.
    /// </summary>
    [JsonPropertyName("badge")]
    public AdminPointsSystemBadge? Badge { get; set; }

    /// <summary>
    /// The maximum points a user can earn.
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
