using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UsersWrappedRequest
{
    /// <summary>
    /// The year to get wrapped data for. Defaults to the current year. Must be an integer between 1 and the current year.
    /// </summary>
    [JsonIgnore]
    public int? Year { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
