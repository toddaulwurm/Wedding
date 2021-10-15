using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Wedding.Models
{
    public class WeddingModel
    {
    [Key]
        public int WeddingId { get; set; }

	[Required]
	[MinLength(2, ErrorMessage="Name must be at least 2 characters")]
        public string NameOne { get; set; }

	[Required]
	[MinLength(2, ErrorMessage="Name must be at least 2 characters")]
        public string NameTwo { get; set; }

    [Required]
    [FutureDateAttribute]
        public DateTime Date { get; set; }

    [Required]
    [MinLength(10, ErrorMessage="Name must be at least 10 characters")]
        public string Address { get; set; }

        public List<RSVP> RSVPs {get;set;}

        public int UserId {get;set;}
        public User User {get;set;}



        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }




    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime checkMe = (DateTime)value;
                if(checkMe < DateTime.Now)
                {
                    return new ValidationResult("That's the Past!");                        
                }
                else 
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Not a date");
            }
        }
    }
}