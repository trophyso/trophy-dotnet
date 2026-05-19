using System.Text.Json;
using System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Response containing updated tenants and any issues.
/// </summary>
[Serializable]
public record UpdateTenantsResponse
{
    /// <summary>
    /// Array of successfully updated tenants.
    /// </summary>
    [JsonPropertyName("updated")]
    public IEnumerable<AdminTenant> Updated { get; set; } = new List<AdminTenant>();

    /// <summary>
    /// Array of issues encountered during update.
    /// </summary>
    [JsonPropertyName("issues")]
    public IEnumerable<AdminIssue> Issues { get; set; } = new List<AdminIssue>();

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
