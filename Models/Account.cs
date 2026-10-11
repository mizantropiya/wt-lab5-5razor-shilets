namespace WtLab5Banking.Razor.Models;

public class Account : BaseEntity
{
    private readonly string _securityCode;

    public string AccountNumber { get; set; }
    public string OwnerName { get; set; }
    public string Currency { get; set; }
    public string? Nickname { get; set; }
    public decimal Balance { get; private set; }

    protected decimal DailyLimit { get; set; }

    public virtual string AccountType => "Обычный счёт";

    public Account(
        int id,
        string accountNumber,
        string ownerName,
        string currency,
        decimal initialBalance,
        string securityCode = "0000")
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Номер счёта не может быть пустым.", nameof(accountNumber));

        if (string.IsNullOrWhiteSpace(ownerName))
            throw new ArgumentException("Имя владельца не может быть пустым.", nameof(ownerName));

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Валюта не может быть пустой.", nameof(currency));

        if (initialBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Баланс не может быть отрицательным.");

        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Currency = currency.ToUpperInvariant();
        Balance = initialBalance;
        _securityCode = securityCode;
        DailyLimit = 5_000m;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Сумма пополнения должна быть больше нуля.");

        ApplyBalanceChange(amount);
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance || amount > DailyLimit)
            return false;

        ApplyBalanceChange(-amount);
        return true;
    }

    public void SetBalance(decimal newBalance)
    {
        if (newBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(newBalance), "Баланс не может быть отрицательным.");

        Balance = newBalance;
    }

    protected void ApplyBalanceChange(decimal delta)
    {
        Balance += delta;
    }

    protected string GetProtectedInfo()
    {
        return $"Дневной лимит: {DailyLimit:F2} {Currency}; PIN: {new string('*', _securityCode.Length)}";
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[{Id}] {AccountType}: {AccountNumber}, {OwnerName}, {Balance:F2} {Currency}");
    }
}
