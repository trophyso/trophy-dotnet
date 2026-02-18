using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record PointsBoostsRequest
{
    /// <summary>
    /// When set to 'true', boosts that have finished (past their end date) will be included in the response. By default, finished boosts are excluded.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeFinished { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
