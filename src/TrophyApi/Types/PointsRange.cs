using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsRange
{
    /// <summary>
    /// The start of the points range. Inclusive.
    /// </summary>
    [JsonPropertyName("from")]
    public required int From { get; set; }

    /// <summary>
    /// The end of the points range. Inclusive.
    /// </summary>
    [JsonPropertyName("to")]
    public required int To { get; set; }

    /// <summary>
    /// The number of users in this points range.
    /// </summary>
    [JsonPropertyName("users")]
    public required int Users { get; set; }

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
