using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Notification preferences for each notification type.
/// </summary>
[Serializable]
public record NotificationPreferences : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
