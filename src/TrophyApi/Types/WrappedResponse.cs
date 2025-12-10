using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user's year-in-review wrapped data including activity summaries, metrics, points, achievements, streaks, and leaderboard rankings.
/// </summary>
[Serializable]
public record WrappedResponse
{
    /// <summary>
    /// The user's profile information.
    /// </summary>
    [JsonPropertyName("user")]
    public required User User { get; set; }

    /// <summary>
    /// The user's activity data for the wrapped year.
    /// </summary>
    [JsonPropertyName("activity")]
    public required WrappedActivity Activity { get; set; }

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
