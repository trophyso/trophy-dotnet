using global::System.Text.Json.Serialization;
using TrophyApi;
using TrophyApi.Core;

namespace TrophyApi.Admin;

[Serializable]
public record UpdateAdminSettingsRequest
{
    [JsonPropertyName("branding")]
    public UpdateAdminSettingsBranding? Branding { get; set; }

    [JsonPropertyName("experimentation")]
    public UpdateAdminSettingsExperimentation? Experimentation { get; set; }

    [JsonPropertyName("aggregationPeriod")]
    public AdminAggregationPeriod? AggregationPeriod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
