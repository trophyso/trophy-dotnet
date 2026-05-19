using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A tenant to create.
/// </summary>
[Serializable]
public record CreateTenantRequestItem
{
    /// <summary>
    /// The external customer ID. Must be unique within the environment.
    /// </summary>
    [JsonPropertyName("customerId")]
    public required string CustomerId { get; set; }

    /// <summary>
    /// Human-readable name for the tenant.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

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
