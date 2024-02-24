using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;

namespace Assignment.Providers.Handlers.Commands;
public class DeleteProfile : IRequest<Unit>{ 
    public string Email { get; }
        public DeleteProfile(string email)
        {
            this.Email = email;
        }
 }
public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfile, Unit>
{
    private readonly IUnitOfWork _repository;

        public DeleteProfileCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

    public async Task<Unit> Handle(DeleteProfile request, CancellationToken cancellationToken)
    {
        var email=request.Email;
        if(email==null){
            throw new EntityNotFoundException();
        }
        _repository.UserProfiles.Delete(email);
       // _repository.Login.Delete(email);
        await _repository.CommitAsync();
        return Unit.Value;
    }
}