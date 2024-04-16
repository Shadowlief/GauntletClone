using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/16/2024]
 * [Script that has functions that are called for a player's control]
 */

public class PlayerController : MonoBehaviour
{
    //var of move input
    private Vector2 _movementInput = Vector2.zero;

    private float _horMovement;
    private float _virMovement;

    /// <summary>
    /// put in Movement in Player Input
    /// 
    /// sets the move value from the inputs
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();

        Vector2 movement = Vector2.zero;
        if (_movementInput.x > 0)
        {
            movement.x = 1f;
        }
        else if (_movementInput.x < 0)
        {
            movement.x = -1f;
        }
        if (_movementInput.y > 0)
        {
            movement.y = 1f;
        }
        else if (_movementInput.y < 0)
        {
            movement.y = -1f;
        }

        movement = movement.normalized;

        _horMovement = movement.x;
        _virMovement = movement.y;
    }

    private void Update()
    {
        Debug.Log(_horMovement + " " + _virMovement);
    }
}
