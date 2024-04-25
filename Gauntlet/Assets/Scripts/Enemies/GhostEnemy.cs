using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/19/2024]
 * [Ghost Enemy]
 */
public class GhostEnemy : Enemy
{
    protected void Awake()
    {
        enemyAttkStr = 10 * enemyLvl;
        enemyShotStr = 0;
        pointsOnDefeat = 10 * enemyLvl;
    }

    protected override void Attack(GameObject player)
    {
        player.GetComponent<PlayerHealth>().Damage(enemyAttkStr);
        Destroy(this.gameObject);
    }

    protected override void DegradePower(int oldLvl)
    {
        int currLvl = oldLvl--;
        SetEnemyLvl(currLvl);
        Debug.Log("New Level (should be 1): " + GetEnemyLvl());
        enemyAttkStr = 10 * enemyLvl;
    }
}
