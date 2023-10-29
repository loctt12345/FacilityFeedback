using FacilityFeedback.RazorPage.Pages;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
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
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var TaskProcess = await _service.GetAllNoPaging();
            var TaskProcessPaging = await TaskProcess.Where(tp => tp.Process.ToString() == state).ToPagedListAsync(pageIndex, 2);
            return View(TaskProcessPaging);
        }

    }
}
