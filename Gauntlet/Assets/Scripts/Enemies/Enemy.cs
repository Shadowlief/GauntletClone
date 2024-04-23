using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [04/19/2024]
 * [Base Enemy]
 */
public abstract class Enemy : MonoBehaviour
{
    protected int enemyLvl = 1; //CHANGE ME!!  Make me equal to my spawner level!
    protected int enemyHP;
    protected int enemyAttkStr;
    protected int enemyShotStr;
    protected int pointsOnDefeat;
    protected Coroutine enemyMovement;
    protected bool amMoving = false;
    //enemy movement speed
    protected float enemySpeed = 15f;
    //TEMP CODE LILY!!!
    //Eventually repurpose into it being the closest player
    [SerializeField] protected GameObject closestPlayer;
    protected Vector3 moveToMe;
    protected GameObject[] closestPlr;

    protected virtual void OnEnable()
    {
        enemyHP = 10 * enemyLvl;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = StartCoroutine(MovementTimer());
        closestPlr = GameObject.FindGameObjectsWithTag("Player");
        closestPlayer = closestPlr[0];
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if(!amMoving)
        {
            amMoving = true;
            enemyMovement = StartCoroutine(MovementTimer());
        }
    }

    protected IEnumerator MovementTimer()
    {
        yield return new WaitForSeconds(0.1f);
        MoveMe();
        amMoving = false;
    }

    /// <summary>
    /// Moves the enemy towards the player
    /// if it runs into a wall, move it towards a hole in the wall
    /// </summary>
    protected virtual void MoveMe()
    {
        //Debug.Log("Moving An Enemy");
        //gameObject player = findPlayer
        //calculate which player is closest
        //PlayerManager.GetClosestPlayer(this.transform.posistion);
        //moveToMe = GameManager.Instance.FindClosestPlayer(this.transform.posistion);
        this.transform.position = Vector3.MoveTowards(this.transform.position, closestPlayer.transform.position, enemySpeed * Time.deltaTime);
        this.transform.up = closestPlayer.transform.position - this.transform.position;
        //if(noPlayer)
        //this.transform.position = this.transform.position + transform.right;
    }

    protected void OnTriggerEnter(Collider other)
    {
        //if it runs into a player, have it attack the player
        //might make this an OnColliderEnter function
        if(other.tag == "Player")
        {
            Attack(other.gameObject);
        }
    }

    protected abstract void Attack(GameObject player);
}
