using System;
using System.Collections.Generic;

#nullable disable

namespace MicroLibrary.Infrastructure.Entities
{
    public partial class LibraryUserContact
    {
        public int Id { get; set; }
        public int LibraryUserId { get; set; }
        public int ContactTypeId { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ContactType ContactType { get; set; }
        public virtual LibraryUser LibraryUser { get; set; }
    }
}
