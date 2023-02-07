using System;
using System.Collections.Generic;

#nullable disable

namespace MicroLibrary.Infrastructure
{
    public partial class Book
    {
        public Book()
        {
            Rents = new HashSet<Rent>();
        }

        public int Id { get; set; }
        public int LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsRented { get; set; }
        public bool? Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Library Library { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
