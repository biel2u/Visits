using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyStudio.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyStudio.Api.Controllers
{
    [Route("api/[controller]")]
    public class VisitController : Controller
    {
        private readonly IVisitRepository _visitRepository;
        public VisitController(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

    }
}