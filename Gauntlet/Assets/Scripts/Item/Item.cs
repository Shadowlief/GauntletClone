using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [05/06/2024]
 * [SO for items]
 */

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp", order = 51)]
public class Item : ScriptableObject, IItemVisitor
{
    //stat upgrades
    [SerializeField] private int _heal;
    [SerializeField] private float _increaseMoveSpeed;
    [SerializeField] private int _increaseDefense;
    [SerializeField] private int _increaseShotStrength;
    [SerializeField] private int _increaseShotSpeed;
    [SerializeField] private int _increaseMeleeStrength;
    [SerializeField] private int _increaseMagicStrength;

    //score
    [SerializeField] private int _increaseScore;

    //inventory items
    [SerializeField] private bool _addKey;
    [SerializeField] private bool _addPotion;

    /// <summary>
    /// when player picks up an item, change the stats
    /// </summary>
    /// <param name="playerData"></param>
    public void Visit(PlayerData playerData)
    {
        if (!playerData.upgradedHp)
        {
            playerData.currentHp += _heal;
            playerData.upgradedHp = true;
        }
        if (!playerData.upgradedMovementSpeed)
        {
            playerData.currentMovementSpeed += _increaseMoveSpeed;
            playerData.upgradedMovementSpeed = true;

        }
        if (!playerData.upgradedDefence)
        {
            playerData.currentDefence += _increaseDefense;
            playerData.upgradedDefence = true;
        }
        if (!playerData.upgradedShotSpeed)
        {
            playerData.currentShotSpeed += _increaseShotSpeed;
            playerData.upgradedShotSpeed = true;
        }
        if (!playerData.upgradedShotStrength)
        {
            playerData.currentShotStrength += _increaseShotStrength;
            playerData.upgradedShotStrength = true;
        }
        if (!playerData.upgradedMeleeStrength)
        {
            playerData.currentMeleeStrength += _increaseMeleeStrength;
            playerData.upgradedMeleeStrength = true;
        }
        if (!playerData.upgradedMagicStrength)
        {
            playerData.currentMagicStrength += _increaseMagicStrength;
            playerData.upgradedMagicStrength = true;
        }
    }

    /// <summary>
    /// when player picks up an item, change the stats
    /// </summary>
    /// <param name="playerData"></param>
    public void Visit(PlayerScore playerScore)
    {
        playerScore.currentScore += _increaseScore;
    }

    /// <summary>
    /// when player picks up an item, adds item to inventroy if not full
    /// </summary>
    /// <param name="playerData"></param>
    public void Visit(PlayerInventory playerInventory)
    {
        if (_addKey)
        {
            playerInventory.AddKey();
        }
        if (_addPotion)
        {
            playerInventory.AddPotion();
        }
    }
}
