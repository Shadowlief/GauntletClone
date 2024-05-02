using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/02/2024]
 * [enemy health]
 */

public class TestDamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Damage(20000);
        }
    }
}
