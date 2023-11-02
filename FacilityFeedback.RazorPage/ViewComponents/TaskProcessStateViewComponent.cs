using FacilityFeedback.Data.Models;
using FacilityFeedback.RazorPage.Pages;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Printing;
using X.PagedList;

namespace FacilityFeedback.RazorPage.ViewComponents
{
    public class TaskProcessStateViewComponent : ViewComponent
    {
        private readonly ITaskProcessService _service;
        private readonly IConfiguration _config;
        public TaskProcessStateViewComponent(ITaskProcessService service, IConfiguration config)
        {
            _service = service;
            _config = config;
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
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var TaskProcess = await _service.GetAllNoPaging();
            var TaskProcessPaging = await TaskProcess.Where(tp => (tp.Process.ToString() == state) && (isShowAll || (tp.StaffEmail == userConvert.Email && (int) tp.Process > 0 ))).ToPagedListAsync(pageIndex, 2);
            ViewBag.state = state;
            return View(TaskProcessPaging);
        }

    }
}
