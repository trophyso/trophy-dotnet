using TrophyApi;

namespace TrophyApi.Admin;

public partial interface ITenantsClient
{
    /// <summary>
    /// List tenants in the current environment.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminTenant>> ListAsync(
        TenantsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create tenants.
    /// </summary>
    WithRawResponseTask<CreateTenantsResponse> CreateAsync(
        IEnumerable<CreateTenantRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete tenants by ID.
    /// </summary>
    WithRawResponseTask<DeleteTenantsResponse> DeleteAsync(
        TenantsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update tenants by ID.
    /// </summary>
    WithRawResponseTask<UpdateTenantsResponse> UpdateAsync(
        IEnumerable<UpdateTenantRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a tenant by ID.
    /// </summary>
    WithRawResponseTask<AdminTenant> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
