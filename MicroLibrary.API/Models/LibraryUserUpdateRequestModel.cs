using System;
using System.ComponentModel.DataAnnotations;

namespace MicroLibrary.API
{
    public class LibraryUserUpdateRequestModel
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public int? LibraryId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Oib { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }
    }
}
