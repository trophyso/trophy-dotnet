using TrophyApi;

namespace TrophyApi.Admin;

public partial interface ISettingsClient
{
    /// <summary>
    /// Get branding, experimentation, and aggregation settings.
    /// </summary>
    WithRawResponseTask<AdminSettings> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update branding, experimentation, and aggregation settings.
    /// </summary>
    WithRawResponseTask<AdminSettings> UpdateAsync(
        UpdateAdminSettingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
