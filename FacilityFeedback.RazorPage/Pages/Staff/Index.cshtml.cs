using FacilityFeedback.Data.EnumModels;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using X.PagedList;

namespace FacilityFeedback.RazorPage.Pages.Staff
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

        public async Task<IActionResult> OnGetAsync(int? id, string? action)
        {
            /*var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var TaskProcess = await _service.GetAllNoPaging();
            TaskProcessWithoutPaging = TaskProcess;*/
            //TaskProcessPaging = await TaskProcess.ToPagedListAsync(pageIndex, pageSize);
            HttpContext.Session.SetString("PAGE", "TaskProcessPage");
            var userString = HttpContext.Session.GetString("ACCOUNT");
            var userConvert = JsonConvert.DeserializeObject<Account>(userString);
            if (id != null)
            {
                if (action == "finish")
                {
                    var task = await _service.GetById((int)id);
                    if (task != null)
                    {
                        task.Process = ProcessStatus.Finishing;
                        await _service.Update(task);
                        return RedirectToPage("/Staff/Index");
                    }
                }
                else
                {
                    if (action == "choose")
                    {
                        var task = await _service.GetById((int)id);
                        if (task != null)
                        {
                            task.Process = ProcessStatus.Processing;
                            task.StaffEmail = userConvert.Email;
                            await _service.Update(task);
                            return RedirectToPage("/Staff/Index");
                        }
                    }
                }
            }
            return null;
        }

        public IActionResult OnGetTaskProcessState(string state, int pageIndex)
        {
            return ViewComponent("TaskProcessState", new { state, pageIndex });
        }
    }
}
