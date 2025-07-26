namespace OopPrinciples.Encapsulation;

/// <summary>
/// Represents an improved bank account that encapsulates balance operations such as deposit and withdrawal,
/// ensuring the internal state remains valid.
/// </summary>
public class ImprovedBankAccount
{
    /// <summary>
    /// Gets the current account balance. Cannot be set externally.
    /// </summary>
    private decimal Balance { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class with an optional initial balance.
    /// </summary>
    /// <param name="initialBalance">The starting balance, which must be non-negative.</param>
    /// <exception cref="ArgumentException">Thrown when the initial balance is negative.</exception>
    public ImprovedBankAccount(decimal initialBalance = 0)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentException("Initial balance cannot be negative.", nameof(initialBalance));
        }

        Balance = initialBalance;
    }

    /// <summary>
    /// Deposits the specified positive amount into the account.
    /// </summary>
    /// <param name="amount">The amount to deposit. Must be greater than zero.</param>
    /// <exception cref="ArgumentException">Thrown when the amount is zero or negative.</exception>
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
        }

        Balance += amount;
    }

    /// <summary>
    /// Withdraws the specified amount from the account, if sufficient funds exist.
    /// </summary>
    /// <param name="amount">The amount to withdraw. Must be greater than zero and less than or equal to the balance.</param>
    /// <exception cref="ArgumentException">Thrown when the amount is zero or negative.</exception>
    /// <exception cref="InvalidOperationException">Thrown when there are insufficient funds.</exception>
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }

        Balance -= amount;
    }
}
