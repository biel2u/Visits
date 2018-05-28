using System.Collections.Generic;
using BeautyStudio.Domain.Dto;

namespace BeautyStudio.Domain.Interfaces
{
    public interface IVisitService
    {
        AddVisitDto AddVisit(AddVisitDto addVisitDto);
        List<VisitDto> GetAllVisits();
    }
}
