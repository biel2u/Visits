using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<VisitDto>> GetAllVisits()
        {
            var visits = await _visitRepository.GetAllVisits();

            var result = _mapper.Map<List<VisitDto>>(visits);
            return result;
        }

        public async Task<VisitDto> GetVisitById(string id)
        {
            var visit = await _visitRepository.GetVisitById(id);

            var result = _mapper.Map<VisitDto>(visit);
            return result;
        }

        public async Task<AddVisitDto> AddVisit(AddVisitDto addVisitDto)
        {
            var visitToAdd = _mapper.Map<Visit>(addVisitDto);

            var addedVisit = await _visitRepository.AddVisit(visitToAdd);

            var result = _mapper.Map<AddVisitDto>(addedVisit);
            return result;
        }

        public async Task<bool> DeleteVisit(string id)
        {
            var result = await _visitRepository.DeleteVisit(id);
            return result;
        }

        public async Task<UpdateVisitDto> UpdateVisit(UpdateVisitDto updateVisitDto)
        {
            var visitToUpdate = _mapper.Map<Visit>(updateVisitDto);

            var updatedVisit = await _visitRepository.UpdateVisit(visitToUpdate);

            var result = _mapper.Map<UpdateVisitDto>(updatedVisit);
            return result;
        }
    }
}
