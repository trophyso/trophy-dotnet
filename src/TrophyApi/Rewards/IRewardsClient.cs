namespace TrophyApi;

public partial interface IRewardsClient
{
    /// <summary>
    /// Redeem a reward for a user.
    /// </summary>
    WithRawResponseTask<RedeemRewardResponse> RedeemAsync(
        string key,
        RewardsRedeemRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
