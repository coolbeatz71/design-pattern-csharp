namespace DesignPatterns.Behavioral.TemplateMethod.GoodExample.PolymorphismSolution.Contracts;

/// <summary>
/// Interface defining the contract for beverage-specific operations.
/// </summary>
/// <remarks>
/// This interface follows the Strategy pattern to encapsulate beverage-specific behavior,
/// allowing the template method to work with different implementations polymorphically.
/// 
/// <para>
/// <b>Benefits of this approach over inheritance:</b>
/// <list type="bullet">
/// <item>Supports composition over inheritance</item>
/// <item>Allows runtime switching of beverage types</item>
/// <item>More flexible for complex scenarios with multiple varying dimensions</item>
/// <item>Easier to unit test individual components</item>
/// </list>
/// </para>
/// </remarks>
public interface IBeverage
{
    /// <summary>
    /// Defines how to brew the specific beverage.
    /// </summary>
    void Brew();
    
    /// <summary>
    /// Defines what condiments to add for this beverage.
    /// </summary>
    void AddCondiments();
    
    /// <summary>
    /// Determines if the customer wants condiments for this specific beverage.
    /// </summary>
    /// <returns>True if condiments should be added, false otherwise.</returns>
    bool CustomerWantsCondiments();
}