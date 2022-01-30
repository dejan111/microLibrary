using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MicroLibrary.API.ViewModels;
using MicroLibrary.Service.Dtos;
using MicroLibrary.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryUserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILibraryUserService libraryUserService;

        public LibraryUserController(IMapper mapper, ILibraryUserService libraryUserService)
        {
            this.mapper = mapper;
            this.libraryUserService = libraryUserService;
        }

        /// <summary>
        /// Get all library users
        /// </summary>
        /// <returns>200 OK response containing list of library users</returns>
        /// <response code="200">List of library users</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        public async Task<IActionResult> GetLibraryUsers()
        {
            IEnumerable<LibraryUserDto> libraryUsers = await libraryUserService.GetLibraryUsers();

            return Ok(mapper.Map<IEnumerable<LibraryUserResponseVm>>(libraryUsers));
        }

        /// <summary>
        /// Get library user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200 OK response containing a library user</returns>
        /// <response code="200">List of library users</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLibraryUser(int id)
        {
            LibraryUserDto libraryUserDto = await libraryUserService.GetLibraryUser(id);

            return Ok(mapper.Map<LibraryUserResponseVm>(libraryUserDto));
        }

        /// <summary>
        /// Create library user
        /// </summary>
        /// <param name="libraryUserRequest">Library user view model</param>
        /// <returns>201 containing created entity</returns>
        /// <response code="201">Created library user</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        public async Task<IActionResult> CreateLibraryUser(LibraryUserRequestVm libraryUserRequest)
        {
            if (libraryUserRequest is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LibraryUserDto libraryUserDto = mapper.Map<LibraryUserDto>(libraryUserRequest);
            LibraryUserDto libraryUserDtoResponse = await libraryUserService.CreateLibraryUser(libraryUserDto);

            return CreatedAtAction(nameof(CreateLibraryUser), mapper.Map<LibraryUserResponseVm>(libraryUserDto));
        }

        /// <summary>
        /// Update library user
        /// </summary>
        /// <param name="libraryUserRequest">Library user view model</param>
        /// <returns>200 OKy</returns>
        /// <response code="200">Update successfull</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Entity for update not found</response>
        [HttpPut]
        public async Task<IActionResult> UpdateLibraryUser(LibraryUserUpdateRequestVm libraryUserRequest)
        {
            if (libraryUserRequest is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LibraryUserDto existingLibraryUserDto = await libraryUserService.GetLibraryUser(libraryUserRequest.Id.GetValueOrDefault());

            if (existingLibraryUserDto is null)
            {
                return NotFound();
            }

            LibraryUserDto libraryUserDto = mapper.Map<LibraryUserDto>(libraryUserRequest);
            await libraryUserService.UpdateLibraryUser(libraryUserDto);

            return Ok();
        }

        /// <summary>
        /// Delete library user
        /// </summary>
        /// <param name="id">Library user id</param>
        /// <returns>200 OK</returns>
        /// <response code="200">Delete successfull</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Entity for delete not found</response>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLibraryUser(int id)
        {
            LibraryUserDto libraryUserDto = await libraryUserService.GetLibraryUser(id);

            if (libraryUserDto is null)
            {
                return NotFound();
            }

            await libraryUserService.DeleteLibraryUser(id);

            return Ok();
        }
    }
}
