using TrophyApi;
using TrophyApi.Admin.Streaks;

namespace TrophyApi.Admin;

public partial interface IStreaksClient
{
    public IFreezesClient Freezes { get; }

    /// <summary>
    /// Restore streaks for multiple users to the maximum previously achieved streak length found within the current restore window: the last 90 days for daily streaks, weekly periods starting with the week containing the start of the current calendar year for weekly streaks, and monthly periods starting at the beginning of the previous calendar year for monthly streaks.
    /// </summary>
    WithRawResponseTask<RestoreStreaksResponse> RestoreAsync(
        RestoreStreaksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
