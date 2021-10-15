using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Wedding.Models
{
    public class RSVP
    {
    [Key]
        public int RSVPId { get; set; }


        public int UserId {get;set;}
        public User User {get;set;}

        public int WeddingId {get;set;}
        public WeddingModel Wedding {get;set;}


    }
}