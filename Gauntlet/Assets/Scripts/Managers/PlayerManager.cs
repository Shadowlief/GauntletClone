using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/13/2024]
 * [Singleton to manage player]
 */

public class PlayerManager : Singleton<PlayerManager>
{
    private Dictionary<ClassEnum, bool> _availableClasses = new Dictionary<ClassEnum, bool>();
    private List<GameObject> _currentPlayers = new List<GameObject>();

    [SerializeField] private Camera _startCamera;

    /// <summary>
    /// adds all classes to list
    /// </summary>
    private void OnEnable()
    {
        _availableClasses.Add(ClassEnum.Warrior, true);
        _availableClasses.Add(ClassEnum.Elf, true);
        _availableClasses.Add(ClassEnum.Valkarie, true);
        _availableClasses.Add(ClassEnum.Wizard, true);
    }

    /// <summary>
    /// checks if class is available to be selected
    /// </summary>
    /// <param name="check">class being checked</param>
    /// <returns>is class available</returns>
    public bool CheckAvailableClass(ClassEnum check)
    {
        return _availableClasses[check];
    }

    /// <summary>
    /// changes availability of class
    /// </summary>
    /// <param name="claim">class being claimed</param>
    public void ClaimClass(ClassEnum claim)
    {
        _availableClasses[claim] = false;
    }

    /// <summary>
    /// adds player to _current player
    /// </summary>
    /// <param name="player">player being added</param>
    public void AddPlayer(GameObject player)
    {
        _currentPlayers.Add(player);
        DontDestroyOnLoad(player.transform.root.gameObject);
        if (_startCamera.enabled)
        {
            _startCamera.enabled = false;
        }
    }

    /// <summary>
    /// returns the first player that is alive
    /// </summary>
    /// <returns>gameobject of first player alive</returns>
    public GameObject GetFirstAlivePlayer()
    {
        for (int index = 0; index < _currentPlayers.Count; index++)
        {
            if (_currentPlayers[index] != null)
            {
                return _currentPlayers[index];
            }
        }
        return null;
    }

    public int GetPlayerCount()
    {
        return _currentPlayers.Count;
    }
}
