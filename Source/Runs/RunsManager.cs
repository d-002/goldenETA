namespace Celeste.Mod.GoldenETA.Runs;

public class RunsManager
{
    public LoggingMode Mode { get; private set; } = LoggingMode.None;

    private BaseRun _currentRun;
    private Run _run;
    private Practice _practice;

    public void Load()
    {
        _run = new Run();
        _practice = new Practice();
    }

    public void Unload()
    {
        _currentRun?.Stop();
        
        _run.Unload();
        _practice.Unload();
    }
    
    public void StartPractice()
    {
        if (Mode == LoggingMode.Practice) return;
        Mode = LoggingMode.Practice;
        
        _currentRun?.Stop();
        _practice.Start();
        _currentRun = _practice;
        
        Tooltip.Show($"GoldenETA: Started {Mode} mode");
    }

    public void StartRuns()
    {
        if (Mode == LoggingMode.Runs) return;
        Mode = LoggingMode.Runs;
        
        _currentRun?.Stop();
        _run.Start();
        _currentRun = _run;
        
        Tooltip.Show($"GoldenETA: Started {Mode} mode");
    }

    public void StopLogging()
    {
        if (Mode == LoggingMode.None) return;
        Mode = LoggingMode.None;
        
        _currentRun?.Stop();
        
        Tooltip.Show($"GoldenETA: Ended {Mode} mode");
    }
}