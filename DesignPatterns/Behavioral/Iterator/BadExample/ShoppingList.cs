namespace DesignPatterns.Behavioral.Iterator.BadExample;

/// <summary>
/// A simple shopping list class that allows adding and removing items.
/// </summary>
/// <remarks>
/// This implementation is not ideal and has several design issues:
/// <list type="bullet">
///   <item><description><b>Encapsulation is broken:</b> The internal list is exposed publicly via <see cref="GetList"/>.</description></item>
///   <item><description><b>Data integrity is at risk:</b> External code can directly modify the list, bypassing class logic.</description></item>
///   <item><description><b>Inflexible:</b> The use of a hardcoded <c>List&lt;string&gt;</c> tightly couples the class to one specific data structure.</description></item>
///   <item><description><b>Responsibility is unclear:</b> The class mixes low-level list operations with domain-specific behavior (e.g., popping the last item), without a clear purpose.</description></item>
/// </list>
/// This class would benefit from stronger encapsulation and a clearer abstraction over how data is managed and accessed.
/// </remarks>
public class ShoppingList
{
    private readonly List<string> _list = [];

    /// <summary>
    /// Adds an item to the shopping list.
    /// </summary>
    /// <param name="itemName">The name of the item to add.</param>
    public void Push(string itemName)
    {
        _list.Add(itemName);
    }

    /// <summary>
    /// Removes and returns the last item in the shopping list.
    /// </summary>
    /// <returns>The last item in the list.</returns>
    /// <remarks>
    /// ⚠️ Treats the list like a stack (last in, first out), which may not match expected list behavior.
    /// Also throws an exception if the list is empty.
    /// </remarks>
    public string Pop()
    {
        var last = _list.Last();
        _list.Remove(last);
        return last;
    }

    /// <summary>
    /// Returns the internal list of items.
    /// </summary>
    /// <returns>The internal <see cref="List{T}"/> of items.</returns>
    /// <remarks>
    /// ⚠️ Exposes the internal data structure directly.
    /// This allows outside code to modify the list (e.g., add, remove, clear items),
    /// which breaks encapsulation and can lead to unexpected side effects.
    /// A safer approach would be to return a read-only copy or expose data through controlled methods.
    /// </remarks>
    public List<string> GetList()
    {
        return _list;
    }
}