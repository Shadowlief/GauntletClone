using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/25/2024]
 * [Sorcerer Enemy]
 */

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyType;
    [SerializeField] private int spawnLevel;
    private int spawnerHp;
    private int enemyCap;
    private bool amSpawning = false;
    Coroutine spawner;

    public int GetSpawnLvl()
    {
        return spawnLevel;
    }
    public void SetSpawnLvl(int actualLevel)
    {
        spawnLevel = actualLevel;
    }

    private void Start()
    {
        this.GetComponent<EnemeyHealthScript>().SetEnemyHpTrue(spawnLevel);
        spawner = StartCoroutine(SpawnTimer());
    }

    private void FixedUpdate()
    {
        //if I am not spawning, start spawnign
        if (!amSpawning)
        {
            amSpawning = true;
            spawner = StartCoroutine(SpawnTimer());
        }
        //if I'm a lv3 spawner and I loose 1/3 of my hp, decreace my level by 1
        if (spawnLevel == 3 && this.GetComponent<EnemeyHealthScript>().GetCurrentHealth() <= 20)
        {
            spawnLevel--;
            Debug.Log("Spawn Level (should be 2) = " + spawnLevel);
        }
        //if I'm a lv2 spawner and I loose half of my hp, decreace my level by 1
        else if (spawnLevel == 2 && this.GetComponent<EnemeyHealthScript>().GetCurrentHealth() <= 10)
        {
            spawnLevel--;
            Debug.Log("Spawn Level (should be 1)  = " + spawnLevel);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the collider is a shot
        //health = health - shotDamage
        //if the collider is an attack
        //health = health - attack
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(5.0f);
        SpawnEnemy();
        amSpawning = false;
    }
    /// <summary>
    /// Spawns an enemy in a LEGAL posistion
    /// getting a legal posistion: generate a random number from 0 to 3
    /// then assign the enemyloc to be at the child's location
    /// if an enemy would spawn inside a wall, move the enemy 2 units away until it is in a legal posistion
    /// reason why it's two is because the spawner is a 2X2X2 cube
    /// </summary>
    private void SpawnEnemy()
    {
        //Debug.Log("Spawning Enemy!");
        GameObject babyEnemy = Instantiate(enemyType);
        babyEnemy.GetComponent<Enemy>().SetEnemyLvl(spawnLevel);
        babyEnemy.GetComponent<EnemeyHealthScript>().SetEnemyHpTrue(spawnLevel);
        babyEnemy.transform.position = this.transform.position;
        int childNum = UnityEngine.Random.Range(0, 3);
        Vector3 newEnemyLoc = Vector3.up * -2;
        if(childNum == 0) //spawning North
        {
            newEnemyLoc = this.gameObject.transform.GetChild(0).transform.position;
            //Debug.Log("Spawning North");
        }else if(childNum == 1) //spawning East
        {
            newEnemyLoc = this.gameObject.transform.GetChild(1).transform.position;
            //Debug.Log("Spawning East");
        }
        else if(childNum == 2) //spawning South
        {
            newEnemyLoc = this.gameObject.transform.GetChild(2).transform.position;
            //Debug.Log("Spawning South");
        }
        else //spawning West
        {
            newEnemyLoc = this.gameObject.transform.GetChild(3).transform.position;
            //Debug.Log("Spawning West");
        }
        //Debug.Log("New Location: " + newEnemyLoc);
        babyEnemy.transform.position = newEnemyLoc;
        //if(legalPos)
        //find nearest legal spot
        //babyEnemy.transform.posistion = nearestLegalSpot
    }
}
