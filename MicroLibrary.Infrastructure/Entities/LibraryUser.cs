using System;
using System.Collections.Generic;

#nullable disable

namespace MicroLibrary.Infrastructure
{
    public partial class LibraryUser
    {
        public LibraryUser()
        {
            LibraryUserContacts = new HashSet<LibraryUserContact>();
            Rents = new HashSet<Rent>();
        }

        public int Id { get; set; }
        public int LibraryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Library Library { get; set; }
        public virtual ICollection<LibraryUserContact> LibraryUserContacts { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
