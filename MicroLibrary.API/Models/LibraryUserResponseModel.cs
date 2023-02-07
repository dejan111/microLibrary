using System;
using System.Collections.Generic;

namespace MicroLibrary.API
{
    public class LibraryUserResponseModel
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; }

        public IEnumerable<LibraryUserContactResponseModel> LibraryUserContacts { get; set; }
    }
}
