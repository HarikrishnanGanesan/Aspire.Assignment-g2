using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Providers.Handlers.Commands;
using Assignment.Providers.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase {
private readonly IMediator _mediator;
public UserProfileController(IMediator mediator)
{
    _mediator=mediator;
}
    [HttpGet]
    [Route("GetProfile/"+"{id}")]
    [ProducesResponseType(typeof(IEnumerable<UserProfile>), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseResponseDTO))]
    public async Task<IActionResult> GetProfileDetails(string id)
    {
        try
        {   
            var query = new GetProfile(id);
            var profile = await _mediator.Send(query);
            return Ok(profile);
        }
        catch (EntityNotFoundException exception)
        {
            return NotFound(new BaseResponseDTO
            {
                IsSuccess = false,
                Errors = [exception.Message]
            });
        }
    }
    
    [HttpPost]
    [Route("Register")]
    [ProducesResponseType(typeof(IEnumerable<UserProfile>),(int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseResponseDTO))]
    public async Task<IActionResult> Register([FromBody] RegistrationDTO userProfile){
     try
        { 
            var query = new RegisterUser(userProfile);
            var profile = await _mediator.Send(query);
            return Ok(profile);
        }

     catch(InvalidRequestBodyException exception){
            return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = exception.Errors
                });
    }
    }
    [HttpPut]
    [Route("UpdateProfile")]
    [ProducesResponseType(typeof(IEnumerable<UserProfile>),(int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseResponseDTO))]
    public async Task<IActionResult> UpdateProfile(string email,[FromForm] UserProfileDTO profileDetailsDTO){
     try
        {   
          if (profileDetailsDTO.ProfileImageFile != null)
          {    
            profileDetailsDTO.ProfileImage = await GetByteArrayFromFormFile(profileDetailsDTO.ProfileImageFile);
          }
          if (profileDetailsDTO.LicenseFrontFile != null)
          {    
            profileDetailsDTO.LicenseFront = await GetByteArrayFromFormFile(profileDetailsDTO.LicenseFrontFile);
          }
          if (profileDetailsDTO.LicenseBackFile != null)
          {    
            profileDetailsDTO.LicenseBack = await GetByteArrayFromFormFile(profileDetailsDTO.LicenseBackFile);
          }
            var query = new UpdateProfile(email,profileDetailsDTO);
            var details = await _mediator.Send(query);
            return Ok(details);
        }
        catch(InvalidRequestBodyException exception){
         return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = exception.Errors
                });
        }
    }
     [HttpDelete]
    [Route("DeleteProfile/"+"{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseResponseDTO))]
    public async Task<IActionResult> DeleteProfile(string id)
    {
        try
        {
            var query = new DeleteProfile(id);
            var profile = await _mediator.Send(query);
            return Ok();
        }
        catch (EntityNotFoundException exception)
        {
            return NotFound(new BaseResponseDTO
            {
                IsSuccess = false,
                Errors = [exception.Message]
            });
        }
    } 
    private async Task<byte[]> GetByteArrayFromFormFile(IFormFile file)
{
    using (var memoryStream = new MemoryStream())
    {
        await file.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}
}