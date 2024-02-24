using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Providers.Handlers.Queries;
    public class GetCarDetails : IRequest<CarDetails>
    {
        public string RegisterationNumber { get; }
        public GetCarDetails(string RegisterationNumber)
        {
           this.RegisterationNumber=RegisterationNumber;
        }
    }

    public class GetCarDetailsQueryHandler : IRequestHandler<GetCarDetails, CarDetails>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetCarDetailsQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarDetails> Handle(GetCarDetails request, CancellationToken cancellationToken)
        {
            var carDetails= await Task.FromResult(_repository.Cars.Get(request.RegisterationNumber));
            
            if (carDetails == null)
            {
                throw new EntityNotFoundException($"No Car found with registration number {request.RegisterationNumber}");
            }
            return carDetails;
        }
    }