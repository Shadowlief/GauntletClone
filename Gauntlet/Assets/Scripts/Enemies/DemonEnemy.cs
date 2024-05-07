using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/25/2024]
 * [Demon Enemy]
 */

public class DemonEnemy : Enemy
{
    protected bool inMeele = false;
    protected bool amShooting = false;
    protected Coroutine shootBuffer;
    [SerializeField] protected GameObject demonProjectile;
    protected float spawnFrom = 2f;
    private float _fireRate = 1f;
    private float _shotSpeed = 3f;
    protected Vector3 spawnLoc;
    protected GameObject yeetus;
    protected void Awake()
    {
        if (enemyLvl == 3)
            enemyAttkStr = 10;
        else if (enemyLvl == 2)
            enemyAttkStr = 8;
        else
            enemyAttkStr = 5;
        enemyShotStr = 10;
        pointsOnDefeat = 5 * enemyLvl;
    }
    protected override void FixedUpdate()
    {
        //move
        base.FixedUpdate();
        //if there is no shooting coroutine
        //start it
        //if we are not shooting
        //shoot
        if (shootBuffer == null && amShooting == false && !inMeele)
        {
            shootBuffer = StartCoroutine(ShootBuffer());
            amShooting = true;
        }
        if (!amShooting && !inMeele)
        {
            shootBuffer = StartCoroutine(ShootBuffer());
            amShooting = true;
        }
    }
    //when the coroutine is ready
    //fire a projectile
    //then say that I can fire again
    protected IEnumerator ShootBuffer()
    {
        yield return new WaitForSeconds(_fireRate);
        Shoot();
        amShooting = false;
    }
    protected void Shoot()
    {
        Debug.Log("FIRE AWAY!!");
        spawnLoc = transform.position + (transform.up * spawnFrom);
        yeetus = Instantiate(demonProjectile, spawnLoc, transform.rotation);
        yeetus.GetComponent<EnemyProjectile>().SetUp(_shotSpeed, enemyShotStr);
        //Future me note: Shots damage enemies, potions, and players
    }
    protected override void Attack(GameObject player)
    {
        //We're in melee
        //so say that I am in melee
        //and stop shooting!!
        inMeele = true;
        StopCoroutine(ShootBuffer());
        player.GetComponent<PlayerHealth>().Damage(enemyAttkStr);
    }
    protected void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inMeele = false;
        }
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
        if (enemyLvl == 2)
            enemyAttkStr = 8;
        else
            enemyAttkStr = 5;
    }
}
