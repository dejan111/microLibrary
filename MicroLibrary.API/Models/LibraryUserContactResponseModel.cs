namespace MicroLibrary.API
{
    public class LibraryUserContactResponseModel
    {
        public int Id { get; set; }
        public int LibraryUserId { get; set; }
        public int ContactTypeId { get; set; }
        public string ContactTypeName { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
    }
}
