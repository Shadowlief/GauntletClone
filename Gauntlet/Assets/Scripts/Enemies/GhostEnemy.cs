using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        enemyAttkStr = 10 * enemyLvl;
        enemyShotStr = 0;
        pointsOnDefeat = 10 * enemyLvl;
    }

    protected override void Attack(GameObject player)
    {
        //player.GetComponent(PlayerController).DamageMe(enemyAttkStr);
        Destroy(this.gameObject);
    }
}
