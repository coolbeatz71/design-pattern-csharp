namespace DesignPatterns.Behavioral.Command.RemoteControl.BadExample;

/// <summary>
/// Represents a remote control tightly coupled to a specific light implementation.
/// </summary>
/// <param name="light">The light device this remote will control.</param>
/// <remarks>
/// <para>
/// <b>Design Flaws in This Implementation:</b>
/// </para>
///
/// <para>
/// <b>1. Violation of the Open/Closed Principle</b><br/>
/// The remote control must be modified every time a new light behavior is added (e.g., blinking, color changing).
/// This makes the class closed to extension and increases the risk of introducing bugs.
/// </para>
///
/// <para>
/// <b>2. Tight Coupling and Encapsulation Breach</b><br/>
/// The remote directly calls concrete methods on the <c>Light</c> class. This means it knows too much about how the light works,
/// leading to tight coupling and breaking encapsulation. Any change in the <c>Light</c> class could force changes here.
/// </para>
///
/// <para>
/// <b>3. Lack of Extensibility and Reusability</b><br/>
/// The current implementation works only with lights. Adding support for new devices like a fan or TV
/// would require rewriting this class or duplicating similar logic elsewhere.
/// </para>
///
/// <para>
/// <b>4. No Support for Action History or Undo</b><br/>
/// Actions are invoked immediately and directly. This design does not allow for queuing, logging, tracking,
/// or undoing operations — all of which are important in interactive systems like remote controls or UIs.
/// </para>
///
/// <para>
/// A better approach would decouple the remote from specific device logic, enabling dynamic assignment of behavior
/// and supporting future features like command history or multi-device control.
/// </para>
/// </remarks>
public class RemoteControl(Light light)
{
    /// <summary>
    /// Simulates pressing a button to turn the light on or off.
    /// </summary>
    /// <param name="turnOn">True to turn on the light, false to turn it off.</param>
    /// <example>
    /// <code>
    /// var light = new Light();
    /// var remote = new RemoteControl(light);
    /// remote.PressButton(true); // Turns on
    /// remote.PressButton(false); // Turns off
    /// </code>
    /// </example>
    public void PressButton(bool turnOn)
    {
        if (turnOn) light.TurnOn();
        else light.TurnOff();
    }

    /// <summary>
    /// Dims the light using a dedicated button.
    /// </summary>
    public void DimLight()
    {
        light.Dim();
    }
}