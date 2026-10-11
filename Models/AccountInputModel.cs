using System.ComponentModel.DataAnnotations;

namespace WtLab5Banking.Razor.Models;

public class AccountInputModel
{
    [Required(ErrorMessage = "Введите номер счёта.")]
    [StringLength(30, ErrorMessage = "Номер счёта слишком длинный.")]
    [Display(Name = "Номер счёта")]
    public string AccountNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите имя владельца.")]
    [StringLength(80, ErrorMessage = "Имя владельца слишком длинное.")]
    [Display(Name = "Владелец")]
    public string OwnerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите валюту.")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Код валюты должен состоять из 3 символов.")]
    [Display(Name = "Валюта")]
    public string Currency { get; set; } = "BYN";

    [Range(typeof(decimal), "0", "1000000000", ErrorMessage = "Баланс не может быть отрицательным.")]
    [Display(Name = "Баланс")]
    public decimal Balance { get; set; }

    [StringLength(50, ErrorMessage = "Название счёта слишком длинное.")]
    [Display(Name = "Название счёта")]
    public string? Nickname { get; set; }

    public static AccountInputModel FromAccount(Account account)
    {
        return new AccountInputModel
        {
            AccountNumber = account.AccountNumber,
            OwnerName = account.OwnerName,
            Currency = account.Currency,
            Balance = account.Balance,
            Nickname = account.Nickname
        };
    }
}
