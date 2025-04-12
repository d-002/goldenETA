namespace Celeste.Mod.GoldenETA.Runs;

public class Run : BaseRun
{
    public Run() : base(LoggingMode.Runs) { }
    
    protected override void OnRoomFail()
    {
        Tooltip.Show($"F{TimeRoom():F3}");
    }

    protected override void OnRoomSuccess(LevelData next)
    {
        Tooltip.Show($"S{TimeRoom(next):F3}");
    }
}