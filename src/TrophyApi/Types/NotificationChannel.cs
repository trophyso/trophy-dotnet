using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[JsonConverter(typeof(EnumSerializer<NotificationChannel>))]
public enum NotificationChannel
{
    [EnumMember(Value = "email")]
    Email,

    [EnumMember(Value = "push")]
    Push,
}
