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
        public async Task<IActionResult> GetAll()
        {
            var response = await _visitService.GetAllVisits();

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _visitService.GetVisitById(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddVisitDto visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _visitService.AddVisit(visit);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            var response = await _visitService.DeleteVisit(id);

            if (response == false)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVisitDto visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _visitService.UpdateVisit(visit);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}