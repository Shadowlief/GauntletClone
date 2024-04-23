using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/20/2024]
 * [player health]
 */

public class PlayerHealth : MonoBehaviour, BaseHealthScript
{
    private PlayerData _playerData;

    private void OnEnable()
    {
        _playerData = GetComponent<PlayerData>();
    }

    public void Damage(int damage)
    {
        _playerData.currentHp -= (damage - _playerData.currentDefence);

        if (_playerData.currentHp <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Debug.Log("player died");
    }
}
