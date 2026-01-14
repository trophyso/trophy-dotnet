using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<NotificationType>))]
public enum NotificationType
{
    [EnumMember(Value = "achievement_completed")]
    AchievementCompleted,

    [EnumMember(Value = "recap")]
    Recap,

    [EnumMember(Value = "reactivation")]
    Reactivation,

    [EnumMember(Value = "streak_reminder")]
    StreakReminder,
}
