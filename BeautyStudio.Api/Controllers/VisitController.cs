using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyStudio.Domain.Dto;
using BeautyStudio.Domain.Interfaces;
using BeautyStudio.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeautyStudio.Api.Controllers
{
    [Route("api/[controller]")]
    public class VisitController : Controller
    {
        private readonly IVisitService _visitService;
        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet]
        public IActionResult GetAllVisits()
        {
            var result = _visitService.GetAllVisits();
        }

        [HttpPost]
        public IActionResult CreateVisit([FromBody]AddVisitDto visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _visitService.AddVisit(visit);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}