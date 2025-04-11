namespace Celeste.Mod.GoldenETA;

public static class KeysListeners
{
    public static LoggingMode Mode = LoggingMode.None;
    
    public static void ToggleMenu()
    {
        GoldenETAModule.Settings.ShowMenu = !GoldenETAModule.Settings.ShowMenu;
    }

    public static void StartPractice()
    {
        Tooltip.Show("GoldenETA: Started practice mode");
        Mode = LoggingMode.Practice;
    }

    public static void StartRuns()
    {
        Tooltip.Show("GoldenETA: Started runs");
        Mode = LoggingMode.Runs;
    }

    public static void StopLogging()
    {
        Tooltip.Show($"GoldenETA: Ended {Mode} mode");
        Mode = LoggingMode.None;
    }
}