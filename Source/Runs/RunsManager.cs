using System;
using Celeste.Mod.GoldenETA.Path;

namespace Celeste.Mod.GoldenETA.Runs;

public class RunsManager
{
    public LoggingMode Mode { get; private set; } = LoggingMode.None;

    private BaseRun _currentRun;
    private Run _run;
    private Practice _practice;

    private RunPath _currentPath;

    public void Load()
    {
        _run = new Run();
        _practice = new Practice();
    }

    public void Unload()
    {
        _currentRun?.Stop(false);
        
        _run.Unload();
        _practice.Unload();
    }

    private bool LoadPath()
    {
        if (_currentPath != null) return true;

        GoldenETAModuleSettings settings = GoldenETAModule.Settings;
        PathsLoader loader = GoldenETAModule.PathsLoader;

        String path = settings.PathName == PathName.Custom ? settings.CustomPathName : settings.PathName.ToString();

        _currentPath = loader.LoadPath(path);
        if (loader.HasError)
        {
            Tooltip.Show(loader.Error);
            return false;
        }

        return true;
    }
    
    public void StartPractice()
    {
        if (GoldenETAModule.PathsLoader.HasError) Tooltip.Show(GoldenETAModule.PathsLoader.Error);
        
        if (Mode == LoggingMode.Practice) return;
        Mode = LoggingMode.Practice;
        
        _currentRun?.Stop(false);
        _practice.Start();
        _currentRun = _practice;
        
        Tooltip.Show($"GoldenETA: Started {Mode} mode");
    }

    public void StartRuns()
    {
        if (!LoadPath()) return;
        
        if (Mode == LoggingMode.Runs) return;
        Mode = LoggingMode.Runs;
        
        _currentRun?.Stop(false);
        _run.Start();
        _currentRun = _run;
        
        Tooltip.Show($"GoldenETA: Started {Mode} mode");
    }

    public void StopLogging(bool pathSuccess)
    {
        if (Mode == LoggingMode.None) return;
        
        _currentRun?.Stop(pathSuccess);
        _currentRun = null;
        
        Tooltip.Show($"GoldenETA: Ended {Mode} mode");
        Mode = LoggingMode.None;
    }
}