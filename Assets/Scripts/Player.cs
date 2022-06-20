//#define ANDROID

using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action<float,float> OnScored;

    [SerializeField]
    private Rigidbody2D _RigidBody;

    [SerializeField]
    private Collider2D _Collider;
    [SerializeField]
    private InputManager _InputManager;

    [SerializeField]
    private PaddleData _Data;

    private Vector3 _StartPosition;

    private Vector3 _LastScorePosition;

    private void Awake()
    {
        _InputManager.OnMoveDelegate += OnMove;
        _StartPosition = transform.position;
    }

    private void OnMove(Vector2 vector)
    {
        _RigidBody.velocity = new Vector2(vector.x * _Data.Speed, _RigidBody.velocity.y);
    }

    internal void Reset()
    {
        transform.position = _StartPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            OnScored?.Invoke(collision.gameObject.transform.position.x, _LastScorePosition.x);

            _LastScorePosition = collision.gameObject.transform.position;
        }
    }
}
