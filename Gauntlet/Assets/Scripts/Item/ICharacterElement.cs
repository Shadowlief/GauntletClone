/*
 * Author: [Lam, Justin]
 * Last Updated: [04/11/2024]
 * [Interface for each element of a Character]
 */

public interface ICharacterElement
{
    void Accept(IItemVisitor visitor);
}
