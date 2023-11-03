using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FacilityFeedback.RazorPage.Pages.AccountPage
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _service;

        public DeleteModel(IAccountService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet(string email)
        {
            var account = await _service.GetByEmail(email);
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string email)
        {
            await _service.Delete(email);

            return RedirectToPage("./Index");
        }
    }
}
