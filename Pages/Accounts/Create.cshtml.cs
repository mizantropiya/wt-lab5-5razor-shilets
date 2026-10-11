using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WtLab5Banking.Razor.Data;
using WtLab5Banking.Razor.Models;

namespace WtLab5Banking.Razor.Pages.Accounts;

public class CreateModel : PageModel
{
    [BindProperty]
    public AccountInputModel Input { get; set; } = new() { Currency = "BYN" };

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        Account account = AccountStore.Add(Input);
        TempData["Message"] = $"Счёт #{account.Id} создан";
        return RedirectToPage("./Details", new { id = account.Id });
    }
}
