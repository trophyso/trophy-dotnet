using TrophyApi;

namespace TrophyApi.Admin.Streaks;

public partial interface ISettingsClient
{
    /// <summary>
    /// Get the organization's streak configuration.
    /// </summary>
    WithRawResponseTask<StreakSettings> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the organization's streak configuration.
    /// </summary>
    WithRawResponseTask<StreakSettings> UpdateAsync(
        UpdateStreakSettingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
