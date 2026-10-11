namespace WtLab5Banking.Razor.Models;

public class BusinessAccount : Account
{
    public decimal MonthlyFee { get; }

    public override string AccountType => "Бизнес-счёт";

    public BusinessAccount(
        int id,
        string accountNumber,
        string ownerName,
        string currency,
        decimal initialBalance,
        decimal monthlyFee)
        : base(id, accountNumber, ownerName, currency, initialBalance)
    {
        MonthlyFee = monthlyFee;
        DailyLimit = 20_000m;
    }
}
