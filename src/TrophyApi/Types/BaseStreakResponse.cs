using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record BaseStreakResponse
{
    /// <summary>
    /// The length of the user's current streak.
    /// </summary>
    [JsonPropertyName("length")]
    public required int Length { get; set; }

    /// <summary>
    /// The frequency of the streak.
    /// </summary>
    [JsonPropertyName("frequency")]
    public required StreakFrequency Frequency { get; set; }

    /// <summary>
    /// The date the streak started.
    /// </summary>
    [JsonPropertyName("started")]
    public string? Started { get; set; }

    /// <summary>
    /// The start date of the current streak period.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public string? PeriodStart { get; set; }

    /// <summary>
    /// The end date of the current streak period.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public string? PeriodEnd { get; set; }

    /// <summary>
    /// The date the streak will expire if the user does not increment a metric.
    /// </summary>
    [JsonPropertyName("expires")]
    public string? Expires { get; set; }

    /// <summary>
    /// The number of available streak freezes. Only present if the organization has enabled streak freezes.
    /// </summary>
    [JsonPropertyName("freezes")]
    public int? Freezes { get; set; }

    /// <summary>
    /// The maximum number of streak freezes a user can have. Only present if the organization has enabled streak freezes.
    /// </summary>
    [JsonPropertyName("maxFreezes")]
    public int? MaxFreezes { get; set; }

    /// <summary>
    /// The interval at which the user will earn streak freezes, in days. Only present if the organization has enabled streak freeze auto-earn.
    /// </summary>
    [JsonPropertyName("freezeAutoEarnInterval")]
    public int? FreezeAutoEarnInterval { get; set; }

    /// <summary>
    /// The amount of streak freezes the user will earn per interval. Only present if the organization has enabled streak freeze auto-earn.
    /// </summary>
    [JsonPropertyName("freezeAutoEarnAmount")]
    public int? FreezeAutoEarnAmount { get; set; }

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
