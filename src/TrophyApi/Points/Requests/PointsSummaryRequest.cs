using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsSummaryRequest
{
    /// <summary>
    /// Optional colon-delimited user attribute filters in the format attributeKey:value,attributeKey:value. Only users matching ALL specified attributes will be included in the points breakdown.
    /// </summary>
    [JsonIgnore]
    public string? UserAttributes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
