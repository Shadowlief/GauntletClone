using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/20/2024]
 * [Singleton to manage player]
 */

public class PlayerManager : Singleton<PlayerManager>
{
    private Dictionary<ClassEnum, bool> _availableClasses = new Dictionary<ClassEnum, bool>();

    private void OnEnable()
    {
        foreach (KeyValuePair<ClassEnum, bool> playerClass in _availableClasses)
        {
            _availableClasses[playerClass.Key] = false;
        }
    }
}
