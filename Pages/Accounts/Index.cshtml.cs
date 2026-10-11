using Microsoft.AspNetCore.Mvc.RazorPages;
using WtLab5Banking.Razor.Data;
using WtLab5Banking.Razor.Models;

namespace WtLab5Banking.Razor.Pages.Accounts;

public class IndexModel : PageModel
{
    public IReadOnlyList<Account> Accounts { get; private set; } = Array.Empty<Account>();

    public void OnGet()
    {
        Accounts = AccountStore.Accounts.OrderBy(account => account.Id).ToList();
    }
}
