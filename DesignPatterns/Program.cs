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
}
