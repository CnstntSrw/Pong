using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action<Vector2> OnMoveDelegate;
    internal void OnMove(InputValue input)
    {
        Vector2 vector;
        if (PlayerInput.all[0].currentControlScheme == "Touch")
        {
            vector = new Vector2(input.Get<Vector2>().x / 40, input.Get<Vector2>().y / 40);
        }
        else
        {
            vector = new Vector2(input.Get<Vector2>().x, input.Get<Vector2>().y);
        }
        OnMoveDelegate?.Invoke(vector);
    }
}
