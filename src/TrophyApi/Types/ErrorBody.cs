using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

public record ErrorBody
{
    [JsonPropertyName("error")]
    public required string Error { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
