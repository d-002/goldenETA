using Microsoft.Xna.Framework.Input;

namespace Celeste.Mod.GoldenETA;

public class GoldenETAModuleSettings : EverestModuleSettings
{
    [SettingSubText("Popup in-game menu to show consistency stats")]
    public bool ShowMenu { get; set; } = false;

    [SettingSubText("Max number of rooms (similar to LiveSplit's splits) displayed at once in the popup menu")]
    [SettingRange(5, 20)] public int MaxMenuLines { get; set; } = 10;
    
    // hotkeys
    [SettingSubHeader("General")]
    [DefaultButtonBinding(button: Buttons.LeftThumbstickUp, key: Keys.M)]
    public ButtonBinding ToggleMenu { get; set; }
    [DefaultButtonBinding(button: Buttons.LeftThumbstickDown, key: Keys.L)]
    public ButtonBinding StopLogging { get; set; }
    [DefaultButtonBinding(button: Buttons.LeftThumbstickLeft, key: Keys.P)]
    [SettingSubText("Start the practice mode, which will log rooms play time, but not change consistency")]
    public ButtonBinding StartPractice { get; set; }
    [SettingSubText("Start the runs mode, which will log path play time, and update rooms consistency")]
    [DefaultButtonBinding(button: Buttons.LeftThumbstickRight, key: Keys.O)]
    public ButtonBinding StartRuns { get; set; }

    [SettingSubHeader("Reset")]
    public ButtonBinding ResetRoomConsistency { get; set; }
    public ButtonBinding ResetPathConsistency { get; set; }
    public ButtonBinding ResetAllPathStats { get; set; }
}