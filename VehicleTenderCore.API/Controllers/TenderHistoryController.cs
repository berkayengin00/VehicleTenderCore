﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderHistoryController : ControllerBase
    {
        private readonly ITenderHistoryService _tenderService;
        public TenderHistoryController(ITenderHistoryService historyService)
        {
            _tenderService = historyService;
        }

        [HttpPost("add")]
        public IActionResult Add(TenderOfferAddVM vm)
        {
            _tenderService.Add(vm);
            return Ok();
        }
    }
}
