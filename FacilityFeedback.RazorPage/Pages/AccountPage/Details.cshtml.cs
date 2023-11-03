using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FacilityFeedback.RazorPage.Pages.AccountPage
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _service;

        public DetailsModel(IAccountService service)
        {
            _service = service;
        }

        public Account Account { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string email)
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
    }
}
