namespace WtLab5Banking.Razor.Models;

public class CreditAccount : Account
{
    public decimal CreditLimit { get; }

    public override string AccountType => "Кредитный";

    public CreditAccount(
        int id,
        string accountNumber,
        string ownerName,
        string currency,
        decimal initialBalance,
        decimal creditLimit)
        : base(id, accountNumber, ownerName, currency, initialBalance)
    {
        CreditLimit = creditLimit;
        DailyLimit = 7_500m;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance + CreditLimit || amount > DailyLimit)
            return false;

        ApplyBalanceChange(-amount);
        return true;
    }
}
