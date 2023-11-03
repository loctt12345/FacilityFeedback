using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using X.PagedList;
using FacilityFeedback.Service.IServices;
using System.ComponentModel;

namespace FacilityFeedback.RazorPage.Pages.RoomPage
{
    public class IndexModel : PageModel
    {
        private readonly IRoomService _service;
        private readonly IConfiguration _config;


        public IndexModel(IRoomService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public IPagedList<Room>? RoomPaging { get; set; }
        public async Task OnGetAsync(int pageIndex)
        {
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var Room = await _service.GetAllNoPaging();
            RoomPaging = await Room.ToPagedListAsync(pageIndex, pageSize);
            HttpContext.Session.SetString("PAGE", "RoomPage");
        }
    }
}
