using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/06/2024]
 * [handles player's inventory]
 */

public class PlayerInventory : MonoBehaviour, ICharacterElement
{
    private int _maxInventorySize = 12;
    private int _currentInventorySize = 0;
    private int _numOfKeys = 0;
    private int _numOfPotions = 0;

    /// <summary>
    /// accepts the visitor to change score
    /// </summary>
    /// <param name="visitor"></param>
    public void Accept(IItemVisitor visitor)
    {
        visitor.Visit(this);
    }

    public int maxInventroySize
    {
        get { return _maxInventorySize; }
    }

    public int currentInventorySize
    {
        get { return _currentInventorySize; }
        set { _currentInventorySize = value; }
    }

    public int numOfKeys
    {
        get { return _numOfKeys; }
        set { _numOfKeys = value; }
    }
    public int numOfPotions
    {
        get { return _numOfPotions; }
        set { _numOfPotions = value; }
    }
}
