using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeautyStudio.Domain.Models;

namespace BeautyStudio.Domain.Interfaces
{
    public interface IVisitRepository
    {
        Task<List<Visit>> GetAllVisits();

        Task<Visit> GetVisitById(int id);

        Task<Visit> AddVisit(Visit visit);

        Task<bool> DeleteVisit(int id);

        Task<bool> UpdateNote(Visit visit);
    }
}
