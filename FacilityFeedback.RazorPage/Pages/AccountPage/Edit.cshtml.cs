using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FacilityFeedback.RazorPage.Pages.AccountPage
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _service;

        public EditModel(IAccountService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet(string email)
        {
            var device = await _service.GetByEmail(email);
            if (device == null)
            {
                return NotFound();
            }
            else
            {
                Account = device;
            }
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Account == null)
            {
                return Page();
            }
            var result = await _service.Update(Account);

            return RedirectToPage("./Index");
        }
    }
}
