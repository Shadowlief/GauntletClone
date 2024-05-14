using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [05/07/2024]
 * [Base Enemy]
 */
public abstract class Enemy : MonoBehaviour
{
    protected int enemyLvl; 
    protected int enemyHP;
    protected int enemyAttkStr;
    protected int enemyShotStr;
    protected int pointsOnDefeat;
    protected Coroutine enemyMovement;
    protected bool amMoving = false;
    //enemy movement speed
    protected float enemySpeed = 20f;
    //TEMP CODE LILY!!!
    //Eventually repurpose into it being the closest player
    [SerializeField] protected GameObject closestPlayer;
    protected int _playerLayer = 8;
    protected int _playerLayerMask;
    protected Vector3 moveToMe;
    protected GameObject[] closestPlr;
    protected Collider[] players;
    protected int playerCount;
    protected Ray _playerBlocker;
    protected float _playerBlockerStopDistance = .51f;

    public int GetEnemyHP()
    {
        return enemyHP;
    }
    public void SetEnemyHP(int n)
    {
        enemyHP = n;
    }
    public int GetEnemyLvl()
    {
        return enemyLvl;
    }
    public void SetEnemyLvl(int n)
    {
        enemyLvl = n;
    }

    protected virtual void OnEnable()
    {
        //enemyHP = 10 * enemyLvl;
        enemyHP = 10;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyMovement = StartCoroutine(MovementTimer());
        _playerLayerMask = (1 << _playerLayer);
        FindClosestPlayer();
        players = new Collider[4];
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if(!amMoving)
        {
            amMoving = true;
            enemyMovement = StartCoroutine(MovementTimer());
        }
        //if I'm a lv3 enemy and I loose 1/3 of my health, decreace my level by 1
        if(enemyLvl == 3 && this.GetComponent<EnemeyHealthScript>().GetCurrentHealth() < 20)
        {
            DegradePower(enemyLvl);
        }
        //if I'm a lv2 enemy and I loose one half of my health, decreace my level by 1
        else if(enemyLvl == 2 && this.GetComponent<EnemeyHealthScript>().GetCurrentHealth() < 10)
        {
            DegradePower(enemyLvl);
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
        FindClosestPlayer();
        if (closestPlayer != null) //if it can detect a player, go to it
        {
            _playerBlocker = new Ray(transform.position, transform.up);
            if (!Physics.Raycast(_playerBlocker, out RaycastHit hit, _playerBlockerStopDistance, _playerLayerMask, QueryTriggerInteraction.Collide)) //if I am not adjacent to the player, move towards it
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, closestPlayer.transform.position, enemySpeed * Time.deltaTime);
                this.transform.up = closestPlayer.transform.position - this.transform.position;
            }
        }else //if I cannot detect a player, move up
        {
            this.transform.position = this.transform.position + Vector3.up;
        }
        //if(noPlayer)
        //this.transform.position = this.transform.position + transform.right;
    }

    /// <summary>
    /// Find the closest player
    /// How it's done:
    /// starting from its own posistion, fire off a OverlapSphere w/a radius of 50, storing all the players into an array
    /// if the amount of players is > 1, calculate the distances between itself and the players
    /// whichever difference is the smallest is the closest player
    /// assign the correct distance
    /// </summary>
    protected virtual void FindClosestPlayer()
    {
        playerCount = Physics.OverlapSphereNonAlloc(this.transform.position, 50, players, _playerLayerMask);  //reason why it's _playerLayerMask is to get the correct info passed in!!)
        if(playerCount > 1)
        {
            closestPlayer = players[0].gameObject;
        }
        else if(playerCount == 1) //why this is an else if instead of an else is to catch the situation of if it doesn't find a player that's within a 50 unit radius
        {
            closestPlayer = players[0].gameObject;
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        //if it runs into a player, have it attack the player
        //might make this an OnColliderEnter function
        if(other.tag == "Player")
        {
            Debug.Log("Attacking The Player!");
            Attack(other.gameObject);
            amMoving = true;
        }
    }

    protected abstract void Attack(GameObject player);
    protected abstract void DegradePower(int oldLvl);
}
