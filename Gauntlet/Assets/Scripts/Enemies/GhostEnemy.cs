using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/25/2024]
 * [Ghost Enemy]
 */
public class GhostEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        enemyAttkStr = 10 * enemyLvl;
        enemyShotStr = 0;
        pointsOnDefeat = 10 * enemyLvl;
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
        Destroy(this.gameObject);
    }

    /// <summary>
    /// decreace the level of the enemy by 1
    /// and adjust offensive (and possibly defensive) stats accordingly
    /// </summary>
    /// <param name="oldLvl"></param>
    protected override void DegradePower(int oldLvl)
    {
        int currLvl = oldLvl--;
        SetEnemyLvl(currLvl);
        Debug.Log("New Level (should be 1): " + GetEnemyLvl());
        enemyAttkStr = 10 * enemyLvl;
    }
}
