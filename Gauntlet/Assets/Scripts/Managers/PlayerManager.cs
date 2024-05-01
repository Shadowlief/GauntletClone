using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/30/2024]
 * [Singleton to manage player]
 */

public class PlayerManager : Singleton<PlayerManager>
{
    private Dictionary<ClassEnum, bool> _availableClasses = new Dictionary<ClassEnum, bool>();
    //private List<PlayerInput> _currentPlayers = new List<PlayerInput>();

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
}
