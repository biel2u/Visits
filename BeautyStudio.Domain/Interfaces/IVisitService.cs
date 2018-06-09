using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyStudio.Domain.Dto;

namespace BeautyStudio.Domain.Interfaces
{
    public interface IVisitService
    {
        Task<AddVisitDto> AddVisit(AddVisitDto addVisitDto);

        Task<List<VisitDto>> GetAllVisits();

        Task<VisitDto> GetVisitById(string id);

        Task<bool> DeleteVisit(string id);

        Task<UpdateVisitDto> UpdateVisit(UpdateVisitDto updateVisitDto);
    }
}
