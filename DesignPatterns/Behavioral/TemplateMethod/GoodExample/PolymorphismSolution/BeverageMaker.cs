using DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Contracts;

namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution;

/// <summary>
/// Template method implementation using composition and polymorphism.
/// This is the Context class in the Strategy Design Pattern
/// </summary>
/// <param name="beverage">The strategy that defines beverage-specific behavior.</param>
/// <exception cref="ArgumentNullException">Thrown when beverageStrategy is null.</exception>
/// <remarks>
/// This class demonstrates the Template Method pattern using composition instead of inheritance.
/// It delegates beverage-specific behavior to an <see cref="IBeverage"/> implementation,
/// while maintaining the consistent preparation algorithm.
/// 
/// <para>
/// This approach provides more flexibility than pure inheritance, as it allows:
/// <list type="bullet">
/// <item>Runtime switching of beverage strategies</item>
/// <item>Easier composition of different behaviors</item>
/// <item>Better testability through dependency injection</item>
/// </list>
/// </para>
/// </remarks>
public class BeverageMaker(IBeverage beverage)
{
    private readonly IBeverage _beverage = beverage ?? throw new ArgumentNullException(nameof(beverage));

    /// <summary>
    /// Template method that defines the complete beverage preparation algorithm.
    /// </summary>
    /// <remarks>
    /// This method uses the injected strategy to handle beverage-specific steps
    /// while maintaining the consistent overall preparation process.
    /// </remarks>
    /// <example>
    /// <code>
    /// var coffeeMaker = new BeverageMaker(new CoffeeStrategy());
    /// coffeeMaker.Prepare(); // Prepares coffee using the template method
    /// </code>
    /// </example>
    public void Prepare()
    {
        // Common actions for all beverage
        BoilWater();
        PourWaterIntoCup();
        
        // Specific actions by beverage
        _beverage.Brew();
        if(_beverage.CustomerWantsCondiments()) _beverage.AddCondiments();
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
}