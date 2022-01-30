using AutoMapper;
using MicroLibrary.API.ViewModels;
using MicroLibrary.Service.Dtos;

namespace MicroLibrary.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryUserDto, LibraryUserResponseVm>();
            CreateMap<LibraryUserContactDto, LibraryUserContactResponseVm>();
            CreateMap<LibraryUserRequestVm, LibraryUserDto>();
            CreateMap<LibraryUserContactRequestVm, LibraryUserContactDto>();
            CreateMap<LibraryUserUpdateRequestVm, LibraryUserDto>();
        }
    }
}
