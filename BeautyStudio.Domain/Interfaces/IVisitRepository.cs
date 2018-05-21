using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeautyStudio.Domain.Models;

namespace BeautyStudio.Domain.Interfaces
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetAllVisits();

        Task<Visit> GetVisitById(int id);

        Task AddVisit(Visit visit);

        Task<bool> DeleteVisit(int id);

        Task<bool> UpdateNote(Visit visit);
    }
}
