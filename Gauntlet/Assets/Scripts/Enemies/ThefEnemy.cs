using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Burgess, Lillian]
 * Last Updated: [05/07/2024]
 * [Base Enemy]
 */
public class ThefEnemy : Enemy
{
    protected bool playerUpgraded;
    protected bool attacked;
    protected override void Start()
    {
        base.Start();
        enemyAttkStr = 10;
        enemyShotStr = 0;
        pointsOnDefeat = 10;
    }
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

    }
    protected override void Attack(GameObject player)
    {
        PlayerData playerData = player.GetComponent<PlayerData>();
        player.GetComponent<PlayerHealth>().Damage(enemyAttkStr);
        playerUpgraded = CheckIfUpgraded(playerData);
        if(!playerUpgraded && !attacked)
        {
            PlayerScore points = player.GetComponent<PlayerScore>();
            points.currentScore -= 50;
            attacked = true;
        }

    }
    public GameObject GetClosestPlayer()
    {
        return closestPlayer;
    }
    public int GetPoints()
    {
        return pointsOnDefeat;
    }
    protected override void DegradePower(int oldLvl)
    {
        Debug.Log("Thieves are conniving bastards and don't degrade");
    }
    /// <summary>
    /// Check if the player is upgraded
    /// If yes, they loose an upgrade
    /// If no, resume the attack
    /// </summary>
    /// <param name="playerData"></param>
    /// <returns></returns>
    protected bool CheckIfUpgraded(PlayerData playerData)
    {
        if (!playerData.upgradedMovementSpeed)
        {
            playerData.currentMovementSpeed -= 1;
            playerData.upgradedMovementSpeed = false;
            return true;

        }
        if (!playerData.upgradedDefence)
        {
            playerData.currentDefence -= 1;
            playerData.upgradedDefence = false;
            return true;
        }
        if (!playerData.upgradedShotSpeed)
        {
            playerData.currentShotSpeed -= 1;
            playerData.upgradedShotSpeed = false;
            return true;
        }
        if (!playerData.upgradedShotStrength)
        {
            playerData.currentShotStrength -= 1;
            playerData.upgradedShotStrength = false;
            return true;
        }
        if (!playerData.upgradedMeleeStrength)
        {
            playerData.currentMeleeStrength -= 1;
            playerData.upgradedMeleeStrength = false;
            return true;
        }
        if (!playerData.upgradedMagicStrength)
        {
            playerData.currentMagicStrength -= 1;
            playerData.upgradedMagicStrength = false;
            return true;
        }
        return false;
    }
}
