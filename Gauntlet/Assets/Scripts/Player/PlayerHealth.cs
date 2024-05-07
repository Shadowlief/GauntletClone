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

    /// <summary>
    /// get needed components
    /// </summary>
    private void OnEnable()
    {
        _playerData = GetComponent<PlayerData>();
    }

    /// <summary>
    /// damages player
    /// </summary>
    /// <param name="damage">how much damage to inflict</param>
    public void Damage(int damage)
    {
        _playerData.currentHp -= (damage - _playerData.currentDefence);
        Debug.Log("Player curr HP: " + _playerData.currentHp);

        if (_playerData.currentHp <= 0)
        {
            OnDeath();
        }
    }

    /// <summary>
    /// what happens on death
    /// </summary>
    public void OnDeath()
    {
        Destroy(transform.root.gameObject);
    }
}
