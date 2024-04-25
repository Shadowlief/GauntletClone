using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/22/2024]
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
        Destroy(this.gameObject);
    }

    public bool isMeleeable
    {
        get { return _isMeleeable; }
    }
}
