using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Burgess, Lillian]
 * Last Updated: [05/11/2024]
 * [Handle moving from one scene to the next]
 */

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private int _sceneToLoad;
    [SerializeField] private string _nextSceneName;
    private int _playersInHole = 0;
    private List<GameObject> playerYeetus = new List<GameObject>();
    private GameObject hitboxToggle;
    private AsyncOperation sceneAsync;

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
            other.transform.position = Vector3.zero;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            hitboxToggle = other.gameObject.transform.GetChild(0).gameObject;
            hitboxToggle.gameObject.GetComponent<MeshRenderer>().enabled = false;
            hitboxToggle.gameObject.GetComponent<BoxCollider>().enabled = false;
            GameObject grabber = other.gameObject;
            GameObject tgrabber = GameObject.Find("BaseCharacterParent(Clone)");
            playerYeetus.Add(other.gameObject);
            _playersInHole++;
            //check if all the players are in the hole
            if(PlayerManager.Instance.GetPlayerCount() == _playersInHole)
            {
                //make it so that the players are visible + targetable again + resets their posistion in case they ran off to who knows were
                for(int counter = 0; counter < playerYeetus.Count; counter++)
                {
                    playerYeetus[counter].gameObject.GetComponent<BoxCollider>().enabled = true;
                    playerYeetus[counter].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    hitboxToggle = playerYeetus[counter].gameObject.transform.GetChild(0).gameObject;
                    hitboxToggle.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    hitboxToggle.gameObject.GetComponent<BoxCollider>().enabled = true;
                    playerYeetus[counter].transform.position = Vector3.zero;
                }
                SceneManager.LoadScene(_sceneToLoad);
            }
        }
    }

    /*private IEnumerator ScenitusYeeticus()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        for (int counter = 0; counter < playerYeetus.Count; counter++)
        {
            SceneManager.MoveGameObjectToScene(playerYeetus[counter], SceneManager.GetSceneByName(_nextSceneName));
        }
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }*/
}
