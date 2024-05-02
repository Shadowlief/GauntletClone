using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/25/2024]
 * [Script that handles projectiles from enemies]
 */
public class EnemyProjectile : MonoBehaviour
{
    private bool _moving = false;

    private float _speed;
    private int _damage;

    /// <summary>
    /// sets the vars for the projectile and tells it to move
    /// </summary>
    /// <param name="dir">direction of the projectile</param>
    /// <param name="spe">speed of the projectile</param>
    /// <param name="dmg">damage of the projectile</param>
    public void SetUp(float spe, int dmg)
    {
        _speed = spe;
        _damage = dmg;

        _moving = true;
    }

    private void Update()
    {
        if (_moving)
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseHealthScript>() != null)
        {
            Debug.Log("Hit Something!");
            other.GetComponent<BaseHealthScript>().Damage(_damage);
        }

        Destroy(gameObject);
    }
}
