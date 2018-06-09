using System;
using MongoDB.Bson;

namespace BeautyStudio.Domain.Dto
{
    public class VisitDto
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Treatment { get; set; }

        public DateTime VisitDate { get; set; }

        public string Message { get; set; }

        public bool IsCanceled { get; set; }
    }
}
