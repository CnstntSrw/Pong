using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Ball : MonoBehaviour
{
    public event Action OnFail;

    [SerializeField]
    internal Rigidbody2D RB;

    [SerializeField]
    internal BallData BallData;

    [SerializeField]
    internal Renderer Renderer;

    internal float Speed;


    private BallLogic _BallLogic;
    internal BallSimulation BallSimulation { get; private set; }


    // Start is called before the first frame update
    private void Awake()
    {
        _BallLogic = new BallLogic(this);
        BallSimulation = new BallSimulation(this);
        _BallLogic.Init();
        BallSimulation.Launch();
    }
    internal void Reset()
    {
        _BallLogic.Reset();
        BallSimulation.Launch();
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x) >= 10f || Mathf.Abs(transform.position.y) >= 10f)
        {
            OnFail?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnFail?.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallSimulation.OnCollision(collision);
    }
    internal void CorrectSpeedAndDirection(float currentPosition, float previousCollisionPosition)
    {
        BallSimulation.CorrectSpeedAndDirection(currentPosition, previousCollisionPosition);
    }
    internal void SetColor(Color color)
    {
        _BallLogic.SetColor(color);
    }

    internal Color GetColor()
    {
        return _BallLogic.GetColor();
    }
}
