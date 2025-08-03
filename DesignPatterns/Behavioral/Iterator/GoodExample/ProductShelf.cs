using DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Iterator.GoodExample;

/// <summary>
/// Represents a shelf containing an array of products.
/// Implements the Aggregate pattern to provide iterator-based traversal
/// of the shelf products using array indexing.
/// </summary>
/// <param name="products">Array of product names to store on the shelf.</param>
/// <remarks>
/// This class demonstrates the Iterator pattern with an array-based collection.
/// It provides sequential access to products without exposing the underlying array structure.
/// </remarks>
/// <exception cref="ArgumentNullException">
/// Thrown when <paramref name="products"/> is null.
/// </exception>
/// <example>
/// <code>
/// string[] products = { "Laptop", "Mouse", "Keyboard" };
/// var shelf = new ProductShelf(products);
/// var iterator = shelf.CreateIterator();
/// while (iterator.HasNext())
/// {
///     Console.WriteLine(iterator.Current());
///     iterator.Next();
/// }
/// </code>
/// </example>
public class ProductShelf(string[] products) : IAggregate<string>
{
    /// <summary>
    /// Internal array storing the product names.
    /// </summary>
    /// <remarks>
    /// The array is stored as a private readonly field to prevent external modification
    /// while allowing iterator access to the elements.
    /// </remarks>
    private readonly string[] _products = products ?? throw new ArgumentNullException(nameof(products));
    
    /// <summary>
    /// Creates an iterator to traverse the products on the shelf.
    /// </summary>
    /// <returns>
    /// A new <see cref="IIterator{T}"/> instance for traversing
    /// string product names on the shelf.
    /// </returns>
    /// <remarks>
    /// Each call returns a new iterator positioned at the beginning of the shelf.
    /// The iteration follows the array order from index 0 to Length-1.
    /// </remarks>
    /// <example>
    /// <code>
    /// var shelf = new ProductShelf(new[] { "Item1", "Item2", "Item3" });
    /// var iterator = shelf.CreateIterator();
    /// 
    /// // Iterate through all products
    /// while (iterator.HasNext())
    /// {
    ///     string product = iterator.Current();
    ///     Console.WriteLine($"Product: {product}");
    ///     iterator.Next();
    /// }
    /// </code>
    /// </example>
    public IIterator<string> CreateIterator()
    {
        return new ProductShelfIterator(this);
    }

    /// <summary>
    /// Internal iterator implementation for ProductShelf.
    /// Provides sequential iteration over the array elements using index-based access.
    /// </summary>
    /// <param name="shelf">The ProductShelf instance to iterate over.</param>
    /// <remarks>
    /// This private nested class maintains the current position in the array
    /// and provides bounds-checked access to elements.
    /// </remarks>
    private class ProductShelfIterator(ProductShelf shelf) : IIterator<string>
    {
        /// <summary>
        /// Current position in the array. Initially set to 0.
        /// </summary>
        private int _index;

        /// <summary>
        /// Moves the iterator to the next element in the shelf.
        /// </summary>
        /// <remarks>
        /// Increments the internal index to point to the next product.
        /// Should only be called after verifying <see cref="HasNext"/> returns true.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to move beyond the end of the shelf.
        /// </exception>
        public void Next() 
        {
            if (_index >= shelf._products.Length)
            {
                throw new InvalidOperationException("Cannot move beyond the end of the shelf.");
            }
            _index++;
        }

        /// <summary>
        /// Determines if there are more products to iterate over.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the current index is within the array bounds;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method performs bounds checking against the shelf's product array length.
        /// </remarks>
        public bool HasNext() => _index < shelf._products.Length;

        /// <summary>
        /// Returns the current product name from the shelf.
        /// </summary>
        /// <returns>The product name at the current iterator position.</returns>
        /// <remarks>
        /// Should only be called when <see cref="HasNext"/> returns true
        /// to ensure valid array access.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to access current element when iterator
        /// is positioned beyond the end of the shelf.
        /// </exception>
        public string Current() 
        {
            if (_index >= shelf._products.Length)
            {
                throw new InvalidOperationException("Iterator is positioned beyond the end of the shelf.");
            }
            return shelf._products[_index];
        }
    }
}
