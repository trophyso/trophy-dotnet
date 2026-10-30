using TrophyApi;

namespace TrophyApi.Admin;

public partial interface IRewardsClient
{
    public TrophyApi.Admin.Rewards.ITriggersClient Triggers { get; }

    /// <summary>
    /// List rewards.
    /// </summary>
    WithRawResponseTask<IEnumerable<AdminReward>> ListAsync(
        RewardsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create rewards. Optionally include triggers in each reward payload to create them alongside the reward. A reward with any invalid trigger is not created.
    /// </summary>
    WithRawResponseTask<CreateRewardsResponse> CreateAsync(
        IEnumerable<CreateRewardRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete rewards by ID. Maximum 100 reward IDs per request. A deleted reward's triggers are deleted too.
    /// </summary>
    WithRawResponseTask<DeleteRewardsResponse> DeleteAsync(
        RewardsDeleteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update rewards by ID. Maximum 100 rewards per request. Only provided fields are updated; omitted fields are preserved. Use the reward triggers endpoints to change a reward's triggers.
    /// </summary>
    WithRawResponseTask<UpdateRewardsResponse> UpdateAsync(
        IEnumerable<UpdateRewardRequestItem> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a reward by ID.
    /// </summary>
    WithRawResponseTask<AdminReward> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
