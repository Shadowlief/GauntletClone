using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/30/2024]
 * [Singleton to manage player]
 */

public class PlayerManager : Singleton<PlayerManager>
{
    private Dictionary<ClassEnum, bool> _availableClasses = new Dictionary<ClassEnum, bool>();
    private List<GameObject> _currentPlayers = new List<GameObject>();

    private void OnEnable()
    {
        _availableClasses.Add(ClassEnum.Warrior, false);
        _availableClasses.Add(ClassEnum.Elf, false);
        _availableClasses.Add(ClassEnum.Valkarie, false);
        _availableClasses.Add(ClassEnum.Wizard, false);

    }
}
