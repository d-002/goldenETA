namespace Celeste.Mod.GoldenETA;

public class KeysListeners
{
    public void OnPlayerUpdate(On.Celeste.Player.orig_Update orig, Player self)
    {
        orig(self);

        GoldenETAModuleSettings settings = GoldenETAModule.Settings;

        if (settings.ToggleMenu.Pressed) ToggleMenu();
        if (settings.StartPractice.Pressed) GoldenETAModule.RunsManager.StartPractice();
        if (settings.StartRuns.Pressed) GoldenETAModule.RunsManager.StartRuns();
        if (settings.StopLogging.Pressed) GoldenETAModule.RunsManager.StopLogging(false);
    }
    
    private void ToggleMenu()
    {
        GoldenETAModule.Settings.ShowMenu = !GoldenETAModule.Settings.ShowMenu;
    }
}