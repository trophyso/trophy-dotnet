namespace TrophyApi.Admin.Points;

public partial interface IPointsClient
{
    public ISystemsClient Systems { get; }
    public IBoostsClient Boosts { get; }
    public ILevelsClient Levels { get; }
    public ITriggersClient Triggers { get; }
}
