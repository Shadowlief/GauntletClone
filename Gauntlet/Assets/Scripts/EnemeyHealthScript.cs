using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/20/2024]
 * [enemy health]
 */

public class EnemeyHealthScript : MonoBehaviour, BaseHealthScript
{
    [SerializeField] private int _health;
    private int _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _health;
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

    }
}
