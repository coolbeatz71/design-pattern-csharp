using DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Contracts;

namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution;

/// <summary>
/// Tea-specific implementation of the beverage strategy.
/// </summary>
/// <remarks>
/// This class encapsulates all tea-specific behavior, following the same
/// contract as <see cref="Coffee"/> but with tea-specific implementations.
/// </remarks>

public class Tea: IBeverage
{
    /// <summary>
    /// Implements tea-specific brewing behavior.
    /// </summary>
    public void Brew()
    {
        Console.WriteLine("Brewing tea for 3 minutes");
    }

    /// <summary>
    /// Adds lemon to the tea.
    /// </summary>
    public void AddCondiments()
    {
        Console.WriteLine("Adding lemon to tea");
    }

    /// <summary>
    /// Prompts the user for lemon preference.
    /// </summary>
    /// <returns>True if the customer wants lemon, false otherwise.</returns>
    public bool CustomerWantsCondiments()
    {
        Console.WriteLine("Would you like lemon with your tea? (y/n)");
        var input = Console.ReadLine()?.ToLower();
        return input == "y";
    }
}