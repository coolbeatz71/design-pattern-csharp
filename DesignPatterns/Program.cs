using DesignPatterns.Behavioral.Iterator.GoodExample;
using DesignPatterns.Behavioral.Iterator.GoodExample.Contracts;
using DesignPatterns.Behavioral.Memento.GoodExample;
using DesignPatterns.Behavioral.State.GoodExample;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;
using DesignPatterns.Behavioral.Strategy.GoodExample;
using DesignPatterns.Behavioral.Strategy.GoodExample.Compressor;
using DesignPatterns.Behavioral.Strategy.GoodExample.Contracts;
using DesignPatterns.Behavioral.Strategy.GoodExample.Overlay;

namespace DesignPatterns;

public static class Program
{
    public static void Main()
    {
        RunMementoPatternDemo();
        RunStatePatternDemo();
        RunStrategyPatternDemo();
        RunIteratorPatternDemo();
    }

    private static void RunMementoPatternDemo()
    {
        Console.WriteLine("=== Memento Pattern Demo ===\n");

        var editor = new Editor("Initial title", "Initial content");
        var history = new EditorHistory(editor);

        SaveAndShow(editor, history);

        editor.Edit("Updated title", "Updated content");
        SaveAndShow(editor, history);

        editor.Edit("Another updated title", "Another updated content");
        SaveAndShow(editor, history);

        editor.Edit("New updated title", "New updated content");
        editor.Show();

        UndoAndShow(editor, history);
        history.ShowHistory();
        UndoAndShow(editor, history);

        Console.WriteLine("=== End Memento Demo ===\n");
    }

    private static void SaveAndShow(Editor editor, EditorHistory history)
    {
        history.Save();
        editor.Show();
    }

    private static void UndoAndShow(Editor editor, EditorHistory history)
    {
        history.Undo();
        editor.Show();
    }

    private static void RunStatePatternDemo()
    {
        Console.WriteLine("=== State Pattern Demo ===\n");

        var roleValidator = new RoleValidator();

        RunSuccessfulWorkflow(roleValidator);
        RunRejectionWorkflow(roleValidator);
        RunInvalidTransitions(roleValidator);

        Console.WriteLine("\n=== End State Pattern Demo ===");
    }

    private static void RunSuccessfulWorkflow(RoleValidator roleValidator)
    {
        Console.WriteLine("--- Successful Workflow ---");

        var document = new Document(roleValidator);
        Console.WriteLine($"Initial state: {document.CurrentStateType}");

        var steps = new (string Description, Action Action)[]
        {
            ("Editor submits for review", () => document.SubmitForReview(UserRoles.Editor)),
            ("Moderator publishes document", () => document.Publish(UserRoles.Moderator)),
            ("Admin suspends document", () => document.Suspend(UserRoles.Admin)),
            ("Super Admin republishes document", () => document.Republish(UserRoles.SuperAdmin))
        };

        ExecuteSteps(steps, document);
    }

    private static void RunRejectionWorkflow(RoleValidator roleValidator)
    {
        Console.WriteLine("\n--- Rejection Workflow ---");

        var document = new Document(roleValidator);
        Console.WriteLine("1. New document created: Draft");

        var steps = new (string Description, Action Action)[]
        {
            ("Editor submits for review", () => document.SubmitForReview(UserRoles.Editor)),
            ("Moderator rejects document", () => document.Reject(UserRoles.Moderator))
        };

        ExecuteSteps(steps, document);
    }

