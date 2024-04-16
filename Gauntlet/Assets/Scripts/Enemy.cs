using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int enemyHP;
    protected int enemyAttkStr;
    protected int enemyShotStr;
    protected int pointsOnDefeat;
    protected Coroutine enemyMovement;
    protected bool amMoving = false;
    //enemy movement speed
    protected float enemySpeed = 5f;
    //TEMP CODE LILY!!!
    //Eventually repurpose into it being the closest player
    [SerializeField] protected GameObject closestPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = StartCoroutine(MovementTimer());
    }

    // Update is called once per frame
    void FixedUpdate()
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
    protected void MoveMe()
    {
        //Debug.Log("Moving An Enemy");
        //gameObject player = findPlayer
        //calculate which player is closest
        //PlayerManager.GetClosestPlayer(this.transform.posistion);
        //private Transform playerLoc = player.transform.posistion;
        this.transform.position = Vector3.MoveTowards(this.transform.position, closestPlayer.transform.position, enemySpeed * Time.deltaTime);
        this.transform.up = closestPlayer.transform.position - this.transform.position;
        //if(noPlayer)
        //this.transform.position = this.transform.position + transform.right;
    }
}
