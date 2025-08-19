using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record PointsSystemResponse
{
    /// <summary>
    /// The unique ID of the points system.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the points system.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The description of the points system.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The URL of the badge image for the points system, if one has been uploaded.
    /// </summary>
    [JsonPropertyName("badgeUrl")]
    public string? BadgeUrl { get; set; }

    /// <summary>
    /// Array of active triggers for this points system.
    /// </summary>
    [JsonPropertyName("triggers")]
    public IEnumerable<PointsTriggerResponse> Triggers { get; set; } =
        new List<PointsTriggerResponse>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
