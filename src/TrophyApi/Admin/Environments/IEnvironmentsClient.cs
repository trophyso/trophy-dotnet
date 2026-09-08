using TrophyApi;

namespace TrophyApi.Admin;

public partial interface IEnvironmentsClient
{
    /// <summary>
    /// List active environments.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminEnvironment>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
