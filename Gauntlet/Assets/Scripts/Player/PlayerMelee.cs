using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/22/2024]
 * [script to handle player melee]
 */

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemeyHealthScript>() != null)
        {
            EnemeyHealthScript enemyHealth = other.GetComponent<EnemeyHealthScript>();
            if (enemyHealth.isMeleeable)
            {

            }
        }
    }
}
