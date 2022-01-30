using AutoMapper;
using MicroLibrary.Infrastructure.Entities;
using MicroLibrary.Service.Dtos;

namespace MicroLibrary.Service.Mapping
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
