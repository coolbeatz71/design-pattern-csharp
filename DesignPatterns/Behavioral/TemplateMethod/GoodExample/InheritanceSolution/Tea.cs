namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.InheritanceSolution;

/// <summary>
/// Concrete implementation of the beverage preparation process for tea.
/// </summary>
/// <remarks>
/// This class extends <see cref="Beverage"/> and provides tea-specific implementations
/// for the abstract methods defined in the base class.
/// 
/// <para>
/// Like the <see cref="Coffee"/> class, this implementation leverages the common preparation
/// algorithm while defining only the tea-specific behavior.
/// </para>
/// </remarks>
public class Tea: Beverage
{
    
    /// <summary>
    /// Implements tea-specific brewing behavior.
    /// </summary>
    protected override void Brew()
    {
        Console.WriteLine("Brewing tea for 3 minutes");
    }

    /// <summary>
    /// Adds lemon to the tea.
    /// </summary>
    protected override void AddSpecificCondiments()
    {
        Console.WriteLine("Adding specific condiments:");
    }

    /// <summary>
    /// Prompts the user for lemon preference.
    /// </summary>
    /// <returns>True if the customer wants lemon, false otherwise.</returns>
    protected override bool CustomerWantsCondiments()
    {
        Console.WriteLine("Would you like lemon with your tea? (y/n)");
        var input = Console.ReadLine()?.ToLower();
        return input == "y";
    }
}