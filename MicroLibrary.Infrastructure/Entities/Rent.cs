using System;
using System.Collections.Generic;

#nullable disable

namespace MicroLibrary.Infrastructure
{
    public partial class Rent
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int LibraryUserId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime? DateReturned { get; set; }
        public int? OverdueInDays { get; set; }
        public bool? Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Book Book { get; set; }
        public virtual LibraryUser LibraryUser { get; set; }
    }
}
