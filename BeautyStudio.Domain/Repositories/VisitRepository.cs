using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyStudio.Domain.Interfaces;
using BeautyStudio.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

        public async Task<Visit> GetVisitById(string id)
        {
            var result = await _context.Visits.Find(new BsonDocument {{"_id", new ObjectId(id)}}).FirstOrDefaultAsync();
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

        public async Task<bool> DeleteVisit(string id)
        {
            var result = await _context.Visits.DeleteOneAsync(new BsonDocument {{"_id", new ObjectId(id)}});

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<Visit> UpdateVisit(Visit visit)
        {
            var visitToUpdate = await _context.Visits.ReplaceOneAsync(v => v.Id == visit.Id, visit, new UpdateOptions {IsUpsert = true});

            if (!visitToUpdate.IsAcknowledged && visitToUpdate.ModifiedCount <= 0)
            {
                return null;
            }

            return visit;
        }
    }
}
