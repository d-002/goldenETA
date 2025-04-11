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
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(GoldenETAModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(GoldenETAModule), LogLevel.Info);
#endif
    }

    public override void Load() {
        // TODO: apply any hooks that should always be active
    }

    public override void Unload() {
        // TODO: unapply any hooks applied in Load()
    }
}