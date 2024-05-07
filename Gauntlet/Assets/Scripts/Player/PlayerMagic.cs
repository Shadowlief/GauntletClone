using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/07/2024]
 * [Script that handles the magic]
 */

public class PlayerMagic : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerData _playerData;
    private PlayerInventory _playerInventory;

    private bool _canUsePotion = true;

    private void OnEnable()
    {
        _playerController = GetComponent<PlayerController>();
        _playerData = GetComponent<PlayerData>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (_playerController.hasChosenClass)
        {
            HandleMagic();
        }
    }

    private void HandleMagic()
    {
        if (_playerController.usePotion && _canUsePotion)
        {

        }
    }
}
