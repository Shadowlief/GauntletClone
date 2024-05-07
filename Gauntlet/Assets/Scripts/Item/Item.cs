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
        }
        if (!playerData.upgradedMovementSpeed)
        {
            playerData.currentMovementSpeed += _increaseMoveSpeed;
        }
        if (!playerData.upgradedDefence)
        {
            playerData.currentDefence += _increaseDefense;
        }
        if (!playerData.upgradedShotSpeed)
        {
            playerData.currentShotSpeed += _increaseShotSpeed;
        }
        if (!playerData.upgradedShotStrength)
        {
            playerData.currentShotStrength += _increaseShotStrength;
        }
        if (!playerData.upgradedMeleeStrength)
        {
            playerData.currentMeleeStrength += _increaseMeleeStrength;
        }
        if (!playerData.upgradedMagicStrength)
        {
            playerData.currentMagicStrength += _increaseMagicStrength;
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
        if (_addKey && playerInventory.currentInventorySize < playerInventory.maxInventroySize)
        {
            playerInventory.numOfKeys++; 
            playerInventory.currentInventorySize++; 
        }
        if (_addKey && playerInventory.currentInventorySize < playerInventory.maxInventroySize)
        {
            playerInventory.numOfPotions++;
            playerInventory.currentInventorySize++;
        }
    }
}
