using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsAward
{
    /// <summary>
    /// The ID of the trigger award
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The points awarded by this trigger
    /// </summary>
    [JsonPropertyName("awarded")]
    public int? Awarded { get; set; }

    /// <summary>
    /// The date these points were awarded, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    /// <summary>
    /// The user's total points after this award occurred.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("trigger")]
    public PointsTrigger? Trigger { get; set; }

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
