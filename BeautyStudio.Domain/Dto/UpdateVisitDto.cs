﻿using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace BeautyStudio.Domain.Dto
{
    public class UpdateVisitDto
    {
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Proszę podać numer adres e-mail")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę wybrać zabieg")]
        public string Treatment { get; set; }

        [Required(ErrorMessage = "Proszę podać datę wizyty")]
        public DateTime VisitDate { get; set; }

        [MaxLength(255, ErrorMessage = "Maksymalna ilość znaków wynosi 255")]
        public string Message { get; set; }
    }
}
