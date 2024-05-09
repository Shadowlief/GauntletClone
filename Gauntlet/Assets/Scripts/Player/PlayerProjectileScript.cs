using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/09/2024]
 * [Script that handles projectiles from the player]
 */

public class PlayerProjectileScript : MonoBehaviour
{
    private bool _moving = false;

    private float _speed;
    private int _damage;
    private int _magic;

    /// <summary>
    /// sets the vars for the projectile and tells it to move
    /// </summary>
    /// <param name="dir">direction of the projectile</param>
    /// <param name="spe">speed of the projectile</param>
    /// <param name="dmg">damage of the projectile</param>
    public void SetUp(float spe, int dmg, int mag)
    {
        _speed = spe;
        _damage = dmg;
        _magic = mag;

        _moving = true;
    }

    /// <summary>
    /// moves projectile every frame
    /// </summary>
    private void Update()
    {
        if (_moving)
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }
    }

    /// <summary>
    /// when hits something, damage if can then destroy
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseHealthScript>() != null)
        {
            other.GetComponent<BaseHealthScript>().Damage(_damage);
        }

        Destroy(gameObject);
    }

    //getters

    public int magic
    {
        get { return _magic; }
    }
}
