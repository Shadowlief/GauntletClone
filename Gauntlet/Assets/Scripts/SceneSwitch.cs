using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [05/09/2024]
 * [Handle moving from one scene to the next]
 */

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private int _sceneToLoad;
    private int _playersInHole = 0;

    /// <summary>
    /// If a player collides with the hole
    /// the player falls into the hole (and is currently out of the way)
    /// If the amount of players that have fallen into the hole is equal to the amount of players
    /// Load the next scene
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player Count: " + PlayerManager.Instance.GetPlayerCount());
            Debug.Log("Down the hole!");
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y -100, other.transform.position.z);
            _playersInHole++;
            if(PlayerManager.Instance.GetPlayerCount() == _playersInHole)
            {
                SceneManager.LoadScene(_sceneToLoad);
            }
        }
    }
}
