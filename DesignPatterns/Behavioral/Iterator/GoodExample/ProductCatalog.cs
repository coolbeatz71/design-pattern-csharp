using DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Iterator.GoodExample;

/// <summary>
/// Represents a product catalog that stores products with their SKU and name.
/// Implements the Aggregate pattern to provide iterator-based traversal
/// of the catalog items.
/// </summary>
/// <remarks>
/// This class demonstrates the Iterator pattern with a Dictionary-based collection.
/// Products are stored as key-value pairs where the key is the SKU and
/// the value is the product name.
/// </remarks>
public class ProductCatalog : IAggregate<KeyValuePair<string, string>>
{
    /// <summary>
    /// Internal storage for catalog items using SKU as key and product name as value.
    /// </summary>
    private readonly Dictionary<string, string> _items = new();

    /// <summary>
    /// Adds a product to the catalog or updates an existing product.
    /// </summary>
    /// <param name="sku">The Stock Keeping Unit (SKU) identifier for the product.</param>
    /// <param name="name">The display name of the product.</param>
    /// <remarks>
    /// If a product with the same SKU already exists, its name will be updated.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="sku"/> or <paramref name="name"/> is null.
    /// </exception>
    /// <example>
    /// <code>
    /// var catalog = new ProductCatalog();
    /// catalog.Add("ABC123", "Wireless Mouse");
    /// catalog.Add("XYZ789", "Mechanical Keyboard");
    /// </code>
    /// </example>
    public void Add(string sku, string name)
    {
        ArgumentNullException.ThrowIfNull(sku);
        ArgumentNullException.ThrowIfNull(name);
        _items[sku] = name;
    }

    /// <summary>
    /// Creates an iterator to traverse the catalog items.
    /// </summary>
    /// <returns>
    /// A new <see cref="IIterator{T}"/> instance for traversing
    /// <see cref="KeyValuePair{TKey,TValue}"/> items in the catalog.
    /// </returns>
    /// <remarks>
    /// Each call returns a new iterator positioned at the beginning of the catalog.
    /// The iteration order follows the Dictionary's internal ordering.
    /// </remarks>
    /// <example>
    /// <code>
    /// var catalog = new ProductCatalog();
    /// catalog.Add("ABC123", "Mouse");
    /// var iterator = catalog.CreateIterator();
    /// while (iterator.HasNext())
    /// {
    ///     var item = iterator.Current();
    ///     Console.WriteLine($"SKU: {item.Key}, Name: {item.Value}");
    ///     iterator.Next();
    /// }
    /// </code>
    /// </example>
    public IIterator<KeyValuePair<string, string>> CreateIterator()
    {
        return new ProductCatalogIterator(this);
    }

    /// <summary>
    /// Internal iterator implementation for ProductCatalog.
    /// Provides iteration over Dictionary items using a list-based approach for cleaner semantics.
    /// </summary>
    /// <param name="catalog">The ProductCatalog instance to iterate over.</param>
    /// <remarks>
    /// This private nested class encapsulates the iteration logic and maintains
    /// the iterator state using index-based access to a snapshot of dictionary items.
    /// This approach provides cleaner iterator semantics with proper separation
    /// between HasNext() and Next() operations.
    /// </remarks>
    private class ProductCatalogIterator(ProductCatalog catalog) : IIterator<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Current position in the items list. Initially set to 0.
        /// </summary>
        private int _index;
        
        /// <summary>
        /// Snapshot of dictionary items taken at iterator creation time.
        /// </summary>
        /// <remarks>
        /// Taking a snapshot ensures consistent iteration even if the original
        /// dictionary is modified during iteration, following iterator best practices.
        /// </remarks>
        private readonly List<KeyValuePair<string, string>> _items = [..catalog._items];
        
        /// <summary>
        /// Moves the iterator to the next element in the catalog.
        /// </summary>
        /// <remarks>
        /// Increments the internal index to point to the next catalog item.
        /// Should only be called after verifying <see cref="HasNext"/> returns true.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to move beyond the end of the catalog.
        /// </exception>
        public void Next() 
        {
            if (_index >= _items.Count)
            {
                throw new InvalidOperationException("Cannot move beyond the end of the catalog.");
            }
            _index++;
        }

        /// <summary>
        /// Determines if there are more catalog items to iterate over.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the current index is within the items list bounds;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method performs bounds checking against the catalog's item list length
        /// without advancing the iterator position.
        /// </remarks>
        public bool HasNext() => _index < _items.Count;
        
        /// <summary>
        /// Returns the current catalog item (SKU and product name pair).
        /// </summary>
        /// <returns>The KeyValuePair at the current iterator position.</returns>
        /// <remarks>
        /// Should only be called when <see cref="HasNext"/> returns true
        /// to ensure valid list access.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to access current element when iterator
        /// is positioned beyond the end of the catalog.
        /// </exception>
        public KeyValuePair<string, string> Current()
        {
            if (_index >= _items.Count)
            {
                throw new InvalidOperationException("Iterator is positioned beyond the end of the catalog.");
            }
            return _items[_index];
        }
    }
}
