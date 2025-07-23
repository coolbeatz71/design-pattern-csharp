namespace OopPrinciples.Encapsulation;

/// <summary>
/// A bad example of a bank account class that violates encapsulation.
/// 
/// <para>
/// This class exposes its internal state (<c>balance</c>) as a <b>public</b> field,
/// which allows external code to modify it freely without any validation or business logic.
/// This breaks the principle of encapsulation and can lead to invalid or inconsistent states.
/// </para>
/// 
/// <para>
/// Example of the issue:
/// <code>
/// var account = new BadBankAccount();
/// account.balance = -1000000m; // No validation! This should not be allowed.
/// </code>
/// </para>
/// 
/// <para>
/// Instead, use private fields with public methods or properties to control access
/// and protect the internal state of the object.
/// </para>
/// </summary>
public class BadBankAccount
{
    /// <summary>
    /// Public balance field. This should be private with controlled access.
    /// </summary>
    public decimal balance;
}
