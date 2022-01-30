﻿namespace MicroLibrary.API.ViewModels
{
    public class LibraryUserContactResponseVm
    {
        public int Id { get; set; }
        public int LibraryUserId { get; set; }
        public int ContactTypeId { get; set; }
        public string ContactTypeName { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
    }
}
