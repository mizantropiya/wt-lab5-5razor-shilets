namespace WtLab5Banking.Razor.Models;

public class SavingsAccount : Account
{
    public decimal InterestRate { get; }

    public override string AccountType => "Сберегательный";

    public SavingsAccount(
        int id,
        string accountNumber,
        string ownerName,
        string currency,
        decimal initialBalance,
        decimal interestRate)
        : base(id, accountNumber, ownerName, currency, initialBalance)
    {
        InterestRate = interestRate;
        DailyLimit = 3_000m;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Ставка: {InterestRate:F2}%");
    }
}
