using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/06/2024]
 * [that holds player score]
 */

public class PlayerScore : MonoBehaviour, ICharacterElement
{
    private int _currentScore;

    /// <summary>
    /// accepts the visitor to change score
    /// </summary>
    /// <param name="visitor"></param>
    public void Accept(IItemVisitor visitor)
    {
        visitor.Visit(this);
    }

    public int currentScore
    {
        get { return _currentScore; }
        set { _currentScore = value; }
    }
}
