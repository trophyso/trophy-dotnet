using TrophyApi;

namespace TrophyApi.Admin;

public partial interface IApplicationApiKeysClient
{
    /// <summary>
    /// Create application API keys scoped to specific users. Each key can only perform operations on behalf of the user it was created for.
    /// </summary>
    WithRawResponseTask<CreateApplicationKeysResponse> CreateAsync(
        IEnumerable<CreateApplicationKeyRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete application API keys by ID.
    /// </summary>
    WithRawResponseTask<DeleteApplicationKeysResponse> DeleteAsync(
        ApplicationApiKeysDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
