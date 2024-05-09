using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/06/2024]
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

    private bool _upgradedHp = false;
    private bool _upgradedMovementSpeed = false;
    private bool _upgradedDefence = false;
    private bool _upgradedShotStrength = false;
    private bool _upgradedShotSpeed = false;
    private bool _upgradedMeleeStrength = false;
    private bool _upgradedMagicStrength = false;

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

    public bool upgradedHp
    {
        get { return _upgradedHp; }
        set { _upgradedHp = value; }
    }

    public bool upgradedMovementSpeed
    {
        get { return _upgradedMovementSpeed; }
        set { _upgradedMovementSpeed = value; }
    }

    public bool upgradedDefence
    {
        get { return _upgradedDefence; }
        set { _upgradedDefence = value; }
    }

    public bool upgradedShotStrength
    {
        get { return _upgradedShotStrength; }
        set { _upgradedShotStrength = value; }
    }

    public bool upgradedShotSpeed
    {
        get { return _upgradedShotSpeed; }
        set { _upgradedShotSpeed = value; }
    }

    public bool upgradedMeleeStrength
    {
        get { return _upgradedMeleeStrength; }
        set { _upgradedMeleeStrength = value; }
    }

    public bool upgradedMagicStrength
    {
        get { return _upgradedMagicStrength; }
        set { _upgradedMagicStrength = value; }
    }
}
