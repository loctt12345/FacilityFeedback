﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using FacilityFeedback.Service.Services;

namespace FacilityFeedback.RazorPage.Pages.RoomPage
{
    public class DeleteModel : PageModel
    {
        private readonly IRoomService _service;
        private readonly IFloorService _serviceFloor;
        private readonly IRoomTypeService _serviceRoomType;
        private readonly IDeviceService _deviceService;
        public DeleteModel(IRoomService service, IFloorService floorService, IRoomTypeService roomTypeService, IDeviceService deviceService)
        {
            _service = service;
            _serviceFloor = floorService;
            _serviceRoomType = roomTypeService;
            _deviceService = deviceService;
        }

        [BindProperty]
      public Room Room { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var room = await _service.GetById(id);

            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                room.Floor = await _serviceFloor.GetById(room.FloorId);
                room.RoomType = await _serviceRoomType.GetById(room.RoomTypeId);
                Room = room;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var devices = await _deviceService.GetAllNoPaging();
            var isExsitedDevice = false;
            if (devices != null)
            {
                isExsitedDevice = devices.Where(x => x.RoomId == id).Any();
            }
            if (!isExsitedDevice)
            {
                await _service.Delete(id);
            }
            else
            {
                var updateDevice = devices?.Where(x => x.RoomId == id).Select(x => x.Room).FirstOrDefault();
                updateDevice.Status = false;
                await _service.Update(updateDevice);
            }

            return RedirectToPage("./Index");
        }
    }
}
