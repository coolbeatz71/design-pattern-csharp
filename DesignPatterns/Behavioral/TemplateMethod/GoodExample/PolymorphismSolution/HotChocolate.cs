using DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Contracts;

namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution;

/// <summary>
/// Hot chocolate strategy demonstrating extensibility.
/// </summary>
/// <remarks>
/// This class shows how easy it is to add new beverage types using the polymorphism approach.
/// No changes to existing code are required - just implement the interface.
/// </remarks>
public class HotChocolate: IBeverage
{
    /// <summary>
    /// Implements hot chocolate-specific brewing behavior.
    /// </summary>
    public void Brew()
    {
        Console.WriteLine("Mixing hot chocolate powder for 2 minutes");
    }
    
    /// <summary>
    /// Adds marshmallows to the hot chocolate.
    /// </summary>
    public void AddCondiments()
    {
        Console.WriteLine("Adding marshmallows to hot chocolate");
    }
    
    /// <summary>
    /// Prompts the user for marshmallow preference.
    /// </summary>
    /// <returns>True if the customer wants marshmallows, false otherwise.</returns>
    public bool CustomerWantsCondiments()
    {
        Console.WriteLine("Would you like marshmallows with your hot chocolate? (y/n)");
        var input = Console.ReadLine()?.ToLower();
        return input == "y";
    }
}