using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.TaskProcessPage
{
    public class IndexModel : PageModel
    {
        private readonly ITaskProcessService _service;

        public IndexModel(ITaskProcessService service)
        {
            _service = service;
        }

        public IList<TaskProcess> TaskProcess { get; set; } = default!;

        public async Task OnGetAsync()
        {
            TaskProcess = await _service.GetAllNoPaging();
        }
    }
}
