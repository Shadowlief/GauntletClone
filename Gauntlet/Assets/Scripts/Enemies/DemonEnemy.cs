using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonEnemy : Enemy
{
    protected bool inMeele = false;
    protected bool amShooting = false;
    protected Coroutine shootBuffer;
    protected override void Awake()
    {
        base.Awake();
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
        yield return new WaitForSeconds(0.5f);
        Shoot();
        amShooting = false;
    }
    protected void Shoot()
    {
        Debug.Log("FIRE AWAY!!");
        //Instantiate(DemonProjectile);
        //Future me note: Shots damage enemies, potions, and players
    }
    protected override void Attack(GameObject player)
    {
        //We're in melee
        //so say that I am in melee
        //and stop shooting!!
        inMeele = true;
        StopCoroutine(ShootBuffer());
        //player.GetComponent(PlayerController).DamageMe(enemyAttkStr);
    }
    protected void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inMeele = false;
        }
    }
}
