using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/30/2024]
 * [Script for players current stats]
 */

public class PlayerData : MonoBehaviour, ICharacterElement
{
    private int _currentHp;
    private float _currentMovementSpeed;
    private int _currentDefence;
    private int _currentShotStrength;
    private int _currentShotSpeed;
    private int _currentMeleeStrength;
    private int _currentMagicStrength;

    /// <summary>
    /// set the stats
    /// </summary>
    public void SetStats(ClassStats startingStats)
    {
        _currentHp = startingStats.hp;
        _currentMovementSpeed = startingStats.movementSpeed;
        _currentDefence = startingStats.defence;
        _currentShotStrength = startingStats.shotStrength;
        _currentShotSpeed = startingStats.shotSpeed;
        _currentMeleeStrength = startingStats.meleeStrength;
        _currentMagicStrength = startingStats.magicStrength;
    }

    /// <summary>
    /// accepts the visitor to change stats
    /// </summary>
    /// <param name="visitor"></param>
    public void Accept(IItemVisitor visitor)
    {
        visitor.Visit(this);
    }

    //properties
    public int currentHp
    {
        get { return _currentHp; }
        set { _currentHp = value; }
    }

    public float currentMovementSpeed
    {
        get { return _currentMovementSpeed; }
        set { _currentMovementSpeed = value; }
    }

    public int currentDefence
    {
        get { return _currentDefence; }
        set { _currentDefence = value; }
    }

    public int currentShotStrength
    {
        get { return _currentShotStrength; }
        set { _currentShotStrength = value; }
    }

    public int currentShotSpeed
    {
        get { return _currentShotSpeed; }
        set { _currentShotSpeed = value; }
    }

    public int currentMeleeStrength
    {
        get { return _currentMeleeStrength; }
        set { _currentMeleeStrength = value; }
    }

    public int currentMagicStrength
    {
        get { return _currentMagicStrength; }
        set { _currentMagicStrength = value; }
    }
}
