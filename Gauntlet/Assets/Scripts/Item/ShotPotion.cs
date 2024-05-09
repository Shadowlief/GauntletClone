using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/09/2024]
 * [Script that potions getting shot by enemy]
 */

public class ShotPotion : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;

    /// <summary>
    /// when a bullet hits a potion,
    /// explode with less effect
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerProjectileScript>())
        {
            PlayerProjectileScript projectile = other.GetComponent<PlayerProjectileScript>();

            Collider[] hitColliders = new Collider[100];
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _radius, hitColliders);

            for (int i = 0; i < numColliders; i++)
            {
                GameObject enemy = hitColliders[i].gameObject;
                if (enemy.GetComponent<EnemeyHealthScript>())
                {
                    EnemeyHealthScript health = enemy.GetComponent<EnemeyHealthScript>();

                    health.Damage(projectile.magic);
                }
            }
            Destroy(gameObject);
        }
    }
}
