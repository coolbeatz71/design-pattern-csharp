namespace DesignPatterns.Behavioral.TemplateMethod.BadExample;

/// <summary>
/// Represents a beverage preparation process specific to tea.
/// </summary>
/// <remarks>
/// This class shares nearly identical structure with <see cref="Coffee"/>,
/// duplicating several methods like boiling water and pouring into a cup.
///
/// <para>
/// Such duplication makes the code harder to maintain and violates the DRY (Don't Repeat Yourself) principle.
/// The common preparation steps should be extracted into a common reusable structure, allowing subclasses
/// to override only the unique steps.
/// </para>
/// </remarks>

public class Tea
{
    /// <summary>
    /// Executes the entire beverage preparation process for tea.
    /// </summary>
    /// <example>
    /// <code>
    /// var tea = new Tea();
    /// tea.MakeBeverage();
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
    /// Simulates brewing tea.
    /// </summary>
    private void Brew()
    {
        Console.WriteLine("Brewing tea for 3 minutes");
    }
    
    /// <summary>
    /// Adds condiments to the tea if the user desires.
    /// </summary>
    private void AddCondiments()
    {
        if (CustomerWantsCondiments())
        {
            Console.WriteLine("Adding lemon to tea");
        }
    }
    
    /// <summary>
    /// Prompts the user for input to determine if condiments should be added.
    /// </summary>
    /// <returns>True if the user wants lemon, false otherwise.</returns>
    private bool CustomerWantsCondiments()
    {
        Console.WriteLine("Would you like lemon with your tea? (y/n)");
        var input = Console.ReadLine();
        return input?.ToLower() == "y";
    }
}