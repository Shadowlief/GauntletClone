using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/07/2024]
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

    public void AddKey()
    {
        if (_currentInventorySize < _maxInventorySize)
        {
            _numOfKeys++;
            _currentInventorySize++;
        }
    }

    public void UseKey()
    {
        if (_currentInventorySize > 0)
        {
            _numOfKeys--;
            _currentInventorySize--;
        }
    }

    public void AddPotion()
    {
        if (_currentInventorySize < _maxInventorySize)
        {
            _numOfPotions++;
            _currentInventorySize++;
        }
    }

    public void UsePotion()
    {
        if (_currentInventorySize > 0)
        {
            _numOfPotions--;
            _currentInventorySize--;
        }
    }

    public int maxInventroySize
    {
        get { return _maxInventorySize; }
    }

    public int currentInventorySize
    {
        get { return _currentInventorySize; }
    }

    public int numOfKeys
    {
        get { return _numOfKeys; }
    }
    public int numOfPotions
    {
        get { return _numOfPotions; }
    }
}
