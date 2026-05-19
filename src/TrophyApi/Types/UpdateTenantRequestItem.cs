using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// A tenant to update.
/// </summary>
[Serializable]
public record UpdateTenantRequestItem
{
    /// <summary>
    /// The UUID of the tenant to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// New external customer ID.
    /// </summary>
    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// New display name for the tenant.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
