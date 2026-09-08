using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using TrophyApi.Core;

namespace TrophyApi;

/// <summary>
/// Organization branding settings.
/// </summary>
[Serializable]
public record AdminSettingsBranding : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the app or platform.
    /// </summary>
    [JsonPropertyName("appName")]
    public required string AppName { get; set; }

    /// <summary>
    /// The URL of the app or platform.
    /// </summary>
    [JsonPropertyName("appUrl")]
    public required string AppUrl { get; set; }

    /// <summary>
    /// Primary brand color as hex (`#RGB` or `#RRGGBB`), `rgb(r,g,b)`, or `rgba(r,g,b,a)`.
    /// </summary>
    [JsonPropertyName("brandColor")]
    public required string BrandColor { get; set; }

    [JsonPropertyName("font")]
    public required AdminFontFamily Font { get; set; }

    /// <summary>
    /// Company logo used in emails, or `null` if none is set.
    /// </summary>
    [JsonPropertyName("logo")]
    public AdminSettingsBrandingLogo? Logo { get; set; }

    /// <summary>
    /// App icon used in push notification previews, or `null` if none is set.
    /// </summary>
    [JsonPropertyName("appIcon")]
    public AdminSettingsBrandingAppIcon? AppIcon { get; set; }

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
