using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Domain.Enumerations;

namespace Domain.Models
{
    [Table("account")]
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public AccountType AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
