using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

[Serializable]
public record CreateGoalRequest
{
    /// <summary>
    /// The goal's key, unique per user. 1–100 letters, numbers, hyphens or underscores, and not `plural` or `singular`.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The key of a goal to add this to as a step, after its last. The parent can't be a step, can't have more than 100 steps, and the request can't have `steps`.
    /// </summary>
    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    /// <summary>
    /// What the goal is, as messages name it, e.g. "Spanish B1 exam".
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// How the goal is completed. Defaults to `manual`.
    /// </summary>
    [JsonPropertyName("completion")]
    public GoalCompletion? Completion { get; set; }

    /// <summary>
    /// When the goal is due, as an ISO 8601 date and time. Without an offset, it's in the user's timezone. Required with `completion: none`.
    /// </summary>
    [JsonPropertyName("dueAt")]
    public string? DueAt { get; set; }

    /// <summary>
    /// When the user completed the goal, if they already have, as an ISO 8601 date and time. Without an offset, it's in the user's timezone, and a time after now is read as now. Not with `completion: none`, which is never completed, or `completion: metric`, which completes when its metric reaches the target.
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

    /// <summary>
    /// The goal's steps, in order, each with its own key.
    /// </summary>
    [JsonPropertyName("steps")]
    public IEnumerable<GoalStepRequest>? Steps { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
