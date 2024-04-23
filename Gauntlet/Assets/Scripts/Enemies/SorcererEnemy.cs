using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/19/2024]
 * [Sorcerer Enemy]
 */

public class SorcererEnemy : Enemy
{
    protected bool inMeele = false;
    protected bool amShooting = false;
    protected Coroutine shootBuffer;
    protected bool amInvisible = false;
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
        InvisibleToggle();
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
    protected void InvisibleToggle()
    {
        float invisChecker = UnityEngine.Random.Range(0.0f, 4.0f);
        if(invisChecker%2 == 0 && !amInvisible) //probably will make the max be bigger to make it less common for the game to have the sorcerer go invis
        {
            Debug.Log("Invisible Wizard Alert!");
            amInvisible = true;
            //this.GetComponent<MeshRenderer>().Disable();
            StartCoroutine(InvisibleTimer());
        }
    }
    protected IEnumerator InvisibleTimer()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Visibable Wizard Alert");
        //this.GetComponent<MeshRenderer>().Enable;
        amInvisible = true;
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
        if (other.tag == "Player")
        {
            inMeele = false;
        }
        //WHILE INVISIBLE, CANNOT BE THE TARGET OF DAMAGING ATTACKS!!!
    }
}
