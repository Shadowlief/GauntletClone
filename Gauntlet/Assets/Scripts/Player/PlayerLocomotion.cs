using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/16/2024]
 * [Handles Movement]
 */

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerData _playerData;
    private PlayerController _playerController;

    /// <summary>
    /// get needed components
    /// </summary>
    private void OnEnable()
    {
        _playerData = GetComponent<PlayerData>();
        _playerController = GetComponent<PlayerController>();
    }

    /// <summary>
    /// Handles movement
    /// </summary>
    private void HandleMovement()
    {
        Vector3 move = new Vector3(_playerController.horMovement, _playerController.virMovement, 0);

        transform.position += move * _playerData.currentMovementSpeed * Time.deltaTime;
    }
    
    /// <summary>
    /// handles rotation
    /// </summary>
    private void HandleRotation()
    {
        if (_playerController.horMovement > 0)
        {
            if (_playerController.virMovement > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 315);
            }
            else if (_playerController.virMovement < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 225);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
        }
        else if (_playerController.horMovement < 0)
        {
            if (_playerController.virMovement > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 45);
            }
            else if (_playerController.virMovement < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 135);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if (_playerController.virMovement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_playerController.virMovement < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    /// <summary>
    /// calls to handle movement
    /// </summary>
    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }
}
