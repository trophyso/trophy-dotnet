using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Points boost payload sent in points.boost_started and points.boost_finished webhook events.
/// </summary>
[Serializable]
public record PointsBoostWebhookPayload
{
    /// <summary>
    /// The ID of the points boost.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the points boost.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The status of the points boost.
    /// </summary>
    [JsonPropertyName("status")]
    public required PointsBoostWebhookPayloadStatus Status { get; set; }

    /// <summary>
    /// The customer-facing user ID that the boost is scoped to, or null for global boosts.
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>
    /// The ID of the points system this boost applies to.
    /// </summary>
    [JsonPropertyName("pointsSystemId")]
    public required string PointsSystemId { get; set; }

    /// <summary>
    /// The key of the points system this boost applies to.
    /// </summary>
    [JsonPropertyName("pointsSystemKey")]
    public required string PointsSystemKey { get; set; }

    /// <summary>
    /// The name of the points system this boost applies to.
    /// </summary>
    [JsonPropertyName("pointsSystemName")]
    public required string PointsSystemName { get; set; }

    /// <summary>
    /// The start date of the points boost (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The end date of the points boost (YYYY-MM-DD), or null if open-ended.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The multiplier applied to points during the boost.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public required double Multiplier { get; set; }

    /// <summary>
    /// The rounding method applied to boosted points.
    /// </summary>
    [JsonPropertyName("rounding")]
    public required PointsBoostWebhookPayloadRounding Rounding { get; set; }

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
