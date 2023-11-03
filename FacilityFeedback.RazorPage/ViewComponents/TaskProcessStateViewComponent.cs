using FacilityFeedback.Data.Models;
using FacilityFeedback.RazorPage.Pages;
using FacilityFeedback.Service.IServices;
using FacilityFeedback.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Linq;
using X.PagedList;

namespace FacilityFeedback.RazorPage.ViewComponents
{
    public class TaskProcessStateViewComponent : ViewComponent
    {
        private readonly ITaskProcessService _service;
        private readonly IAccountService _accountService;
        private readonly IConfiguration _config;
        public TaskProcessStateViewComponent(ITaskProcessService service, IConfiguration config, IAccountService accountService)
        {
            _service = service;
            _config = config;
            _accountService = accountService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string state, int pageIndex)
        {
            var userString = HttpContext.Session.GetString("ACCOUNT");
            var userConvert = JsonConvert.DeserializeObject<Account>(userString);
            var isShowAll = true;
            if (userConvert.Role == "STAFF")
            {
                isShowAll = false;
            }
            
            var account = await _accountService.GetAllNoPaging();
            var sl2 = new SelectList(account.Where(a => a.Role == "STAFF"), "Email", "Email");
            ViewData["Account"] = sl2;

            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var TaskProcess = await _service.GetAllNoPaging();
            var TaskProcessPaging = await TaskProcess.Where(tp => (tp.Process.ToString() == state) 
                                    && (isShowAll || (tp.StaffEmail == userConvert.Email 
                                    || (tp.Process == Data.EnumModels.ProcessStatus.Incoming && tp.StaffEmail == null))))
                                    .ToPagedListAsync(pageIndex, 5);
            ViewBag.state = state;
            return View(TaskProcessPaging);
        }

    }
}
