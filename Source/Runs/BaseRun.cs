using System;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.GoldenETA.Runs;

public abstract class BaseRun
{
    protected float RoomStartTime;
    protected LevelData CurrentRoom;

    protected static float Now => DateTimeOffset.Now.ToUnixTimeMilliseconds() * .001f;

    public BaseRun()
    {
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

    protected float TimeNewRoom(LevelData next)
    {
        float now = Now;
        float time = now - RoomStartTime;
        
        RoomStartTime = now;
        CurrentRoom = next;

        return time;
    }

    private void OnDie(Player player)
    {
        OnRoomFail();
    }

    private void OnTransition(Level level, LevelData next, Vector2 direction)
    {
        OnRoomSuccess(next);
    }

    public abstract void OnRoomFail();
    public abstract void OnRoomSuccess(LevelData next);
}