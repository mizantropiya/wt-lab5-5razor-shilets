using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WtLab5Banking.Razor.Data;
using WtLab5Banking.Razor.Models;

namespace WtLab5Banking.Razor.Pages.Accounts;

public class DeleteModel : PageModel
{
    [BindProperty]
    public int Id { get; set; }

    public Account? Account { get; private set; }

    public IActionResult OnGet(int id)
    {
        Account = AccountStore.GetById(id);
        if (Account is null)
            return NotFound();

        Id = id;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!AccountStore.Delete(Id))
            return NotFound();

        TempData["Message"] = $"Счёт #{Id} удалён";
        return RedirectToPage("./Index");
    }
}
