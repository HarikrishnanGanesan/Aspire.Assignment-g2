using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;

namespace Assignment.Providers.Handlers.Commands;
public class RegisterUser:IRequest<UserProfile>{
    public RegistrationDTO Model{get;}
    public RegisterUser(RegistrationDTO model){
        Model=model;
    }
}
public class RegisterUserCommandHandler : IRequestHandler<RegisterUser, UserProfile>
{
    private readonly IUnitOfWork _repository;
    private readonly IValidator<RegistrationDTO> _validator;

        public RegisterUserCommandHandler(IUnitOfWork repository, IValidator<RegistrationDTO> validator)
        {
            _repository = repository;
            _validator=validator;
        }
    public async Task<UserProfile> Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        RegistrationDTO userProfile=request.Model;
        var result = _validator.Validate(userProfile);

            if (userProfile==null || !result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            throw new InvalidRequestBodyException{
                Errors=errors
            };
        }
        var model=new UserProfile{
            Email=userProfile.Email,
            Name=userProfile.Name!,
            ContactNumber=userProfile.ContactNumber!,
            Password=userProfile.Password!,
            Address=null,
            ProfileImage=null,
            DLImageFront=null,
            DLImageBack=null
        };
        _repository.UserProfiles.Add(model);
        await _repository.CommitAsync();
        return model;
    }
}