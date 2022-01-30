using System.ComponentModel.DataAnnotations;

namespace MicroLibrary.API.ViewModels
{
    public class LibraryUserContactRequestVm
    {
        [Required]
        public int LibraryUserId { get; set; }
        [Required]
        public int ContactTypeId { get; set; }
        [Required]
        public string Contact { get; set; }
        public string Description { get; set; }
    }
}
