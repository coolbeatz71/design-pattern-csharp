namespace DesignPatterns.Behavioral.TemplateMethod.BadExample;

/// <summary>
/// Represents a beverage preparation process specific to coffee.
/// </summary>
/// <remarks>
/// This implementation contains duplicated logic shared with similar classes like <see cref="Tea"/>.
/// While each beverage has its own unique brewing and condiments logic,
/// the shared steps such as boiling water and pouring into cup are repeated.
///
/// <para>
/// This design violates the principle of code reuse and separation of concerns.
/// If the general preparation process changes (e.g., how water is boiled), it must be updated in multiple places,
/// increasing the risk of inconsistencies and bugs.
/// </para>
///
/// <para>
/// <b>Suggested Improvement:</b> Extract the shared steps into a reusable base class, and delegate specific behaviors
/// (like brewing and adding condiments) to subclasses. This promotes reusability, consistency, and cleaner code.
/// </para>
/// </remarks>
public class Coffee
{
    /// <summary>
    /// Executes the entire beverage preparation process for coffee.
    /// </summary>
    /// <example>
    /// <code>
    /// var coffee = new Coffee();
    /// coffee.MakeBeverage();
    /// </code>
    /// </example>
    public void MakeBeverage()
    {
        BoilWater();
        PourWaterIntoCup();
        Brew();
        AddCondiments();
    }
    
    /// <summary>
    /// Simulates boiling water.
    /// </summary>
    private void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }
    
    /// <summary>
    /// Simulates pouring hot water into a cup.
    /// </summary>
    private void PourWaterIntoCup()
    {
        Console.WriteLine("Pouring water into cup");
    }
    
    /// <summary>
    /// Simulates brewing coffee.
    /// </summary>
    private void Brew()
    {
        Console.WriteLine("Brewing coffee for 5 minutes");
    }
    
    /// <summary>
    /// Adds condiments to the coffee if the user desires.
    /// </summary>
    private void AddCondiments()
    {
        if (CustomerWantsCondiments())
        {
            Console.WriteLine("Adding cream to coffee");
        }
    }
    
    /// <summary>
    /// Prompts the user for input to determine if condiments should be added.
    /// </summary>
    /// <returns>True if the user wants cream, false otherwise.</returns>
    private bool CustomerWantsCondiments()
    {
        Console.WriteLine("Would you like cream with your coffee? (y/n)");
        var input = Console.ReadLine();
        return input?.ToLower() == "y";
    }
}