using System;
using BeautyStudio.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MongoDB.Driver;

namespace BeautyStudio.Domain
{
    public class BeautyDbContext
    {
        private readonly IMongoDatabase _database;

        public BeautyDbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Visit> Visits
        {
            get
            {
                return _database.GetCollection<Visit>("Visit");
            }
        }
    }
}
