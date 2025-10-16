namespace TrophyApi.Core;

public interface IIsRetryableContent
{
    public bool IsRetryable { get; }
}
