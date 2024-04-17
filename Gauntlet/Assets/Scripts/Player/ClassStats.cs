using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [04/11/2024]
 * [Scriptable Object for class stats]
 */

[CreateAssetMenu(fileName = "ClassStat", menuName = "ClassStat", order = 50)]
public class ClassStats : ScriptableObject
{
    //stats
    [SerializeField] private int _hp;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _defence;
    [SerializeField] private int _shotStrength;
    [SerializeField] private int _shotSpeed;
    [SerializeField] private int _meleeStrength;
    [SerializeField] private int _magicStrength;

    /// <summary>
    /// properties for the stats
    /// </summary>
    public int hp
    {
        get { return _hp; }
    }

    public float movementSpeed
    {
        get { return _movementSpeed; }
    }

    public int defence
    {
        get { return _defence; }
    }

    public int shotStrength
    {
        get { return _shotStrength; }
    }

    public int shotSpeed
    {
        get { return _shotSpeed; }
    }

    public int meleeStrength
    {
        get { return _meleeStrength; }
    }

    public int magicStrength
    {
        get { return _magicStrength; }
    }
}
