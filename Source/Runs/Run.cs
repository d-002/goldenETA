namespace Celeste.Mod.GoldenETA.Runs;

public class Run : BaseRun
{
    public Run() : base(LoggingMode.Runs) { }
    
    protected override void OnRoomFail()
    {
        Tooltip.Show($"Died, room time: {TimeRoom():F3}s");
    }

    protected override void OnRoomSuccess(LevelData next)
    {
        Tooltip.Show($"Room time: {TimeRoom(next):F3}s");
    }
}