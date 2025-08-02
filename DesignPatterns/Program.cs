using DesignPatterns.Behavioral.Memento.GoodExample;
using DesignPatterns.Behavioral.State.GoodExample;
using DesignPatterns.Behavioral.State.GoodExample.Enums;
using DesignPatterns.Behavioral.State.GoodExample.Exceptions;

namespace DesignPatterns;

public static class Program
{
    public static void Main()
    {
        RunMementoPatternDemo();
        RunStatePatternDemo();
    }
    
    private static void RunMementoPatternDemo()
    {
        var editor = new Editor("Initial title", "Initial content");
        var history = new EditorHistory(editor);

        history.Save();
        editor.Show();

        editor.Edit("Updated title", "Updated content");
        history.Save();
        editor.Show();

        editor.Edit("Another updated title", "Another updated content");
        history.Save();
        editor.Show();

        editor.Edit("New updated title", "New updated content");
        editor.Show();

        history.Undo();
        editor.Show();

        history.ShowHistory();

        history.Undo();
        editor.Show();
    }

    private static void RunStatePatternDemo()
    {
        Console.WriteLine("=== Document State Pattern Demo ===\n");

        // Create dependencies
        var roleValidator = new RoleValidator();
        var document = new Document(roleValidator);

        // Show initial state
        Console.WriteLine($"Initial state: {document.CurrentStateType}");

        // Complete workflow: Draft → Review → Published → Suspended → Published
        Console.WriteLine("\n--- Complete Workflow ---");
        
        // Step 1: Editor submits for review (Draft → Review)
        Console.WriteLine("1. Editor submits for review");
        document.SubmitForReview(UserRoles.Editor);
        Console.WriteLine($"   State: {document.CurrentStateType}");

        // Step 2: Moderator publishes (Review → Published)
        Console.WriteLine("2. Moderator publishes document");
        document.Publish(UserRoles.Moderator);
        Console.WriteLine($"   State: {document.CurrentStateType}");

        // Step 3: Admin suspends (Published → Suspended)
        Console.WriteLine("3. Admin suspends document");
        document.Suspend(UserRoles.Admin);
        Console.WriteLine($"   State: {document.CurrentStateType}");

        // Step 4: Admin republishes (Suspended → Published)
        Console.WriteLine("4. Admin republishes document");
        document.Republish(UserRoles.Admin);
        Console.WriteLine($"   State: {document.CurrentStateType}");

        // Show rejection workflow
        Console.WriteLine("\n--- Rejection Workflow ---");
        var document2 = new Document(roleValidator);
        
        Console.WriteLine("1. New document created: Draft");
        document2.SubmitForReview(UserRoles.Editor);
        Console.WriteLine("2. Editor submits: Review");
        
        document2.Reject(UserRoles.Moderator);
        Console.WriteLine("3. Moderator rejects: Rejected (terminal state)");

        // Show error handling
        Console.WriteLine("\n--- Error Examples ---");
        
        try
        {
            // Try invalid action
            document.SubmitForReview(UserRoles.Editor); // Published can't go to Review
        }
        catch (InvalidStateTransitionException ex)
        {
            Console.WriteLine($"Invalid transition: {ex.Message}");
        }

        try
        {
            // Try unauthorized action
            document.Suspend(UserRoles.Editor); // Editor can't suspend
        }
        catch (UnauthorizedActionException ex)
        {
            Console.WriteLine($"Unauthorized: {ex.Message}");
        }

        Console.WriteLine("\n=== Demo Complete ===");
    }
}