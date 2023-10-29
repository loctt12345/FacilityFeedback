using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using X.PagedList;

namespace FacilityFeedback.RazorPage.Pages.TaskProcessPage
{
    public class IndexModel : PageModel
    {
        private readonly ITaskProcessService _service;
        private readonly IConfiguration _config;

        public IndexModel(ITaskProcessService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public IPagedList<TaskProcess>? TaskProcessPaging { get; set; }
        public List<TaskProcess> TaskProcessWithoutPaging { get; set; }

        public async Task OnGetAsync(int pageIndex)
        {
            /*var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var TaskProcess = await _service.GetAllNoPaging();
            TaskProcessWithoutPaging = TaskProcess;*/
            //TaskProcessPaging = await TaskProcess.ToPagedListAsync(pageIndex, pageSize);

        }

        public IActionResult OnGetTaskProcessState(string state, int pageIndex)
        {
            return ViewComponent("TaskProcessState", new { state, pageIndex });
        }
    }
}
