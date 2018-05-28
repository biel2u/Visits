using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using BeautyStudio.Domain.Interfaces;
using BeautyStudio.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BeautyStudio.Domain.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly BeautyDbContext _context;

        public VisitRepository(IOptions<Settings> settings)
        {
            _context = new BeautyDbContext(settings);
        }

        public async Task<List<Visit>> GetAllVisits()
        {
            var result = await _context.Visits.Find(_ => true).ToListAsync();

            return result;
        }

        public async Task<Visit> GetVisitById(int id) //string?
        {
            var visit = Builders<Visit>.Filter.Eq("Id", id);

            var result = await _context.Visits.Find(visit).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Visit> AddVisit(Visit visit)
        {
            try
            {
                await _context.Visits.InsertOneAsync(visit);

                return visit;
            }
            catch (Exception)
            {
                return null;
            }                  
        }

        public async Task<bool> DeleteVisit(int id)
        {
            var result = await _context.Visits.DeleteOneAsync(Builders<Visit>.Filter.Eq("Id", id));

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<bool> UpdateNote(Visit visit)
        {
            var result = await _context.Visits.ReplaceOneAsync(v => v.Id.Equals(visit.Id), visit, new UpdateOptions {IsUpsert = true});
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
