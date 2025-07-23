namespace OopPrinciples.Encapsulation;

/// <summary>
/// Represents a bank account that uses encapsulation to protect its balance and ensure valid operations.
/// 
/// <para>
/// This class provides controlled access to the account balance through deposit and withdrawal methods.
/// It ensures the balance cannot be modified arbitrarily, enforcing business rules and data integrity.
/// </para>
/// 
/// <para>
/// Example usage:
/// <code>
/// var account = new BankAccount(100);
/// account.Deposit(50);
/// account.Withdraw(30);
/// Console.WriteLine(account.GetBalance()); // 120
/// </code>
/// </para>
/// </summary>
public class BankAccount
{
    /// <summary>
    /// The current account balance. This field is private to enforce encapsulation.
    /// </summary>
    private decimal balance;

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class with an optional initial balance.
    /// </summary>
    /// <param name="initialBalance">The initial amount to deposit into the account. Must be non-negative.</param>
    /// <exception cref="ArgumentException">Thrown if the initial balance is negative.</exception>
    public BankAccount(decimal initialBalance = 0)
    {
        Deposit(initialBalance);
    }

    /// <summary>
    /// Gets the current balance of the account.
    /// </summary>
    /// <returns>The current balance.</returns>
    public decimal GetBalance()
    {
        return balance;
    }

    /// <summary>
    /// Deposits a specified positive amount into the account.
    /// </summary>
    /// <param name="amount">The amount to deposit. Must be greater than zero.</param>
    /// <exception cref="ArgumentException">Thrown when the deposit amount is zero or negative.</exception>
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
        }
        balance += amount;
    }

    /// <summary>
    /// Withdraws a specified amount from the account, if sufficient funds exist.
    /// </summary>
    /// <param name="amount">The amount to withdraw. Must be greater than zero and less than or equal to the balance.</param>
    /// <exception cref="ArgumentException">Thrown when the withdrawal amount is zero or negative.</exception>
    /// <exception cref="InvalidOperationException">Thrown when there are insufficient funds for the withdrawal.</exception>
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
        }

        if (amount > balance)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }
        balance -= amount;
    }
}
