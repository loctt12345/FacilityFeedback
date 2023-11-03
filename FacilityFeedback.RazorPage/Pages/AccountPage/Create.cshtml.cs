using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FacilityFeedback.RazorPage.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _service;

        public CreateModel(IAccountService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {
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

            Account.Password = "123";
            Account.Role = "STAFF";
            var result = await _service.Create(Account);

            return RedirectToPage("./Index");
        }
    }
}
