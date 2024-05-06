/*
 * Author: [Lam, Justin]
 * Last Updated: [05/06/2024]
 * [Interface for each element of a Character]
 */

public interface IItemVisitor
{
    void Visit(PlayerData playerData);
    void Visit(PlayerScore playerScore);
    void Visit(PlayerInventory playerInventory);
}
