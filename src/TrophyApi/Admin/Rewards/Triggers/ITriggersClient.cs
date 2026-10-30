using TrophyApi;

namespace TrophyApi.Admin.Rewards;

public partial interface ITriggersClient
{
    /// <summary>
    /// List triggers for a reward. Active triggers are listed first.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminRewardTrigger>> ListAsync(
        string rewardId,
        TriggersListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create reward triggers in bulk. Maximum 100 triggers per request.
    /// </summary>
    WithRawResponseTask<CreateRewardTriggersResponse> CreateAsync(
        string rewardId,
        IEnumerable<CreateRewardTriggerRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete reward triggers by ID. Maximum 100 trigger IDs per request. A reward with no triggers is not awarded until a trigger is added.
    /// </summary>
    WithRawResponseTask<DeleteRewardTriggersResponse> DeleteAsync(
        string rewardId,
        TriggersDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update reward triggers in bulk. Maximum 100 triggers per request. Only provided fields are updated; omitted fields are preserved. A trigger keeps its ID when its criteria change.
    /// </summary>
    WithRawResponseTask<UpdateRewardTriggersResponse> UpdateAsync(
        string rewardId,
        IEnumerable<UpdateRewardTriggersRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single reward trigger by ID.
    /// </summary>
    WithRawResponseTask<AdminRewardTrigger> GetAsync(
        string rewardId,
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
