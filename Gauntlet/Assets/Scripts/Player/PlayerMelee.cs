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
    [SerializeField] private PlayerData _playerData;

    private bool _meleeing = false;
    [SerializeField] private float _meleeSpeed = .5f;

    /// <summary>
    /// if something stays in hit box, starts coroutine to melee
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<EnemeyHealthScript>() != null)
        {
            EnemeyHealthScript enemyHealth = other.GetComponent<EnemeyHealthScript>();
            if (enemyHealth.isMeleeable && !_meleeing && IsMovingTwoards(enemyHealth))
            {
                enemyHealth.Damage(_playerData.currentMeleeStrength);
                StartCoroutine(Melee());
            }
        }
    }

    /// <summary>
    /// checks if the player (melee hitbox) is going twoards the player
    /// </summary>
    /// <param name="enemy">enemy being checked</param>
    /// <returns>is moving twoards enemy</returns>
    private bool IsMovingTwoards(EnemeyHealthScript enemy)
    {
        bool isMovingTwoards = true;
        if (transform.position.x >= enemy.transform.position.x + .4f && _playerController.horMovement >= 0)
        {
            isMovingTwoards = false;
        }
        if (transform.position.x <= enemy.transform.position.x - .4f && _playerController.horMovement <= 0)
        {
            isMovingTwoards = false;
        }
        if (transform.position.y >= enemy.transform.position.y + .4f && _playerController.virMovement >= 0)
        {
            isMovingTwoards = false;
        }
        if (transform.position.y <= enemy.transform.position.y - .4f && _playerController.virMovement <= 0)
        {
            isMovingTwoards = false;
        }

        return isMovingTwoards;
    }

    private IEnumerator Melee()
    {
        _meleeing = true;
        yield return new WaitForSeconds(_meleeSpeed);
        _meleeing = false;
    }
}
