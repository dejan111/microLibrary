using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroLibrary.Service
{
    public interface ILibraryUserService
    {
        Task<IEnumerable<LibraryUserDto>> GetLibraryUsers();
        Task<LibraryUserDto> GetLibraryUser(int id);
        Task<LibraryUserDto> CreateLibraryUser(LibraryUserDto libraryUserDto);
        Task UpdateLibraryUser(LibraryUserDto libraryUserDto);
        Task DeleteLibraryUser(int id);
    }
}
