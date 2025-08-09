namespace DesignPatterns.Behavioral.Observer.GoodExample.Contracts;

/// <summary>
/// Defines the contract for subjects that maintain observers.
/// </summary>
/// <remarks>
/// <b>Key responsibilities:</b>
/// <list type="bullet">
///   <item>Maintain a list of observers</item>
///   <item>Provide methods to add and remove observers</item>
///   <item>Notify all observers when state changes</item>
/// </list>
/// <para>
/// Subjects allow observers to attach/detach and notify them of state changes.
/// </para>
/// <para>Usage example:</para>
/// <code>
/// var subject = new DataSource();
/// var observer = new MyObserver();
/// subject.Attach(observer);
/// subject.SetValues(new List&lt;int&gt; { 10, 20, 30 });
/// </code>
/// </remarks>
public interface ISubject
{
    /// <summary>
    /// Registers an observer to receive notifications when the subject's state changes.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Add an observer from the notification list.
    /// </para>
    /// </remarks>
    /// <param name="observer">The observer to register.</param>
    void Subscribe(IObserver observer);

    /// <summary>
    /// Removes an observer from the notification list.
    /// </summary>
    /// <param name="observer">The observer to unregister.</param>
    void Unsubscribe(IObserver observer);

    /// <summary>
    /// Notifies all registered observers that the subject's state has changed.
    /// </summary>
    void NotifyObservers();
}