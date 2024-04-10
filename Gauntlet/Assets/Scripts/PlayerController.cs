using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/09/2024]
 * [Script that has functions that are called for a player's control]
 */

public class PlayerController : MonoBehaviour
{
    //var of move input
    private Vector2 movementInput = Vector2.zero;

    /// <summary>
    /// put in Movement in Player Input
    /// 
    /// sets the move value from the inputs
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Debug.Log(gameObject.name + " " + movementInput);
    }
}
