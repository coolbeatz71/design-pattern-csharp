namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.InheritanceSolution;

/// <summary>
/// Concrete implementation of the beverage preparation process for coffee.
/// </summary>
/// <remarks>
/// This class extends <see cref="Beverage"/> and provides coffee-specific implementations
/// for the abstract methods defined in the base class.
/// 
/// <para>
/// By inheriting from the abstract base class, this implementation automatically gets
/// the complete preparation algorithm while only needing to define the coffee-specific behavior.
/// </para>
/// </remarks>
public class Coffee: Beverage
{
    /// <summary>
    /// Implements coffee-specific brewing behavior.
    /// </summary>
    protected override void Brew()
    {
        Console.WriteLine("Brewing Coffee for 5 minutes");
    }
    
    /// <summary>
    /// Adds cream to the coffee.
    /// </summary>
    protected override void AddSpecificCondiments()
    {
        Console.WriteLine("Adding specific condiments:");
    }
    
    /// <summary>
    /// Prompts the user for cream preference.
    /// </summary>
    /// <returns>True if the customer wants cream, false otherwise.</returns>
    protected override bool CustomerWantsCondiments()
    {
        Console.WriteLine("Would like cream with your coffee? (y/n)");
        var input = Console.ReadLine()?.ToLower();
        return input == "y";
    }
}