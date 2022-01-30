using System;
using System.Collections.Generic;

#nullable disable

namespace MicroLibrary.Infrastructure.Entities
{
    public partial class ContactType
    {
        public ContactType()
        {
            LibraryUserContacts = new HashSet<LibraryUserContact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<LibraryUserContact> LibraryUserContacts { get; set; }
    }
}
