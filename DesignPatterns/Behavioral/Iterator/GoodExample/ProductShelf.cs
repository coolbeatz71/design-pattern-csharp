using DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Iterator.GoodExample;

public class ProductShelf(string[] products) : IAggregate<string>
{
    private readonly string[] _products = products;

    /// <inheritdoc />
    public IIterator<string> CreateIterator()
    {
        return new ProductShelfIterator(this);
    }

    private class ProductShelfIterator(ProductShelf shelf) : IIterator<string>
    {
        private int _index;
        
        public void Next() => _index++;

        public bool HasNext() => _index < shelf._products.Length;

        public string Current() => shelf._products[_index];
    }
}