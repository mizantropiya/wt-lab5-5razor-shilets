using WtLab5Banking.Razor.Models;

namespace WtLab5Banking.Razor.Data;

public static class AccountStore
{
    public static List<Account> Accounts { get; } = new()
    {
        new Account(1, "BY01BANK0001", "Николь кот", "BYN", 2_500m)
        {
            Nickname = "Основной счёт"
        },
        new SavingsAccount(2, "BY01BANK0002", "Анна Бронская", "BYN", 8_200m, 5.5m)
        {
            Nickname = "Накопления"
        },
        new CreditAccount(3, "BY01BANK0003", "Иван Шкред", "BYN", 1_100m, 4_000m)
        {
            Nickname = "Кредитная карта"
        },
        new BusinessAccount(4, "BY01BANK0004", "ОАО мм ОО", "BYN", 21_000m, 35m)
        {
            Nickname = "Расчётный счёт"
        },
        new SavingsAccount(5, "BY01BANK0005", "Дана Сан", "USD", 3_600m, 3.2m)
        {
            Nickname = "На карзину в ЗЯ"
        },
        new CreditAccount(6, "BY01BANK0006", "Николь Кот", "USD", 750m, 2_500m)
        {
            Nickname = "Планируемые расходы"
        },
        new Account(7, "BY01BANK0007", "Нюша", "EUR", 900m)
        {
            Nickname = "Евросчёт"
        }
    };

    public static Account? GetById(int id)
    {
        return Accounts.FirstOrDefault(account => account.Id == id);
    }

    public static Account Add(AccountInputModel input)
    {
        int id = Accounts.Count == 0 ? 1 : Accounts.Max(account => account.Id) + 1;

        var account = new Account(
            id,
            input.AccountNumber.Trim(),
            input.OwnerName.Trim(),
            input.Currency.Trim().ToUpperInvariant(),
            input.Balance)
        {
            Nickname = string.IsNullOrWhiteSpace(input.Nickname) ? null : input.Nickname.Trim()
        };

        Accounts.Add(account);
        return account;
    }

    public static bool Update(int id, AccountInputModel input)
    {
        Account? account = GetById(id);
        if (account is null)
            return false;

        account.AccountNumber = input.AccountNumber.Trim();
        account.OwnerName = input.OwnerName.Trim();
        account.Currency = input.Currency.Trim().ToUpperInvariant();
        account.Nickname = string.IsNullOrWhiteSpace(input.Nickname) ? null : input.Nickname.Trim();
        account.SetBalance(input.Balance);
        return true;
    }

    public static bool Delete(int id)
    {
        Account? account = GetById(id);
        if (account is null)
            return false;

        Accounts.Remove(account);
        return true;
    }
}
