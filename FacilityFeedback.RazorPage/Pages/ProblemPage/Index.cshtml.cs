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

namespace FacilityFeedback.RazorPage.Pages.ProblemPage
{
    public class IndexModel : PageModel
    {
        private readonly IProblemService _service;
        private readonly IConfiguration _config;

        public IndexModel(IProblemService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public IPagedList<Problem>? ProblemPaging { get; set; }

        public async Task OnGetAsync(int pageIndex)
        {
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var Problem = await _service.GetAllNoPaging();
            ProblemPaging = await Problem.ToPagedListAsync(pageIndex, pageSize);
        }
    }
}
