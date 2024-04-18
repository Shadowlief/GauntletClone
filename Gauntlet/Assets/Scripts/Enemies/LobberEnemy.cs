using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberEnemy : Enemy
{
    protected bool amShooting = false;
    protected Coroutine shootBuffer;
    protected override void Awake()
    {
        base.Awake();
        enemyShotStr = 3;
        enemyAttkStr = 0;
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
        if(shootBuffer == null && amShooting == false)
        {
            shootBuffer = StartCoroutine(ShootBuffer());
            amShooting = true;
        }
        if(!amShooting)
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
        //Instantiate(lobberProjectile);
        //Future me note: Shots damage enemies, potions, and players
        //lobber shots also go over walls?
    }
    protected override void Attack(GameObject player)
    {
        //player.GetComponent(PlayerController).DamageMe(enemyAttkStr);
        Retreat();
    }
    
    /// <summary>
    /// back away from the player
    /// </summary>
    protected void Retreat()
    {
        this.transform.up = closestPlayer.transform.position - this.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, closestPlayer.transform.position, (enemySpeed + 20) * -1 * Time.deltaTime);
    }
}
