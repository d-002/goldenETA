using Celeste.Mod.GoldenETA.Message;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.GoldenETA;

public static class Toast
{
    public static void TempToast(Level level, LevelData next, Vector2 direction)
    {
       Tooltip.Show("Hello world");
    }
}