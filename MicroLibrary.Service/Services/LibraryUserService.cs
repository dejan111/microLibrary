using AutoMapper;
using MicroLibrary.Infrastructure;
using MicroLibrary.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroLibrary.Service
{
    public class LibraryUserService : ServiceBase, ILibraryUserService
    {
        public LibraryUserService(MicroLibraryContext microLibraryContext, IMapper mapper) : base(microLibraryContext, mapper)
        { }

        public async Task<IEnumerable<LibraryUserDto>> GetLibraryUsers()
        {
            IEnumerable<LibraryUser> query = await _microLibraryContext.LibraryUsers.AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(x => x.LibraryUserContacts).ToListAsync();

            IEnumerable<LibraryUserDto> retVal = query.Select(x => new LibraryUserDto()
            {
                Id = x.Id,
                Active = x.Active.GetValueOrDefault(),
                Address = x.Address,
                PostalCode = x.PostalCode,
                City = x.City,
                DateOfBirth = x.DateOfBirth,
                FirstName = x.FirstName,
                LastName = x.LastName,
                LibraryId = x.LibraryId,
                Oib = x.Oib,
                LibraryUserContacts = x.LibraryUserContacts.Where(c => !c.IsDeleted).Select(luc => new LibraryUserContactDto()
                {
                    Id = luc.Id,
                    Contact = luc.Contact,
                    ContactTypeId = luc.ContactTypeId,
                    ContactTypeName = ((ContactTypeEnum)luc.ContactTypeId).ToString(),
                    Description = luc.Description,
                    LibraryUserId = x.Id
                })
            });

            return retVal;
        }

        public async Task<LibraryUserDto> GetLibraryUser(int id)
        {
            LibraryUser libraryUser = await _microLibraryContext.LibraryUsers.AsNoTracking()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Include(x => x.LibraryUserContacts).FirstOrDefaultAsync();

            LibraryUserDto libraryUserDto = null;

            if (libraryUser is not null)
            {
                libraryUserDto = new()
                {
                    Id = libraryUser.Id,
                    Active = libraryUser.Active.GetValueOrDefault(),
                    Address = libraryUser.Address,
                    PostalCode = libraryUser.PostalCode,
                    City = libraryUser.City,
                    DateOfBirth = libraryUser.DateOfBirth,
                    FirstName = libraryUser.FirstName,
                    LastName = libraryUser.LastName,
                    LibraryId = libraryUser.LibraryId,
                    Oib = libraryUser.Oib,
                    LibraryUserContacts = libraryUser.LibraryUserContacts.Where(c => !c.IsDeleted).Select(luc => new LibraryUserContactDto()
                    {
                        Id = luc.Id,
                        Contact = luc.Contact,
                        ContactTypeId = luc.ContactTypeId,
                        ContactTypeName = ((ContactTypeEnum)luc.ContactTypeId).ToString(),
                        Description = luc.Description,
                        LibraryUserId = libraryUser.Id
                    })
                };
            }

            return libraryUserDto;
        }

        public async Task<LibraryUserDto> CreateLibraryUser(LibraryUserDto libraryUserDto)
        {
            LibraryUser libraryUser = new()
            {
                Address = libraryUserDto.Address,
                City = libraryUserDto.City,
                PostalCode = libraryUserDto.PostalCode,
                DateCreated = DateTime.Now,
                CreatedByUserId = new Guid("29D29ACD-131C-4C6B-B362-3A3B42B04786"),
                DateOfBirth = libraryUserDto.DateOfBirth,
                FirstName = libraryUserDto.FirstName,
                LastName = libraryUserDto.LastName,
                LibraryId = libraryUserDto.LibraryId,
                Oib = libraryUserDto.Oib,
            };

            await _microLibraryContext.LibraryUsers.AddAsync(libraryUser);
            await _microLibraryContext.SaveChangesAsync();

            return _mapper.Map<LibraryUserDto>(libraryUser);
        }

        public async Task UpdateLibraryUser(LibraryUserDto libraryUserDto)
        {
            LibraryUser libraryUser = await _microLibraryContext.LibraryUsers.FirstOrDefaultAsync(x => x.Id == libraryUserDto.Id && !x.IsDeleted);

            if (libraryUser is not null)
            {
                libraryUser.FirstName = libraryUserDto.FirstName;
                libraryUser.LastName = libraryUserDto.LastName;
                libraryUser.PostalCode = libraryUserDto.PostalCode;
                libraryUser.Address = libraryUserDto.Address;
                libraryUser.City = libraryUserDto.City;
            }

            await _microLibraryContext.SaveChangesAsync();
        }

        public async Task DeleteLibraryUser(int id)
        {
            LibraryUser libraryUser = await _microLibraryContext.LibraryUsers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (libraryUser is not null)
            {
                libraryUser.IsDeleted = true;

                await _microLibraryContext.SaveChangesAsync();
            }
        }
    }
}
