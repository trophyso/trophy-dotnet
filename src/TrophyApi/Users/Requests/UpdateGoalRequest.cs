using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record UpdateGoalRequest
{
    /// <summary>
    /// What the goal is, as messages name it. Null clears it.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// How the goal is completed. Changing it to `none` uncompletes the goal, and needs it to have a `dueAt`; changing it to `metric` needs a `metric` and `target`.
    /// </summary>
    [JsonPropertyName("completion")]
    public GoalCompletion? Completion { get; set; }

    /// <summary>
    /// When the goal is due, as an ISO 8601 date and time. Without an offset, it's in the user's timezone. Null clears it, except with `completion: none`.
    /// </summary>
    [JsonPropertyName("dueAt")]
    public string? DueAt { get; set; }

    /// <summary>
    /// When the user completed the goal, as an ISO 8601 date and time. Without an offset, it's in the user's timezone, and a time after now is read as now. Null uncompletes it. Not with `completion: none`, which is never completed, or `completion: metric`, which completes when its metric reaches the target.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public string? CompletedAt { get; set; }

    /// <summary>
    /// `completion: metric` only. The metric's key. Changing the metric, target or start checks the goal against its target again, which can complete or uncomplete it; other changes leave a completed goal completed.
    /// </summary>
    [JsonPropertyName("metric")]
    public string? Metric { get; set; }

    /// <summary>
    /// `completion: metric` only. The metric total that completes it.
    /// </summary>
    [JsonPropertyName("target")]
    public double? Target { get; set; }

    /// <summary>
    /// `completion: metric` only. The date, in the user's timezone, the metric total counts from.
    /// </summary>
    [JsonPropertyName("start")]
    public string? Start { get; set; }

    /// <summary>
    /// Replaces the goal's steps, in order: a step whose key the goal has is updated, the others are added, and steps left out are deleted. Not for a step, since steps are one level deep.
    /// </summary>
    [JsonPropertyName("steps")]
    public IEnumerable<GoalStepRequest>? Steps { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
