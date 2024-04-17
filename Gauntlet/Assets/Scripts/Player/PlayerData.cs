using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/11/2024]
 * [Script for players current stats]
 */

public class PlayerData : MonoBehaviour, ICharacterElement
{
    [SerializeField] private ClassStats _startingStats;
    private int _currentHp;
    private float _currentMovementSpeed;
    private int _currentDefence;
    private int _currentShotStrength;
    private int _currentShotSpeed;
    private int _currentMeleeStrength;
    private int _currentMagicStrength;

    /// <summary>
    /// on enabled, set the stats
    /// </summary>
    private void OnEnable()
    {
        _currentHp = _startingStats.hp;
        _currentMovementSpeed = _startingStats.movementSpeed;
        _currentDefence = _startingStats.defence;
        _currentShotStrength = _startingStats.shotStrength;
        _currentShotSpeed = _startingStats.shotSpeed;
        _currentMeleeStrength = _startingStats.meleeStrength;
        _currentMagicStrength = _startingStats.magicStrength;
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
