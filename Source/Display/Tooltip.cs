// shamelessly copied from DemoJameson.SpeedrunTool

using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.GoldenETA;

[Tracked]
public class Tooltip : Entity {
    private const int Padding = 25;
    private readonly string _message;
    private float _alpha;
    private float _unEasedAlpha;
    private readonly float _duration;

    private Tooltip(string message, float duration = 1f) {
        _message = message;
        _duration = duration;
        Vector2 messageSize = ActiveFont.Measure(message);
        Position = new(Padding, Engine.Height - messageSize.Y - Padding / 2f);
        Tag = Tags.HUD | Tags.Global | Tags.FrozenUpdate | Tags.PauseUpdate | Tags.TransitionUpdate;
        Add(new Coroutine(Show()));
    }

    private IEnumerator Show() {
        while (_alpha < 1f) {
            _unEasedAlpha = Calc.Approach(_unEasedAlpha, 1f, Engine.RawDeltaTime * 5f);
            _alpha = Ease.SineOut(_unEasedAlpha);
            yield return null;
        }

        yield return Dismiss();
    }

    private IEnumerator Dismiss() {
        yield return _duration;
        while (_alpha > 0f) {
            _unEasedAlpha = Calc.Approach(_unEasedAlpha, 0f, Engine.RawDeltaTime * 5f);
            _alpha = Ease.SineIn(_unEasedAlpha);
            yield return null;
        }

        RemoveSelf();
    }

    public override void Render() {
        base.Render();
        ActiveFont.DrawOutline(_message, Position, Vector2.Zero, Vector2.One, Color.White * _alpha, 2,
            Color.Black * (_alpha * _alpha * _alpha));
    }

    public static void Show(string message, float duration = 1f) {
        if (Engine.Scene is { } scene) {
            if (!scene.Tracker.Entities.TryGetValue(typeof(Tooltip), out var tooltips)) {
                tooltips = scene.Entities.FindAll<Tooltip>().Cast<Entity>().ToList();
            }
            tooltips.ForEach(entity => entity.RemoveSelf());
            scene.Add(new Tooltip(message, duration));
        }
    }
}