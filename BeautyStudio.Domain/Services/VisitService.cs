using System.Collections.Generic;
using AutoMapper;
using BeautyStudio.Domain.Dto;
using BeautyStudio.Domain.Interfaces;
using BeautyStudio.Domain.Models;

namespace BeautyStudio.Domain.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitService(IVisitRepository visitRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public List<VisitDto> GetAllVisits()
        {
            var visits = _visitRepository.GetAllVisits();
            var result = _mapper.Map<List<VisitDto>>(visits);

            return result;
        }

        public AddVisitDto AddVisit(AddVisitDto addVisitDto)
        {
            var visit = new Visit
            {
                Name = addVisitDto.Name,
                Surname = addVisitDto.Surname,
                PhoneNumber = addVisitDto.PhoneNumber,
                Email = addVisitDto.Email,
                Treatment = addVisitDto.Treatment,
                VisitDate = addVisitDto.VisitDate,
                Message = addVisitDto.Message
            };

            var result = _visitRepository.AddVisit(visit);

            var addedVisitDto = new AddVisitDto
            {
                Name = visit.Name,
                Surname = visit.Surname,
                PhoneNumber = visit.PhoneNumber,
                Email = visit.Email,
                Treatment = visit.Treatment,
                VisitDate = visit.VisitDate,
                Message = visit.Message
            };

            return addedVisitDto;
        }
    }
}
