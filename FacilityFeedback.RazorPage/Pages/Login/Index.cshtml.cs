using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FacilityFeedback.RazorPage.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account {  get; set; }

        public IActionResult OnGet()
        {
            var accountString = HttpContext.Session.GetString("ACCOUNT");
            if (accountString != null)
            {
                var account = JsonConvert.DeserializeObject<Account>(accountString);
                if (account.Role == "ADMIN")
                {
                    return RedirectToPage("/Index");
                }
                if (account.Role == "USER")
                {
                    return RedirectToPage("/User/Index");
                }
                if (account.Role == "STAFF")
                {
                    return RedirectToPage("/Staff/Index");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsyncRegister()
        {
            string email = Account.Email;
            try
            {
                var exsited = await _accountService.GetByEmail(email);
                return RedirectToPage("/Error");
            }
            catch
            {
                Account.Role = "USER";
                await _accountService.Create(Account);
            }
            return RedirectToPage("/Login/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string email = Account.Email;
            string password = Account.Password;
            try
            {
                var account = await _accountService.GetByEmail(email);
                if (account != null)
                {
                    if (account.Password == password)
                    {
                        HttpContext.Session.SetString("ACCOUNT", JsonConvert.SerializeObject(account));
                        if (account.Role == "ADMIN")
                            return RedirectToPage("/Index");
                        else
                            if (account.Role == "USER")
                        {
                            return RedirectToPage("/User/Index");
                        }
                        else
                                if (account.Role == "STAFF")
                        {
                            return RedirectToPage("/Staff/Index");
                        }
                    }
                }
            }
            catch
            {
                ViewData["ErrorMessage"] = "Invalid Email or Password";
                return Page();
            }
            return Page();
        }
    }
}
