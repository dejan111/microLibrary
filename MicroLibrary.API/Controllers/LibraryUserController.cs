using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MicroLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace MicroLibrary.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILibraryUserService _libraryUserService;

        public LibraryUserController(IMapper mapper, ILibraryUserService libraryUserService)
        {
            _mapper = mapper;
            _libraryUserService = libraryUserService;
        }

        /// <summary>
        /// Get all library users
        /// </summary>
        /// <returns>200 OK response containing list of library users</returns>
        /// <response code="200">List of library users</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        public async ValueTask<IActionResult> GetLibraryUsers()
        {
            IEnumerable<LibraryUserDto> libraryUsers = await _libraryUserService.GetLibraryUsers();
            return Ok(_mapper.Map<IEnumerable<LibraryUserResponseModel>>(libraryUsers));
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
        public async ValueTask<IActionResult> GetLibraryUser(int id)
        {
            LibraryUserDto libraryUserDto = await _libraryUserService.GetLibraryUser(id);

            return Ok(_mapper.Map<LibraryUserResponseModel>(libraryUserDto));
        }

        /// <summary>
        /// Create library user
        /// </summary>
        /// <param name="libraryUserRequest">Library user view model</param>
        /// <returns>201 containing created entity</returns>
        /// <response code="201">Created library user</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        public async ValueTask<IActionResult> CreateLibraryUser(LibraryUserRequestModel libraryUserRequest)
        {
            if (libraryUserRequest is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LibraryUserDto libraryUserDto = _mapper.Map<LibraryUserDto>(libraryUserRequest);
            LibraryUserDto libraryUserDtoResponse = await _libraryUserService.CreateLibraryUser(libraryUserDto);

            return CreatedAtAction(nameof(CreateLibraryUser), _mapper.Map<LibraryUserResponseModel>(libraryUserDto));
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
        public async ValueTask<IActionResult> UpdateLibraryUser(LibraryUserUpdateRequestModel libraryUserRequest)
        {
            if (libraryUserRequest is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LibraryUserDto existingLibraryUserDto = await _libraryUserService.GetLibraryUser(libraryUserRequest.Id.GetValueOrDefault());

            if (existingLibraryUserDto is null)
            {
                return NotFound();
            }

            LibraryUserDto libraryUserDto = _mapper.Map<LibraryUserDto>(libraryUserRequest);
            await _libraryUserService.UpdateLibraryUser(libraryUserDto);

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
        public async ValueTask<IActionResult> DeleteLibraryUser(int id)
        {
            LibraryUserDto libraryUserDto = await _libraryUserService.GetLibraryUser(id);

            if (libraryUserDto is null)
            {
                return NotFound();
            }

            await _libraryUserService.DeleteLibraryUser(id);

            return Ok();
        }
    }
}
