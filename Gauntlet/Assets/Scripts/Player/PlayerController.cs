using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/07/2024]
 * [Script that has functions that are called for a player's control]
 */

public class PlayerController : MonoBehaviour
{
    //var of move input
    private Vector2 _movementInput = Vector2.zero;

    private float _horMovement;
    private float _virMovement;

    private bool _shoot = false;
    private bool _usePotion = false;

    private bool _hasChosenClass = false;

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

    public void OnShoot(InputAction.CallbackContext context)
    {
        _shoot = context.action.triggered;
    }

    public void OnUsePotion(InputAction.CallbackContext context)
    {
        _usePotion = context.action.triggered;
    }

    public void ChosenClass()
    {
        _hasChosenClass = true;
    }

    /// <summary>
    /// gets horizontal move input
    /// </summary>
    public float horMovement
    {
        get { return _horMovement; }
    }

    /// <summary>
    /// gets vertical move input
    /// </summary>
    public float virMovement
    {
        get { return _virMovement; }
    }

    public bool shoot
    {
        get { return _shoot; }
    }

    public bool usePotion
    {
        get { return _usePotion; }
    }

    public bool hasChosenClass
    {
        get { return _hasChosenClass; }
    }
}
