using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// An issue encountered while processing an item in an admin API request.
/// </summary>
[Serializable]
public record AdminIssue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the resource the issue relates to, when applicable.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the user the issue relates to, when applicable.
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>
    /// The ID of the points boost the issue relates to, when applicable.
    /// </summary>
    [JsonPropertyName("boostId")]
    public string? BoostId { get; set; }

    /// <summary>
    /// The zero-based index of the item the issue relates to, when no resource ID exists yet.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    /// The severity level of the issue.
    /// </summary>
    [JsonPropertyName("severity")]
    public required AdminIssueSeverity Severity { get; set; }

    /// <summary>
    /// A human-readable description of the issue.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

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
