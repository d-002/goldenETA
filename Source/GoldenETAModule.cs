using System;

namespace Celeste.Mod.GoldenETA;

public class GoldenETAModule : EverestModule {
    public static GoldenETAModule Instance { get; private set; }

    public override Type SettingsType => typeof(GoldenETAModuleSettings);
    public static GoldenETAModuleSettings Settings => (GoldenETAModuleSettings) Instance._Settings;

    public override Type SessionType => typeof(GoldenETAModuleSession);
    public static GoldenETAModuleSession Session => (GoldenETAModuleSession) Instance._Session;

    public override Type SaveDataType => typeof(GoldenETAModuleSaveData);
    public static GoldenETAModuleSaveData SaveData => (GoldenETAModuleSaveData) Instance._SaveData;

    public GoldenETAModule() {
        Instance = this;
#if DEBUG
        Logger.SetLogLevel(nameof(GoldenETAModule), LogLevel.Verbose);
#else
        Logger.SetLogLevel(nameof(GoldenETAModule), LogLevel.Info);
#endif
    }

    public override void Load()
    {
        Everest.Events.Level.OnTransitionTo += Toast.TempToast;
    }

    public override void Unload() {
        Everest.Events.Level.OnTransitionTo -= Toast.TempToast;
    }
}