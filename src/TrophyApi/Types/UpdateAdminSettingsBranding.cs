using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Branding fields to update. Omitted fields stay as-is.
/// </summary>
[Serializable]
public record UpdateAdminSettingsBranding : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the app or platform.
    /// </summary>
    [JsonPropertyName("appName")]
    public string? AppName { get; set; }

    /// <summary>
    /// The URL of the app or platform.
    /// </summary>
    [JsonPropertyName("appUrl")]
    public string? AppUrl { get; set; }

    /// <summary>
    /// Primary brand color as hex (`#RGB` or `#RRGGBB`), `rgb(r,g,b)`, or `rgba(r,g,b,a)`.
    /// </summary>
    [JsonPropertyName("brandColor")]
    public string? BrandColor { get; set; }

    [JsonPropertyName("font")]
    public AdminFontFamily? Font { get; set; }

    /// <summary>
    /// Company logo, or `null` to clear it.
    /// </summary>
    [JsonPropertyName("logo")]
    public UpdateAdminSettingsBrandingLogo? Logo { get; set; }

    /// <summary>
    /// App icon, or `null` to clear it.
    /// </summary>
    [JsonPropertyName("appIcon")]
    public UpdateAdminSettingsBrandingAppIcon? AppIcon { get; set; }

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
