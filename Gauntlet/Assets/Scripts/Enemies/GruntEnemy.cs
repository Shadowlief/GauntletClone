using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        if (enemyLvl == 3)
            enemyAttkStr = 10;
        else if (enemyLvl == 2)
            enemyAttkStr = 8;
        else
            enemyAttkStr = 5;
        enemyShotStr = 0;
        pointsOnDefeat = 5 * enemyLvl;
    }
    protected override void Attack(GameObject player)
    {
        //player.GetComponent(PlayerController).DamageMe(enemyAttkStr);
    }
}
