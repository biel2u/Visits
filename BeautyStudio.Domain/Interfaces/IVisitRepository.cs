using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyStudio.Domain.Models;

namespace BeautyStudio.Domain.Interfaces
{
    public interface IVisitRepository
    {
        Task<List<Visit>> GetAllVisits();

        Task<Visit> GetVisitById(string id);

        Task<Visit> AddVisit(Visit visit);

        Task<bool> DeleteVisit(string id);

        Task<Visit> UpdateVisit(Visit visit);
    }
}
