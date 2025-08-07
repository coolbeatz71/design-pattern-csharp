using DesignPatterns.Behavioral.Command.TextEditor;
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
using DesignPatterns.Behavioral.TemplateMethod.GoodExample.InheritanceSolution;
using DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution;
using DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Contracts;

using CoffeeIn = DesignPatterns.Behavioral.TemplateMethod.GoodExample.InheritanceSolution.Coffee;
using TeaIn = DesignPatterns.Behavioral.TemplateMethod.GoodExample.InheritanceSolution.Tea;

using CoffeePoly = DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Coffee;
using TeaPoly = DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Tea;

namespace DesignPatterns;

public static class Program
{
    public static void Main()
    {
        RunMementoPatternDemo();
        RunStatePatternDemo();
        RunStrategyPatternDemo();
        RunIteratorPatternDemo();
        RunCommandPatternDemo();
        RunTemplateMethodPatternDemo();
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

    private static void RunIteratorPatternDemo()
    {
        Console.WriteLine("--- ShoppingCart Iteration Demo ---");
        
        // Shopping Cart
        var cart = new ShoppingCart();
        cart.AddItem("Apple");
        cart.AddItem("Banana");
        cart.AddItem("Pineapple");
        cart.AddItem("Mango");
        cart.RemoveItem("Pineapple");
        PrintItems(cart.CreateIterator());

        // Product Shelf
        var shelf = new ProductShelf(["Shampoo", "Soap", "Lotion"]);
        PrintItems(shelf.CreateIterator());

        // Product Catalog
        var catalog = new ProductCatalog();
        catalog.Add("A123", "MacBook Pro");
        catalog.Add("B456", "Dell XPS 13");
        PrintCatalog(catalog.CreateIterator());
    }
    
    private static void PrintItems(IIterator<string> iterator)
    {
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Current());
            iterator.Next();
        }
        Console.WriteLine();
    }

    private static void PrintCatalog(IIterator<KeyValuePair<string, string>> iterator)
    {
        while (iterator.HasNext())
        {
            var entry = iterator.Current();
            Console.WriteLine($"SKU: {entry.Key}, Name: {entry.Value}");
            iterator.Next();
        }
    }

    private static void RunCommandPatternDemo()
    {
        BasicCommandUsage();
        AdvancedCommandUsage();
    }
    
    public static void BasicCommandUsage()
    {
        Console.WriteLine("=== Command Pattern Text Editor Example ===\n");

        var textEditor = new TextEditor();
        var editorControl = new EditorControl();

        Console.WriteLine("Initial content: '" + textEditor.GetContent() + "'\n");

        // Create and execute commands
        var insertHello = new InsertTextCommand(textEditor, "Hello", 0);
        var insertWorld = new InsertTextCommand(textEditor, " World", 5);
        var insertExclamation = new InsertTextCommand(textEditor, "!", 11);

        Console.WriteLine("Executing insert commands...");
        editorControl.ExecuteCommand(insertHello);
        editorControl.ExecuteCommand(insertWorld);
        editorControl.ExecuteCommand(insertExclamation);
        
        Console.WriteLine($"Content after inserts: '{textEditor.GetContent()}'\n");

        // Demonstrate delete command
        var deleteCommand = new DeleteTextCommand(textEditor, 5, 6); // Delete " World"
        Console.WriteLine("Executing delete command...");
        editorControl.ExecuteCommand(deleteCommand);
        Console.WriteLine($"Content after delete: '{textEditor.GetContent()}'\n");

        // Demonstrate undo functionality
        Console.WriteLine("Performing undo operations...");
        editorControl.Undo(); // Undo delete
        Console.WriteLine($"After first undo: '{textEditor.GetContent()}'");
        
        editorControl.Undo(); // Undo insert "!"
        Console.WriteLine($"After second undo: '{textEditor.GetContent()}'");

        // Demonstrate redo functionality
        Console.WriteLine("\nPerforming redo operations...");
        editorControl.Redo(); // Redo insert "!"
        Console.WriteLine($"After first redo: '{textEditor.GetContent()}'");
        
        editorControl.Redo(); // Redo delete " World"
        Console.WriteLine($"After second redo: '{textEditor.GetContent()}'");
    }
    
    public static void AdvancedCommandUsage()
    {
        Console.WriteLine("\n=== Advanced Command Pattern Usage ===\n");

        var textEditor = new TextEditor();
        var editorControl = new EditorControl();

        // Create a list of commands to simulate a macro
        var macroCommands = new List<ICommand>
        {
            new InsertTextCommand(textEditor, "The ", 0),
            new InsertTextCommand(textEditor, "Command ", 4),
            new InsertTextCommand(textEditor, "Pattern ", 12),
            new InsertTextCommand(textEditor, "is ", 20),
            new InsertTextCommand(textEditor, "powerful!", 23)
        };

        Console.WriteLine("Executing macro (multiple commands)...");
        foreach (var command in macroCommands)
        {
            editorControl.ExecuteCommand(command);
        }
        
        Console.WriteLine($"Content after macro: '{textEditor.GetContent()}'\n");

        // Demonstrate that each command can be undone individually
        Console.WriteLine("Undoing commands one by one...");
        for (var i = 0; i < 3; i++)
        {
            editorControl.Undo();
            Console.WriteLine($"After undo {i + 1}: '{textEditor.GetContent()}'");
        }
    }

    private static void RunTemplateMethodPatternDemo()
    {
        TemplateMethodInheritance();
        TemplateMethodPolymorphism();
    }

    private static void TemplateMethodInheritance()
    {
        Console.WriteLine("=== Making Coffee ===");
        Beverage coffee = new CoffeeIn();
        coffee.MakeBeverage();
        
        Console.WriteLine("\n=== Making Tea ===");
        Beverage tea = new TeaIn();
        tea.MakeBeverage();
        
        Console.WriteLine("\nBoth beverages follow the same preparation algorithm!");
    }

    private static void TemplateMethodPolymorphism()
    {
        // Array of different beverage strategies
        IBeverage[] strategies = 
        {
            new CoffeePoly(),
            new TeaPoly(),
            new HotChocolate()
        };
        
        Console.WriteLine("=== Polymorphic Beverage Preparation ===");
        
        // Process each beverage using the same template method
        foreach (var strategy in strategies)
        {
            Console.WriteLine($"\n=== Making {strategy.GetType().Name.Replace("Strategy", "")} ===");
            var beverageMaker = new BeverageMaker(strategy);
            beverageMaker.Prepare();
        }
        
        Console.WriteLine("\n=== Runtime Strategy Switching Demo ===");
        var maker = new BeverageMaker(new CoffeePoly());
        maker.Prepare();
        
        // In a real application, you could switch strategies dynamically
        Console.WriteLine("\nSwitching to tea strategy...");
        maker = new BeverageMaker(new TeaPoly());
        maker.Prepare();
        
        Console.WriteLine("\nAll beverages use the same preparation template with different strategies!");
    }
}
