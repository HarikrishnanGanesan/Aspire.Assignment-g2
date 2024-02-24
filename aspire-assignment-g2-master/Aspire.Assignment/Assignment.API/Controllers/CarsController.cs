using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
public class CarsController : ControllerBase
{
    private readonly IMediator _sender;
    public CarsController(IMediator sender)
    {
        _sender = sender;
        
    }
    [HttpGet]
    [Route("GetCarDetails/"+"{id}")]
    [ProducesResponseType(typeof(IEnumerable<CarDetails>), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(BaseResponseDTO))]
    public async Task<IActionResult> GetCarDetails(string id)
    {
        try
        {
            var query = new GetCarDetails(id);
            var carDetails = await _sender.Send(query);
            return Ok(carDetails);
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
    [Route("AddCar")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesErrorResponseType(typeof(BaseResponseDTO))]
    public async Task<IActionResult> AddCar([FromForm]  CarDetailsDTO carDetailsDTO){
     try
        { 
            if (carDetailsDTO.ImageFile != null)
          {    
            carDetailsDTO.ImageData = await GetByteArrayFromFormFile(carDetailsDTO.ImageFile);
          }
            var query = new AddCar(carDetailsDTO);
            var carDetails = await _sender.Send(query);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch(InvalidRequestBodyException exception){
         return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = exception.Errors
                });
        }
        catch(ArgumentNullException exception){
            return BadRequest(new BaseResponseDTO
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