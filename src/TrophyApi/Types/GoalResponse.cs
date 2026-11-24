using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A user's goal or step.
/// </summary>
[Serializable]
public record GoalResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The goal's unique ID. A goal deleted and created again with the same key gets a new one.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The goal's key, unique per user.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The key of the goal it's a step of, or null if it has no parent.
    /// </summary>
    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    /// <summary>
    /// What the goal is, as messages name it.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("completion")]
    public required GoalCompletion Completion { get; set; }

    /// <summary>
    /// When the goal is due, or null if it has no due time.
    /// </summary>
    [JsonPropertyName("dueAt")]
    public DateTime? DueAt { get; set; }

    /// <summary>
    /// When the user completed the goal, or null if they haven't.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public DateTime? CompletedAt { get; set; }

    [JsonPropertyName("status")]
    public required GoalStatus Status { get; set; }

    /// <summary>
    /// Its steps, in order. Empty for a goal without steps, and for a step.
    /// </summary>
    [JsonPropertyName("steps")]
    public IEnumerable<GoalResponse> Steps { get; set; } = new List<GoalResponse>();

    /// <summary>
    /// How many of its steps are completed.
    /// </summary>
    [JsonPropertyName("done")]
    public required int Done { get; set; }

    /// <summary>
    /// How many steps it has.
    /// </summary>
    [JsonPropertyName("total")]
    public required int Total { get; set; }

    /// <summary>
    /// `completion: metric` only. The metric's key.
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
    /// `completion: metric` only. The metric total since `start`.
    /// </summary>
    [JsonPropertyName("current")]
    public double? Current { get; set; }

    /// <summary>
    /// When the goal was created.
    /// </summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; set; }

    /// <summary>
    /// When the goal was last changed.
    /// </summary>
    [JsonPropertyName("updated")]
    public required DateTime Updated { get; set; }

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
