using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic
{
    private Ball _Ball;
    private Vector3 _StartScale;
    private Vector3 _StartPosition;

    public BallLogic(Ball ball)
    {
        _Ball = ball;
    }
    internal void Init()
    {
        _StartPosition = _Ball.RB.transform.position;
        _StartScale = _Ball.RB.transform.localScale;
        SetRandomSettings();
    }
    internal void Reset()
    {
        _Ball.RB.velocity = Vector3.zero;
        _Ball.RB.transform.position = _StartPosition;
        SetRandomSettings();
    }
    internal void SetRandomSettings()
    {
        _Ball.RB.transform.localScale = _StartScale * UnityEngine.Random.Range(_Ball.BallData.MinScale, _Ball.BallData.MaxScale);
        _Ball.Speed = UnityEngine.Random.Range(_Ball.BallData.MinSpeed, _Ball.BallData.MaxSpeed);
    }
    internal static Vector2 GetRandomVelocity()
    {
        float x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        return new Vector2(x, y);
    }
    internal void SetColor(Color color)
    {
        _Ball.Renderer.material.color = color;
    }

    internal Color GetColor()
    {
        return _Ball.Renderer.material.color;
    }
}
