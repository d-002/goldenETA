using Monocle;

namespace Celeste.Mod.GoldenETA.Runs;

public class Run : BaseRun
{
    public override void OnRoomFail()
    {
        Tooltip.Show("Died");
    }

    public override void OnRoomSuccess(LevelData next)
    {
        Tooltip.Show($"Room time: {TimeNewRoom(next):3F}");
    }
}