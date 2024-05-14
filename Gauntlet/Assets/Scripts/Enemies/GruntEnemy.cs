using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/25/2024]
 * [Grunt Enemy]
 */

public class GruntEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        if (enemyLvl == 3)
            enemyAttkStr = 10;
        else if (enemyLvl == 2)
            enemyAttkStr = 8;
        else
            enemyAttkStr = 5;
        enemyShotStr = 0;
        pointsOnDefeat = 5 * enemyLvl;
    }
    public GameObject GetClosestPlayer()
    {
        return closestPlayer;
    }
    public int GetPoints()
    {
        return pointsOnDefeat;
    }
    protected override void Attack(GameObject player)
    {
        player.GetComponent<PlayerHealth>().Damage(enemyAttkStr);
    }

    /// <summary>
    /// decreace the level of the enemy by 1
    /// and adjust offensive (and possibly defensive) stats accordingly
    /// </summary>
    /// <param name="oldLvl"></param>
    protected override void DegradePower(int oldLvl)
    {
        int currLvl = oldLvl- 1;
        SetEnemyLvl(currLvl);
        Debug.Log("New Level (should be 1): " + GetEnemyLvl());
        if (enemyLvl == 2)
            enemyAttkStr = 8;
        else
            enemyAttkStr = 5;
    }
}
