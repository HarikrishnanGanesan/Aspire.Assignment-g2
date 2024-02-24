using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;

namespace Assignment.Providers.Handlers.Commands
{
    public class CreateBookingCommand : IRequest<Unit>
    {
        public BookingDTO BookingDTO { get; }

        public CreateBookingCommand(BookingDTO bookingDTO)
        {
            BookingDTO = bookingDTO;
        }
    }
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Unit>
    {
        private readonly IUnitOfWork _repository;
        public CreateBookingCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            BookingDTO bookingDTO=request.BookingDTO;
            if(bookingDTO == null){
                throw new InvalidRequestBodyException();
            }
            var model=new Booking{
                RegistrationNumber = bookingDTO.RegistrationNumber,
                CustomerName = bookingDTO.CustomerName,
                MobileNumber = bookingDTO.MobileNumber,
                PickupDateTime = bookingDTO.PickupDateTime,
                ReturnDateTime = bookingDTO.ReturnDateTime,
                PickupLocation = bookingDTO.PickupLocation,
                DropLocation = bookingDTO.DropLocation,
                ShippingType = bookingDTO.ShippingType,
                PaymentMode = bookingDTO.PaymentMode,
                PaymentStatus = bookingDTO.PaymentStatus,
                DLNumber = bookingDTO.DLNumber,
                DLImageFront=bookingDTO.DLImageFront,
                DLImageBack=bookingDTO.DLImageBack
            };
            
            _repository.Booking.Add(model);
            await _repository.CommitAsync();
            return Unit.Value;
            //throw new NotImplementedException();
        }
    }
}