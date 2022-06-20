using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSimulation 
{
    private Ball _Ball;
    public BallSimulation(Ball ball)
    {
        _Ball = ball;
    }
    internal void CorrectSpeedAndDirection(float currentPosition, float previousCollisionPosition)
    {
        AddSpeedIfNeed(ChangeDirectionIfNeed(currentPosition, previousCollisionPosition));
    }
    internal bool ChangeDirectionIfNeed(float x1, float x2)
    {
        if (Mathf.Abs(x1 - x2) <= _Ball.BallData.MinimalCollisionPositionDelta)
        {
            _Ball.RB.velocity = new Vector2(_Ball.RB.velocity.x + _Ball.Speed, _Ball.RB.velocity.y);

            return true;
        }

        return false;
    }
    internal void AddSpeedIfNeed(bool isChangedDir)
    {
        if (!isChangedDir && _Ball.RB.velocity.magnitude <= _Ball.Speed)
        {
            _Ball.RB.AddForce(_Ball.RB.velocity * _Ball.Speed);
        }
    }
    internal void OnCollision(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (_Ball.RB.velocity.y == 0)
            {
                _Ball.RB.velocity = new Vector2(_Ball.RB.velocity.x, _Ball.RB.velocity.y + _Ball.Speed);
            }
        }
    }
    internal void Launch()
    {
        Vector2 velocity = BallLogic.GetRandomVelocity();
        _Ball.RB.velocity = new Vector2(_Ball.Speed * velocity.x, _Ball.Speed * velocity.y);
    }
}
