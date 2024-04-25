using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author[s]: [Lam, Justin], [Burgess, Lillian]
 * Last Updated: [04/25/2024]
 * [enemy health]
 */

public class EnemeyHealthScript : MonoBehaviour, BaseHealthScript
{
    [SerializeField] private int _health;
    private int _currentHealth;
    [SerializeField] private bool _isMeleeable = true;

    private void OnEnable()
    {
        _currentHealth = _health;
        //Debug.Log("Health: " + _currentHealth);
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
    /// <summary>
    /// Actually set the enemy hp
    /// take the enemy level
    /// multiply it by 10 (the base _health)
    /// and set the current health to be _health
    /// </summary>
    /// <param name="enemyLvl"></param>
    public void SetEnemyHpTrue(int enemyLvl)
    {
        _health = _health * enemyLvl;
        _currentHealth = _health;
        Debug.Log("Health: " + _currentHealth);
    }

    public void Damage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);

        if (_currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        //grab the closest player
        //closestPlayer.GetComponent<PlayerData>().PlayerPoints(points);
        //might have the singleton handle this, instead passing in the points and the player that triggered this
        Destroy(this.gameObject);
    }

    public bool isMeleeable
    {
        get { return _isMeleeable; }
    }
}
