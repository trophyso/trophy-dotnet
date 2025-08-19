using TrophyApi.Core;

namespace TrophyApi;

public record PointsSummaryRequest
{
    /// <summary>
    /// Optional colon-delimited user attribute filters in the format attributeKey:value,attributeKey:value. Only users matching ALL specified attributes will be included in the points breakdown.
    /// </summary>
    public string? UserAttributes { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
