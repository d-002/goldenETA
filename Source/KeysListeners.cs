namespace Celeste.Mod.GoldenETA;

public static class KeysListeners
{
    public static LoggingMode Mode = LoggingMode.None;
    
    public static void OnPlayerUpdate(On.Celeste.Player.orig_Update orig, Player self)
    {
        orig(self);

        GoldenETAModuleSettings settings = GoldenETAModule.Settings;

        if (settings.ToggleMenu.Pressed) ToggleMenu();
        if (settings.StartPractice.Pressed) StartPractice();
        if (settings.StartRuns.Pressed) StartRuns();
        if (settings.StopLogging.Pressed) StopLogging();
    }
    
    private static void ToggleMenu()
    {
        GoldenETAModule.Settings.ShowMenu = !GoldenETAModule.Settings.ShowMenu;
    }

    private static void StartPractice()
    {
        Mode = LoggingMode.Practice;
        Tooltip.Show($"GoldenETA: Started {Mode} mode");
    }

    private static void StartRuns()
    {
        Mode = LoggingMode.Runs;
        Tooltip.Show($"GoldenETA: Started {Mode} mode");
    }

    private static void StopLogging()
    {
        if (Mode == LoggingMode.None) return;
        
        Tooltip.Show($"GoldenETA: Ended {Mode} mode");
        Mode = LoggingMode.None;
    }
}