using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    [Table("owner")]
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "FirstName can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, ErrorMessage = "LastName can't be longer than 50 characters")]
        public string LastName { get; set; }
        
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string RegionCode { get; set; }
        //[JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
    }
}
