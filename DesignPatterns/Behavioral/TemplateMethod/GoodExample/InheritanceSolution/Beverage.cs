namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.InheritanceSolution;

/// <summary>
/// Abstract base class that defines the template method for beverage preparation.
/// </summary>
/// <remarks>
/// This class implements the Template Method pattern by defining the skeleton of the algorithm
/// in the <see cref="MakeBeverage"/> method, while allowing subclasses to override specific steps.
/// 
/// <para>
/// The template method defines the sequence of operations that are common to all beverages,
/// while delegating the beverage-specific behavior to abstract methods that must be implemented
/// by concrete subclasses.
/// </para>
/// 
/// <para>
/// <b>Benefits:</b>
/// <list type="bullet">
/// <item>Eliminates code duplication by centralizing common behavior</item>
/// <item>Ensures consistent algorithm structure across all beverage types</item>
/// <item>Allows easy extension for new beverage types</item>
/// <item>Follows the Open/Closed Principle (open for extension, closed for modification)</item>
/// </list>
/// </para>
/// </remarks>
public abstract class Beverage
{
    /// <summary>
    /// Template method that defines the complete beverage preparation algorithm.
    /// </summary>
    /// <remarks>
    /// This method is marked as <c>sealed</c> to prevent subclasses from overriding
    /// the algorithm structure, ensuring consistency across all beverage preparations.
    /// </remarks>
    /// <example>
    /// <code>
    /// Beverage coffee = new Coffee();
    /// coffee.MakeBeverage(); // Executes the complete preparation process
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
    /// Simulates boiling water - common step for all beverages.
    /// </summary>
    private void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }
    
    /// <summary>
    /// Simulates pouring hot water into a cup - common step for all beverages.
    /// </summary>
    private void PourWaterIntoCup()
    {
        Console.WriteLine("Pouring water into cup");
    }
    
    /// <summary>
    /// Abstract method for brewing the specific beverage.
    /// Must be implemented by concrete subclasses to define beverage-specific brewing behavior.
    /// </summary>
    protected abstract void Brew();
    
    /// <summary>
    /// Abstract method for adding beverage-specific condiments.
    /// Must be implemented by concrete subclasses to define what condiments to add.
    /// </summary>
    protected abstract void AddSpecificCondiments();
    
    /// <summary>
    /// Abstract method that prompts the user for condiment preference.
    /// Must be implemented by concrete subclasses to define the specific condiment question.
    /// </summary>
    /// <returns>True if the customer wants condiments, false otherwise.</returns>
    protected abstract bool CustomerWantsCondiments();

    /// <summary>
    /// Adds condiments to the beverage if the customer desires.
    /// Uses the hook method <see cref="CustomerWantsCondiments"/> to determine user preference.
    /// </summary>
    private void AddCondiments()
    {
        if (CustomerWantsCondiments())
        {
            AddSpecificCondiments();
        }
    }
}