using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A tenant in a multi-tenant environment.
/// </summary>
[Serializable]
public record AdminTenant
{
    /// <summary>
    /// The tenant UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The external customer ID for this tenant.
    /// </summary>
    [JsonPropertyName("customerId")]
    public required string CustomerId { get; set; }

    /// <summary>
    /// Human-readable name for the tenant.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The lifecycle status of the tenant.
    /// </summary>
    [JsonPropertyName("status")]
    public required AdminTenantStatus Status { get; set; }

    /// <summary>
    /// When the tenant was created.
    /// </summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; set; }

    /// <summary>
    /// When the tenant was last updated.
    /// </summary>
    [JsonPropertyName("updated")]
    public required DateTime Updated { get; set; }

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