    private static void RunInvalidTransitions(RoleValidator roleValidator)
    {
        Console.WriteLine("\n--- Invalid Transitions ---");

        var document = new Document(roleValidator);
        document.SubmitForReview(UserRoles.Editor);
        document.Publish(UserRoles.Moderator);

        var errorSteps = new (string Description, Action Action)[]
        {
            ("Invalid: Published → Review", () => document.SubmitForReview(UserRoles.Editor)),
            ("Unauthorized: Editor tries to suspend", () => document.Suspend(UserRoles.Editor))
        };

        foreach (var (description, action) in errorSteps)
        {
            Console.WriteLine($"\n{description}");
            try
            {
                action();
            }
            catch (InvalidStateTransitionException ex)
            {
                Console.WriteLine($"Invalid transition: {ex.Message}");
            }
            catch (UnauthorizedActionException ex)
            {
                Console.WriteLine($"Unauthorized action: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }

    private static void ExecuteSteps((string Description, Action Action)[] steps, Document document)
    {
        foreach (var (description, action) in steps)
        {
            Console.WriteLine($"\n{description}");
            try
            {
                action();
                Console.WriteLine($"Current state: {document.CurrentStateType}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during '{description}': {ex.Message}");
            }
        }
    }

    private static void RunStrategyPatternDemo()
    {
        // Step 1: Choose your compressor and overlay strategies
        ICompressor compressorStrategy = new Mp4Compressor();
        IOverlay overlayStrategy = new BlurOverlay();

        // Step 2: Inject strategies into the context
        var videoStorage = new VideoStorage(compressorStrategy, overlayStrategy);

        // Step 3: Store video
        const string filePath = "holiday_trip.mp4";
        videoStorage.Store(filePath);

        // Optional: Change strategies at runtime
        Console.WriteLine("\nSwitching strategies...\n");

        videoStorage.SetCompressor(new WebMCompressor());
        videoStorage.SetOverlay(new BlackAndWhiteOverlay());
        videoStorage.Store("meeting_recording.webm");
    }
    
    public static void RunIteratorPatternDemo()
    {
        DemonstrateProductCatalogIteration();
        DemonstrateProductShelfIteration();
        DemonstrateShoppingCartIteration();
        DemonstrateGenericIteration();
    }
    
    private static void DemonstrateProductCatalogIteration()
    {
        Console.WriteLine("--- ProductCatalog Iteration Demo ---");
        
        // Create and populate a product catalog
        var catalog = new ProductCatalog();
        catalog.Add("MOUSE001", "Wireless Gaming Mouse");
        catalog.Add("KEYB002", "Mechanical Keyboard RGB");
        catalog.Add("MON003", "4K Ultra HD Monitor");
        catalog.Add("HDST004", "Noise-Canceling Headset");
        catalog.Add("WEBCAM005", "1080p HD Webcam");

        Console.WriteLine("Products in catalog:");
        
        // Create iterator and traverse the catalog
        var catalogIterator = catalog.CreateIterator();
        var itemCount = 0;
        
        while (catalogIterator.HasNext())
        {
            var product = catalogIterator.Current();
            itemCount++;
            Console.WriteLine($"  {itemCount}. SKU: {product.Key} | Name: {product.Value}");
            catalogIterator.Next();
        }
        
        Console.WriteLine($"Total products in catalog: {itemCount}");
    }
    
    private static void DemonstrateProductShelfIteration()
    {
        Console.WriteLine("--- ProductShelf Iteration Demo ---");
        
        // Create a product shelf with office supplies
        string[] officeSupplies = {
            "Stapler",
            "Paper Clips",
            "Sticky Notes",
            "Highlighters",
            "Notebooks",
            "Pens & Pencils",
            "Scissors",
            "Tape Dispenser"
        };
        
        var shelf = new ProductShelf(officeSupplies);
        Console.WriteLine($"Office supplies shelf (contains {shelf.Count} items):");
        
        // Create iterator and traverse the shelf
        var shelfIterator = shelf.CreateIterator();
        var position = 1;
        
        while (shelfIterator.HasNext())
        {
            var product = shelfIterator.Current();
            Console.WriteLine($"  Position {position}: {product}");
            shelfIterator.Next();
            position++;
        }
    }
    
    private static void DemonstrateShoppingCartIteration()
    {
        Console.WriteLine("--- ShoppingCart Iteration Demo ---");
        
        // Create and populate a shopping cart
        var cart = new ShoppingCart();
        cart.AddItem("Gaming Laptop");
        cart.AddItem("Wireless Mouse");
        cart.AddItem("Mechanical Keyboard");
        cart.AddItem("USB-C Hub");
        cart.AddItem("Laptop Stand");
        cart.AddItem("Blue Light Glasses");
        
        Console.WriteLine($"Shopping cart contents ({cart.Count} items):");
        
        // Create iterator and traverse the cart
        var cartIterator = cart.CreateIterator();
        var itemNumber = 1;
        
        while (cartIterator.HasNext())
        {
            var item = cartIterator.Current();
            Console.WriteLine($"  {itemNumber}. {item}");
            cartIterator.Next();
            itemNumber++;
        }
        
        // Demonstrate cart operations
        Console.WriteLine($"\nRemoving 'USB-C Hub' from cart...");
        var removedItem = cart.RemoveItem("USB-C Hub");
        if (removedItem != null)
        {
            Console.WriteLine($"Successfully removed: {removedItem}");
        }
        
        Console.WriteLine($"Cart now contains {cart.Count} items.");
        
        // Check if cart contains specific item
        Console.WriteLine($"Cart contains 'Gaming Laptop': {cart.Contains("Gaming Laptop")}");
        Console.WriteLine($"Cart contains 'USB-C Hub': {cart.Contains("USB-C Hub")}");
    }

    private static void DemonstrateGenericIteration()
    {
        Console.WriteLine("--- Generic Iteration Demo ---");
        
        // Create different types of collections
        var techCatalog = new ProductCatalog();
        techCatalog.Add("CPU001", "Intel Core i7 Processor");
        techCatalog.Add("GPU002", "NVIDIA RTX 4080 Graphics Card");
        techCatalog.Add("RAM003", "32GB DDR5 Memory");
        
        string[] snackItems = { "Chips", "Cookies", "Nuts", "Granola Bars" };
        var snackShelf = new ProductShelf(snackItems);
        
        var groceryCart = new ShoppingCart();
        groceryCart.AddItem("Milk");
        groceryCart.AddItem("Bread");
        groceryCart.AddItem("Eggs");
        groceryCart.AddItem("Cheese");
        
        // Use generic methods to process different collection types
        Console.WriteLine("Tech Products (using generic method):");
        ProcessCatalogGeneric(techCatalog);
        
        Console.WriteLine("\nSnack Items (using generic method):");
        ProcessShelfGeneric(snackShelf);
        
        Console.WriteLine("\nGrocery Cart (using generic method):");
        ProcessCartGeneric(groceryCart);
    }
    
    private static void ProcessShelfGeneric(ProductShelf shelf)
    {
        var iterator = shelf.CreateIterator();
        while (iterator.HasNext())
        {
            var item = iterator.Current();
            Console.WriteLine($"  → {item}");
            iterator.Next();
        }
    }

    private static void ProcessCatalogGeneric(ProductCatalog catalog)
    {
        var iterator = catalog.CreateIterator();
        while (iterator.HasNext())
        {
            var item = iterator.Current();
            Console.WriteLine($"  → {item.Value} (SKU: {item.Key})");
            iterator.Next();
        }
    }

    private static void ProcessCartGeneric(ShoppingCart cart)
    {
        var iterator = cart.CreateIterator();
        while (iterator.HasNext())
        {
            var item = iterator.Current();
            Console.WriteLine($"  → {item}");
            iterator.Next();
        }
    }
}
