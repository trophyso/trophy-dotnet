using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A step of a goal: a goal of its own, with its own key, one level deep. A step whose key the goal already has is updated, with fields left out staying as they are.
/// </summary>
[Serializable]
public record GoalStepRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The step's key, unique per user like any goal's. 1–100 letters, numbers, hyphens or underscores, and not `plural` or `singular`.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// What the step is, as messages name it.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// How the step is completed. Defaults to `manual`.
    /// </summary>
    [JsonPropertyName("completion")]
    public GoalCompletion? Completion { get; set; }

    /// <summary>
    /// When the step is due, as an ISO 8601 date and time. Without an offset, it's in the user's timezone.
    /// </summary>
    [JsonPropertyName("dueAt")]
    public string? DueAt { get; set; }

    /// <summary>
    /// When the user completed the step, as an ISO 8601 date and time. Without an offset, it's in the user's timezone, and a time after now is read as now. Null uncompletes it. Not with `completion: none`, which is never completed, or `completion: metric`, which completes when its metric reaches the target.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public string? CompletedAt { get; set; }

    /// <summary>
    /// The metric's key. Required with `completion: metric`, and only for it.
    /// </summary>
    [JsonPropertyName("metric")]
    public string? Metric { get; set; }

    /// <summary>
    /// The metric total that completes it. Required with `completion: metric`, and only for it.
    /// </summary>
    [JsonPropertyName("target")]
    public double? Target { get; set; }

    /// <summary>
    /// `completion: metric` only. The date, in the user's timezone, the metric total counts from. Defaults to today.
    /// </summary>
    [JsonPropertyName("start")]
    public string? Start { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
