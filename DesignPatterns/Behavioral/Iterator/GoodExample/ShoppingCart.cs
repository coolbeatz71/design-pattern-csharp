using DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Iterator.GoodExample;

/// <summary>
/// A shopping cart that holds items and supports iteration via a list.
/// </summary>
public class ShoppingCart: IAggregate<string>
{
    private readonly List<string> _items = [];
    
    public void AddItem(string item) => _items.Add(item);

    public string RemoveItem(string item)
    {
        _items.Remove(item);
        return item;   
    }
    
    /// <inheritdoc />
    public IIterator<string> CreateIterator()
    {
        return new ShoppingCartIterator(this);
    }

    private class ShoppingCartIterator(ShoppingCart cart) : IIterator<string>
    {
        private int _index;

        public void Next() => _index++;

        public bool HasNext() => _index < cart._items.Count;

        public string Current() => cart._items[_index];
    }
}