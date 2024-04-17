using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/16/2024]
 * [handles all elements from visitor pattern]
 */

public class PlayerVisitorController : MonoBehaviour, ICharacterElement
{
    private List<ICharacterElement> _characterElements = new List<ICharacterElement>();

    //adds all ICharacterElements
    private void Start()
    {
        _characterElements.Add(gameObject.GetComponent<PlayerData>());
    }

    /// <summary>
    /// accepts all needed visitor
    /// </summary>
    /// <param name="visitor"></param>
    public void Accept(IItemVisitor visitor)
    {
        foreach (ICharacterElement element in _characterElements)
        {
            element.Accept(visitor);
        }
    }
}
