using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/13/2024]
 * [player health]
 */

public class PlayerHealth : MonoBehaviour, BaseHealthScript
{
    private PlayerData _playerData;
    private PlayerController _playerController;

    private bool startDOT = false;

    /// <summary>
    /// get needed components
    /// </summary>
    private void OnEnable()
    {
        _playerData = GetComponent<PlayerData>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_playerController.hasChosenClass && !startDOT)
        {
            StartCoroutine(DamageOverTime());
            startDOT = true;
        }
    }

    /// <summary>
    /// damages player
    /// </summary>
    /// <param name="damage">how much damage to inflict</param>
    public void Damage(int damage)
    {
        int dmg = damage - _playerData.currentDefence;

        if (dmg < 0)
        {
            dmg = 0;
        }

        _playerData.currentHp -= dmg;
        //Debug.Log("Player curr HP: " + _playerData.currentHp);

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
        PlayerManager.Instance.UpdateFinalScore(this.gameObject, GetComponent<PlayerScore>().currentScore);
        Destroy(transform.root.gameObject);
    }

    private IEnumerator DamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Damage(1 + _playerData.currentDefence);
        }
    }
}
