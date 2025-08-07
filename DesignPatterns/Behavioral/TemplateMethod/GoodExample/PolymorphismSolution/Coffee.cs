using DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Contracts;

namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution;

/// <summary>
/// Coffee-specific implementation of the beverage strategy.
/// </summary>
/// <remarks>
/// This class encapsulates all coffee-specific behavior, making it easy to
/// maintain and test independently of the overall preparation algorithm.
/// </remarks>
public class Coffee: IBeverage
{
    /// <summary>
    /// Implements coffee-specific brewing behavior.
    /// </summary>
    public void Brew()
    {
        Console.WriteLine("Brewing coffee for 5 minutes");
    }

    /// <summary>
    /// Adds cream to the coffee.
    /// </summary>
    public void AddCondiments()
    {
        Console.WriteLine("Adding cream to coffee");
    }

    /// <summary>
    /// Prompts the user for cream preference.
    /// </summary>
    /// <returns>True if the customer wants cream, false otherwise.</returns>
    public bool CustomerWantsCondiments()
    {
        Console.WriteLine("Would you like cream with your coffee? (y/n)");
        var input = Console.ReadLine()?.ToLower();
        return input == "y";
    }
}