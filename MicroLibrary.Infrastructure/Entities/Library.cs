using System;
using System.Collections.Generic;

#nullable disable

namespace MicroLibrary.Infrastructure
{
    public partial class Library
    {
        public Library()
        {
            Books = new HashSet<Book>();
            LibraryUsers = new HashSet<LibraryUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public bool? Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<LibraryUser> LibraryUsers { get; set; }
    }
}
