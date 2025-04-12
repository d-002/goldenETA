using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.GoldenETA.Runs;

public abstract class BaseRun
{
    protected float RoomStartTime;
    protected LevelData CurrentRoom;

    private readonly LoggingMode _mode;

    private static float Now => Engine.Scene.TimeActive;

    protected BaseRun(LoggingMode mode)
    {
        _mode = mode;
        Everest.Events.Level.OnTransitionTo += OnTransition;
        Everest.Events.Player.OnDie += OnDie;
    }

    public void Unload()
    {
        Everest.Events.Level.OnTransitionTo -= OnTransition;
        Everest.Events.Player.OnDie -= OnDie;
    }
    
    public void Start()
    {
        RoomStartTime = Now;
        CurrentRoom = ((Level)Engine.Scene).Session.LevelData;
    }

    public void Stop()
    {
        
    }

    protected float TimeRoom(LevelData next = null)
    {
        // null: stay in the same room
        // otherwise, go to this new room
        
        float now = Now;
        float time = now - RoomStartTime;
        
        RoomStartTime = now;
        if (next != null) CurrentRoom = next;

        return time;
    }

    private void OnDie(Player player)
    {
        if (GoldenETAModule.RunsManager.Mode != _mode) return;
        
        OnRoomFail();
    }

    private void OnTransition(Level level, LevelData next, Vector2 direction)
    {
        if (GoldenETAModule.RunsManager.Mode != _mode) return;
        
        OnRoomSuccess(next);
    }

    protected abstract void OnRoomFail();
    protected abstract void OnRoomSuccess(LevelData next);
}