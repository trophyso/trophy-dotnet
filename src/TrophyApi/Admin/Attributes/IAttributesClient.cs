using TrophyApi;

namespace TrophyApi.Admin;

public partial interface IAttributesClient
{
    /// <summary>
    /// List attributes.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminAttribute>> ListAsync(
        AttributesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create attributes.
    /// </summary>
    WithRawResponseTask<CreateAttributesResponse> CreateAsync(
        IEnumerable<CreateAttributeRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete attributes by ID.
    /// </summary>
    WithRawResponseTask<DeleteAttributesResponse> DeleteAsync(
        AttributesDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update attributes by ID.
    /// </summary>
    WithRawResponseTask<UpdateAttributesResponse> UpdateAsync(
        IEnumerable<UpdateAttributeRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an attribute by ID.
    /// </summary>
    WithRawResponseTask<AdminAttribute> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
