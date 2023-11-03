using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace FacilityFeedback.RazorPage.Pages.AccountPage
{
    public class IndexModel : PageModel
    {

        private readonly IAccountService _service;
        private readonly IConfiguration _config;

        public IndexModel(IAccountService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public IPagedList<Account>? AccountPaging { get; set; }

        public async Task OnGetAsync(int pageIndex)
        {
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var account = await _service.GetAllNoPaging();
            var accountList = account.Where(a => a.Role == "STAFF");
            AccountPaging = await accountList.ToPagedListAsync(pageIndex, pageSize);
            HttpContext.Session.SetString("PAGE", "AccountPage");
        }
    }
}
