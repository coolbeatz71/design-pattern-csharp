using DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Iterator.GoodExample;

public class ProductCatalog: IAggregate<KeyValuePair<string, string>>
{
    private readonly Dictionary<string, string> _items = new();

    public void Add(string sku, string name)
    {
        _items[sku] = name;
    }
    
    public IIterator<KeyValuePair<string, string>> CreateIterator()
    {
        throw new NotImplementedException();
    }

    private class ProductCatalogIterator(ProductCatalog catalog) : IIterator<KeyValuePair<string, string>>
    {
        private Dictionary<string, string>.Enumerator _enumerator = catalog._items.GetEnumerator();
        
        public void Next() { /* Already moved in HasNext */ }

        public bool HasNext() => _enumerator.MoveNext();

        public KeyValuePair<string, string> Current() => _enumerator.Current;
    }
}