using AutoMapper;
using MicroLibrary.Service;

namespace MicroLibrary.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryUserDto, LibraryUserResponseModel>();
            CreateMap<LibraryUserContactDto, LibraryUserContactResponseModel>();
            CreateMap<LibraryUserRequestModel, LibraryUserDto>();
            CreateMap<LibraryUserContactRequestModel, LibraryUserContactDto>();
            CreateMap<LibraryUserUpdateRequestModel, LibraryUserDto>();
        }
    }
}
