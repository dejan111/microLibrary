using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroLibrary.API.ViewModels
{
    public class LibraryUserRequestVm
    {
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
        //[Required]
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; }

        //public IEnumerable<LibraryUserContactRequestVm> LibraryUserContacts { get; set; }
    }
}
