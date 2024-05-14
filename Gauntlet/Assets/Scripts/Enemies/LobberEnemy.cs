using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: [Burgess, Lillian]
 * Last Updated: [05/02/2024]
 * [Lobber Enemy]
 */
public class LobberEnemy : Enemy
{
    protected bool amShooting = false;
    protected Coroutine shootBuffer;
    [SerializeField] protected GameObject lobberProjectile;
    protected float spawnFrom = 2f;
    private float _fireRate = 1f;
    private float _shotSpeed = 3f;
    protected Vector3 spawnLoc;
    protected GameObject yeetus;
    protected override void Start()
    {
        base.Start();
        enemyShotStr = 3;
        enemyAttkStr = 0;
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
        yield return new WaitForSeconds(_fireRate);
        Shoot();
        amShooting = false;
    }
    protected void Shoot()
    {
        Debug.Log("FIRE AWAY!!");
        spawnLoc = transform.position + (transform.up * spawnFrom);
        yeetus = Instantiate(lobberProjectile, spawnLoc, transform.rotation);
        yeetus.GetComponent<EnemyProjectile>().SetUp(_shotSpeed, enemyShotStr);
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

    /// <summary>
    /// decreace the level of the enemy by 1
    /// and (possibly defensive) stats accordingly
    /// </summary>
    /// <param name="oldLvl"></param>
    protected override void DegradePower(int oldLvl)
    {
        int currLvl = oldLvl--;
        SetEnemyLvl(currLvl);
        Debug.Log("New Level (should be 1): " + GetEnemyLvl());
    }
}
