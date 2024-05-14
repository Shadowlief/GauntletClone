using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author[s]: [Lam, Justin], [Burgess, Lillian]
 * Last Updated: [04/25/2024]
 * [enemy health]
 */

public class EnemeyHealthScript : MonoBehaviour, BaseHealthScript
{
    [SerializeField] private int _health;
    private int _currentHealth;
    [SerializeField] private bool _isMeleeable = true;
    private GameObject player;
    private PlayerScore playerScore;
    private int enemyPoints;

    private void OnEnable()
    {
        _currentHealth = _health;
        //Debug.Log("Health: " + _currentHealth);
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
    /// <summary>
    /// Actually set the enemy hp
    /// take the enemy level
    /// multiply it by 10 (the base _health)
    /// and set the current health to be _health
    /// </summary>
    /// <param name="enemyLvl"></param>
    public void SetEnemyHpTrue(int enemyLvl)
    {
        _health = _health * enemyLvl;
        _currentHealth = _health;
        Debug.Log("Health: " + _currentHealth);
    }

    public void Damage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);

        if (_currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        //grab the closest player
        //closestPlayer.GetComponent<PlayerData>().PlayerPoints(points);
        //might have the singleton handle this, instead passing in the points and the player that triggered this
        string name = this.gameObject.name;
        AwardPoints(name);
        Destroy(this.gameObject);
    }

    public void AwardPoints(string name)
    {
        Debug.Log("Name: " + name);
        if(name == "TestDeath")
        {
            player = this.gameObject.GetComponent<DeathEnemy>().GetClosestPlayer();
            playerScore = player.GetComponent<PlayerScore>();
            enemyPoints = this.gameObject.GetComponent<DeathEnemy>().GetPoints();
            playerScore.currentScore += enemyPoints;
        }else if (name == "TestDemon(Clone)")
        {
            player = this.gameObject.GetComponent<DemonEnemy>().GetClosestPlayer();
            playerScore = player.GetComponent<PlayerScore>();
            enemyPoints = this.gameObject.GetComponent<DemonEnemy>().GetPoints();
            playerScore.currentScore += enemyPoints;
        }
        else if (name == "TestGhost(Clone)")
        {
            player = this.gameObject.GetComponent<GhostEnemy>().GetClosestPlayer();
            playerScore = player.GetComponent<PlayerScore>();
            enemyPoints = this.gameObject.GetComponent<GhostEnemy>().GetPoints();
            playerScore.currentScore += enemyPoints;
        }
        else if (name == "TestGrunt(Clone)")
        {
            Debug.Log("Points Deploying: " + this.gameObject.GetComponent<GruntEnemy>().GetPoints());
            player = this.gameObject.GetComponent<GruntEnemy>().GetClosestPlayer();
            Debug.Log("Points Deploying: " + player.name);
            playerScore = player.GetComponent<PlayerScore>();
            enemyPoints = this.gameObject.GetComponent<GruntEnemy>().GetPoints();
            playerScore.currentScore = enemyPoints + playerScore.currentScore;
        }
        else if (name == "TestLobber(Clone)")
        {
            player = this.gameObject.GetComponent<LobberEnemy>().GetClosestPlayer();
            playerScore = player.GetComponent<PlayerScore>();
            enemyPoints = this.gameObject.GetComponent<LobberEnemy>().GetPoints();
            playerScore.currentScore += enemyPoints;
        }
        else if (name == "TestSorcerer(Clone)")
        {
            player = this.gameObject.GetComponent<SorcererEnemy>().GetClosestPlayer();
            playerScore = player.GetComponent<PlayerScore>();
            enemyPoints = this.gameObject.GetComponent<SorcererEnemy>().GetPoints();
            playerScore.currentScore += enemyPoints;
        }
        else if(name == "TestThief")
        {
            player = this.gameObject.GetComponent<ThefEnemy>().GetClosestPlayer();
            playerScore = player.GetComponent<PlayerScore>();
            playerScore.currentScore += 100;
        }else if(name == "TestSpawner")
        {
            this.gameObject.SetActive(false);
        }
    }

    public bool isMeleeable
    {
        get { return _isMeleeable; }
    }
}
