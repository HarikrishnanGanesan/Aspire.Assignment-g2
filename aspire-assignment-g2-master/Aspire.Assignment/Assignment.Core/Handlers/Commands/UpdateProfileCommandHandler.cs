using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;

namespace Assignment.Providers.Handlers.Commands;
public class UpdateProfile : IRequest<UserProfile>
{
    public string Email { get; set; }
    public UserProfileDTO Model { get; }
    public UpdateProfile(string email, UserProfileDTO model)
    {
        this.Email = email;
        this.Model = model;
    }
}
public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfile, UserProfile>
{
    private readonly IUnitOfWork _repository;
    private readonly IValidator<RegistrationDTO> _validator;

    public UpdateProfileCommandHandler(IUnitOfWork repository, IValidator<RegistrationDTO> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<UserProfile> Handle(UpdateProfile request, CancellationToken cancellationToken)
    {
        string email = request.Email;
        UserProfileDTO profile = request.Model;
        var entity = _repository.UserProfiles.Get(email) ?? throw new EntityNotFoundException($"User with ID {email} not found");
        
        if (profile == null)
        {
            throw new InvalidRequestBodyException();
        }
        if (!string.IsNullOrEmpty(profile.Password))
            {
                var passwordValidationResult = _validator.Validate(new RegistrationDTO { 
                    Email=entity.Email,
                    Name=entity.Name,
                    ContactNumber=entity.ContactNumber,
                    Password = profile.Password });
                if (!passwordValidationResult.IsValid)
                {
                    throw new ValidationException(passwordValidationResult.Errors);
                }
            }
            if (!string.IsNullOrEmpty(profile.ContactNumber))
            {
                var contactNumberValidationResult = _validator.Validate(new RegistrationDTO { Email=entity.Email,
                    Name=entity.Name,
                    ContactNumber=profile.ContactNumber,
                    Password = entity.Password });
                if (!contactNumberValidationResult.IsValid)
                {
                    throw new ValidationException(contactNumberValidationResult.Errors);
                }
            }
        
        entity.Name = profile.Name ?? entity.Name;
        entity.Password = profile.Password ?? entity.Password;
        entity.ContactNumber = profile.ContactNumber ?? entity.ContactNumber;
        entity.Address=profile.Address ?? entity.Address;
        entity.ProfileImage = profile.ProfileImage ?? entity.ProfileImage;
        entity.DLImageFront = profile.LicenseFront ?? entity.DLImageFront;
        entity.DLImageBack = profile.LicenseBack ?? entity.DLImageBack;
        _repository.UserProfiles.Update(entity);
        await _repository.CommitAsync();
        return entity;
    }
}