using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Notification preferences for each notification type.
/// </summary>
[Serializable]
public record NotificationPreferences
{
    /// <summary>
    /// Channels to receive achievement completion notifications on.
    /// </summary>
    [JsonPropertyName("achievement_completed")]
    public IEnumerable<NotificationChannel>? AchievementCompleted { get; set; }

    /// <summary>
    /// Channels to receive recap notifications on.
    /// </summary>
    [JsonPropertyName("recap")]
    public IEnumerable<NotificationChannel>? Recap { get; set; }

    /// <summary>
    /// Channels to receive reactivation notifications on.
    /// </summary>
    [JsonPropertyName("reactivation")]
    public IEnumerable<NotificationChannel>? Reactivation { get; set; }

    /// <summary>
    /// Channels to receive streak reminder notifications on.
    /// </summary>
    [JsonPropertyName("streak_reminder")]
    public IEnumerable<NotificationChannel>? StreakReminder { get; set; }

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
