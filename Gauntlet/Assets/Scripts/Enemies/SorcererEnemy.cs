using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [05/02/2024]
 * [Sorcerer Enemy]
 */

public class SorcererEnemy : Enemy
{
    protected bool inMeele = false;
    protected bool amShooting = false;
    protected Coroutine shootBuffer;
    protected bool amInvisible = false;
    protected int invisChecker;
    [SerializeField] protected GameObject sorcererProjectile;
    private float _shotSpeed = 3f;
    protected float spawnFrom = 2f;
    protected Vector3 spawnLoc;
    protected GameObject yeetus;
    protected override void Start()
    {
        base.Start();
        if (enemyLvl == 3)
            enemyAttkStr = 10;
        else if (enemyLvl == 2)
            enemyAttkStr = 8;
        else
            enemyAttkStr = 5;
        enemyShotStr = 10;
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
        if(!amInvisible)
        {
            InvisibleToggle();
        }
    }
    //when the coroutine is ready
    //fire a projectile
    //then say that I can fire again
    protected IEnumerator ShootBuffer()
    {
        yield return new WaitForSeconds(1f);
        Shoot();
        amShooting = false;
    }
    protected void Shoot()
    {
        Debug.Log("Magical Spellz!!");
        spawnLoc = transform.position + (transform.up * spawnFrom);
        yeetus = Instantiate(sorcererProjectile, spawnLoc, transform.rotation);
        yeetus.GetComponent<EnemyProjectile>().SetUp(_shotSpeed, enemyShotStr);
    }
    protected void InvisibleToggle()
    {
        invisChecker = UnityEngine.Random.Range(1, 5);
        Debug.Log("Invis Checker: " + invisChecker);
        if(invisChecker%2 == 0 && !amInvisible) //probably will make the max be bigger to make it less common for the game to have the sorcerer go invis
        {
            Debug.Log("Invisible Wizard Alert!");
            amInvisible = true;
            this.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(InvisibleTimer());
        }
    }
    protected IEnumerator InvisibleTimer()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Visibable Wizard Alert");
        this.GetComponent<MeshRenderer>().enabled = true;
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
    /// <summary>
    /// decreace the level of the enemy by 1
    /// and adjust offensive (and possibly defensive) stats accordingly
    /// </summary>
    /// <param name="oldLvl"></param>
    protected override void DegradePower(int oldLvl)
    {
        int currLvl = oldLvl--;
        SetEnemyLvl(currLvl);
        if (enemyLvl == 2)
            enemyAttkStr = 8;
        else
            enemyAttkStr = 5;
    }
}
