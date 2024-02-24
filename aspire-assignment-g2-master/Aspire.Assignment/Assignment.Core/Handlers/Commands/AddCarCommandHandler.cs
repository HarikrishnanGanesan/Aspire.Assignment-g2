using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;

namespace Assignment.Providers.Handlers.Commands;
public class AddCar : IRequest<Unit>{ 
    public CarDetailsDTO Model { get; }
        public AddCar(CarDetailsDTO model)
        {
            this.Model = model;
        }
 }
public class AddCarCommandHandler : IRequestHandler<AddCar, Unit>
{
    private readonly IUnitOfWork _repository;

        public AddCarCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }
    public async Task<Unit> Handle(AddCar request, CancellationToken cancellationToken)
    {
        CarDetailsDTO carDetailsDTO=request.Model;
        if(carDetailsDTO==null){
           throw new InvalidRequestBodyException();
        }
        var car=new CarDetails{
            RegistrationNumber=carDetailsDTO.RegistrationNumber,
            ManufacturerName=carDetailsDTO.ManufacturerName,
            Model=carDetailsDTO.Model,
            ModelYear=carDetailsDTO.ModelYear,
            PassengerCapacity=carDetailsDTO.PassengerCapacity,
            Colour=carDetailsDTO.Colour,
            TransmissionType=carDetailsDTO.TransmissionType,
            FuelType=carDetailsDTO.FuelType,
            HasAC=carDetailsDTO.HasAC,
            Mileage=carDetailsDTO.Mileage,
            ImageData=carDetailsDTO.ImageData!,
            PricePerHour=carDetailsDTO.PricePerHour,
            PricePerDay=carDetailsDTO.PricePerDay,
            PricePerWeek=carDetailsDTO.PricePerWeek,
            KilometersDriven=carDetailsDTO.KilometersDriven,
            Available=carDetailsDTO.Available,
            Description=carDetailsDTO.Description 
        };
        _repository.Cars.Add(car);
        await _repository.CommitAsync();
        return Unit.Value;

    }
}