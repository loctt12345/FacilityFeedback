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
        public TaskProcessStateViewComponent(ITaskProcessService service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync(string state)
        {
            var TaskProcess = await _service.GetAllNoPaging();
            var TaskProcessPaging = await TaskProcess.Where(tp => tp.Process.ToString() == state).ToPagedListAsync(1, 5);
            return View(TaskProcessPaging);
        }

    }
}
