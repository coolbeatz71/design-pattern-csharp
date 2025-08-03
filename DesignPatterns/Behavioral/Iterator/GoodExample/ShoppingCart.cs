using DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;

namespace DesignPatterns.Behavioral.Iterator.GoodExample;

/// <summary>
/// A shopping cart that holds items and supports iteration via a list.
/// Implements the Aggregate pattern to provide iterator-based traversal
/// of cart items using List-based storage.
/// </summary>
/// <remarks>
/// This class demonstrates the Iterator pattern with a List-based collection
/// that supports dynamic addition and removal of items. The shopping cart
/// maintains items as strings and provides methods for cart management
/// along with iterator functionality.
/// </remarks>
/// <example>
/// <code>
/// var cart = new ShoppingCart();
/// cart.AddItem("Laptop");
/// cart.AddItem("Mouse");
/// cart.AddItem("Keyboard");
/// 
/// var iterator = cart.CreateIterator();
/// while (iterator.HasNext())
/// {
///     Console.WriteLine($"Cart item: {iterator.Current()}");
///     iterator.Next();
/// }
/// </code>
/// </example>
public class ShoppingCart : IAggregate<string>
{
    /// <summary>
    /// Internal list storing the shopping cart items.
    /// </summary>
    /// <remarks>
    /// Using a List provides dynamic sizing and efficient access patterns
    /// for shopping cart operations like adding, removing, and iterating items.
    /// </remarks>
    private readonly List<string> _items = [];
    
    /// <summary>
    /// Adds an item to the shopping cart.
    /// </summary>
    /// <param name="item">The item name to add to the cart.</param>
    /// <remarks>
    /// Items are added to the end of the list, maintaining the order
    /// in which they were added to the cart.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="item"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="item"/> is empty or whitespace.
    /// </exception>
    /// <example>
    /// <code>
    /// var cart = new ShoppingCart();
    /// cart.AddItem("Wireless Headphones");
    /// cart.AddItem("USB Cable");
    /// </code>
    /// </example>
    public void AddItem(string item)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(item);
        _items.Add(item);
    }

    /// <summary>
    /// Removes the first occurrence of an item from the shopping cart.
    /// </summary>
    /// <param name="item">The item name to remove from the cart.</param>
    /// <returns>
    /// The removed item name if found and removed; otherwise, null.
    /// </returns>
    /// <remarks>
    /// This method removes only the first occurrence of the specified item.
    /// If the same item appears multiple times in the cart, only one instance
    /// will be removed per method call.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="item"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="item"/> is empty or whitespace.
    /// </exception>
    /// <example>
    /// <code>
    /// var cart = new ShoppingCart();
    /// cart.AddItem("Phone Case");
    /// cart.AddItem("Screen Protector");
    /// 
    /// string removed = cart.RemoveItem("Phone Case");
    /// if (removed != null)
    /// {
    ///     Console.WriteLine($"Removed: {removed}");
    /// }
    /// </code>
    /// </example>
    public string? RemoveItem(string item)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(item);
        
        var removed = _items.Remove(item);
        return removed ? item : null;
    }

    /// <summary>
    /// Creates an iterator to traverse the items in the shopping cart.
    /// </summary>
    /// <returns>
    /// A new <see cref="IIterator{T}"/> instance for traversing
    /// string item names in the cart.
    /// </returns>
    /// <remarks>
    /// Each call returns a new iterator positioned at the beginning of the cart.
    /// The iteration follows the order in which items were added to the cart.
    /// Items added after iterator creation will not be visible to that iterator instance.
    /// </remarks>
    /// <example>
    /// <code>
    /// var cart = new ShoppingCart();
    /// cart.AddItem("Book");
    /// cart.AddItem("Pen");
    /// 
    /// var iterator = cart.CreateIterator();
    /// int itemNumber = 1;
    /// while (iterator.HasNext())
    /// {
    ///     string item = iterator.Current();
    ///     Console.WriteLine($"{itemNumber}. {item}");
    ///     iterator.Next();
    ///     itemNumber++;
    /// }
    /// </code>
    /// </example>
    public IIterator<string> CreateIterator()
    {
        return new ShoppingCartIterator(this);
    }

    /// <summary>
    /// Internal iterator implementation for ShoppingCart.
    /// Provides iteration over List items using a snapshot approach for consistent traversal.
    /// </summary>
    /// <param name="cart">The ShoppingCart instance to iterate over.</param>
    /// <remarks>
    /// This private nested class maintains the current position in a snapshot
    /// of the cart items, ensuring consistent iteration even if the original
    /// cart is modified during iteration.
    /// </remarks>
    private class ShoppingCartIterator(ShoppingCart cart) : IIterator<string>
    {
        /// <summary>
        /// Current position in the items list. Initially set to 0.
        /// </summary>
        private int _index;
        
        /// <summary>
        /// Snapshot of cart items taken at iterator creation time.
        /// </summary>
        /// <remarks>
        /// Taking a snapshot ensures consistent iteration even if the original
        /// cart is modified during iteration, following iterator best practices.
        /// </remarks>
        private readonly List<string> _items = [..cart._items];

        /// <summary>
        /// Moves the iterator to the next item in the shopping cart.
        /// </summary>
        /// <remarks>
        /// Increments the internal index to point to the next cart item.
        /// Should only be called after verifying <see cref="HasNext"/> returns true.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to move beyond the end of the cart.
        /// </exception>
        public void Next()
        {
            if (_index >= _items.Count)
            {
                throw new InvalidOperationException("Cannot move beyond the end of the shopping cart.");
            }
            _index++;
        }

        /// <summary>
        /// Determines if there are more items to iterate over in the cart.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the current index is within the items list bounds;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method performs bounds checking against the cart's item list length
        /// without advancing the iterator position.
        /// </remarks>
        public bool HasNext() => _index < _items.Count;

        /// <summary>
        /// Returns the current item name from the shopping cart.
        /// </summary>
        /// <returns>The item name at the current iterator position.</returns>
        /// <remarks>
        /// Should only be called when <see cref="HasNext"/> returns true
        /// to ensure valid list access.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to access current element when iterator
        /// is positioned beyond the end of the cart.
        /// </exception>
        public string Current()
        {
            if (_index >= _items.Count)
            {
                throw new InvalidOperationException("Iterator is positioned beyond the end of the shopping cart.");
            }
            return _items[_index];
        }
    }
}