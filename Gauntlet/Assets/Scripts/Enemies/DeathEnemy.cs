using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [05/07/2024]
 * [Base Enemy]
 */
public class DeathEnemy : Enemy
{
    protected int currentHealthTaken = 0;
    protected int maxHealthTaken = 200;
    protected void Awake()
    {
        enemyAttkStr = 100;
        pointsOnDefeat = 1000;
        //enemyHP = int.MaxValue;
        enemyLvl = 3;
    }
    /// <summary>
    /// Do 10 dmg
    /// if the dmg counter reaches 200 while still attacking the player, destroy self
    /// </summary>
    /// <param name="player"></param>
    protected override void Attack(GameObject player)
    {
        player.GetComponent<PlayerHealth>().Damage(enemyAttkStr);
        currentHealthTaken = currentHealthTaken + enemyAttkStr;
        if(currentHealthTaken == maxHealthTaken)
        {
            Debug.Log("Took 200 health!");
            Destroy(this);
        }
    }

    /// <summary>
    /// This SHOULD NOT HAPPEN FOR DEATH!!
    /// </summary>
    /// <param name="oldLvl"></param>
    protected override void DegradePower(int oldLvl)
    {
        Debug.Log("How the fuck am I here Death does not Degrade in power!");
    }
}
