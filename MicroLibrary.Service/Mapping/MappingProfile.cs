using AutoMapper;
using MicroLibrary.Infrastructure;

namespace MicroLibrary.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryUser, LibraryUserDto>();
            CreateMap<LibraryUserContact, LibraryUserContactDto>();
        }
    }
}
