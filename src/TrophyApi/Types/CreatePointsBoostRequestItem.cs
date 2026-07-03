using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A points boost to create. May optionally target a specific user via `userId` or filter by user attributes via `userAttributes`. These two fields are mutually exclusive.
/// </summary>
[Serializable]
public record CreatePointsBoostRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the user to create a boost for. Mutually exclusive with `userAttributes` — providing `userAttributes` when `userId` is set will result in an error. Omit for a global boost.
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>
    /// The name of the boost.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The start date of the boost (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("start")]
    public required string Start { get; set; }

    /// <summary>
    /// The end date of the boost (YYYY-MM-DD). If null, the boost has no end date.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; set; }

    /// <summary>
    /// The points multiplier. Must be greater than 0, not equal to 1, and less than 100.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public required double Multiplier { get; set; }

    /// <summary>
    /// How to round the boosted points. Defaults to 'down'.
    /// </summary>
    [JsonPropertyName("rounding")]
    public CreatePointsBoostRequestItemRounding? Rounding { get; set; }

    /// <summary>
    /// User attribute filters for the boost. Cannot be provided when `userId` is set.
    /// </summary>
    [JsonPropertyName("userAttributes")]
    public IEnumerable<CreatePointsBoostRequestItemUserAttributesItem>? UserAttributes { get; set; }

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
