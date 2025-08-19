using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record PointsTriggerResponseEventAttribute
{
    /// <summary>
    /// The key of the event attribute.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The required value of the event attribute.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
