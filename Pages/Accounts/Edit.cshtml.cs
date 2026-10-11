using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WtLab5Banking.Razor.Data;
using WtLab5Banking.Razor.Models;

namespace WtLab5Banking.Razor.Pages.Accounts;

public class EditModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public AccountInputModel Input { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        Account? account = AccountStore.GetById(id);
        if (account is null)
            return NotFound();

        Id = id;
        Input = AccountInputModel.FromAccount(account);
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        if (!AccountStore.Update(Id, Input))
            return NotFound();

        TempData["Message"] = $"Счёт #{Id} изменён";
        return RedirectToPage("./Details", new { id = Id });
    }
}
