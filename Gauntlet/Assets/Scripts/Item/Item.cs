using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp", order = 51)]
public class Item : ScriptableObject, IItemVisitor
{
    [SerializeField] private int _heal;
    [SerializeField] private float _increaseMoveSpeed;
    [SerializeField] private int _increaseDefense;
    [SerializeField] private int _increaseShotStrength;
    [SerializeField] private int _increaseShotSpeed;
    [SerializeField] private int _increaseMeleeStrength;
    [SerializeField] private int _increaseMagicStrength;

    /// <summary>
    /// when player picks up an item, change the stats
    /// </summary>
    /// <param name="playerData"></param>
    public void Visit(PlayerData playerData)
    {
        playerData.currentHp += _heal;
        playerData.currentMovementSpeed += _increaseMoveSpeed;
        playerData.currentDefence += _increaseDefense;
        playerData.currentShotSpeed += _increaseShotSpeed;
        playerData.currentShotStrength += _increaseShotStrength;
        playerData.currentMeleeStrength += _increaseMeleeStrength;
        playerData.currentMagicStrength += _increaseMagicStrength;
    }
}
