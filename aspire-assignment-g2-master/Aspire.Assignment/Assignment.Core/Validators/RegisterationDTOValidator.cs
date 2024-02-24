using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators;
    public class RegistrationDTOValidator : AbstractValidator<RegistrationDTO>
    {
        public RegistrationDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").Matches(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b").WithMessage("Invalid Email");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").Matches(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\d\s])(?!.*\s).{8,}").WithMessage("Password must  contain atleast one upper case, lower case alphabet, one digit, special character and length should be more than 8");
            RuleFor(x => x.ContactNumber).NotEmpty().WithMessage("Contact number is required").Matches(@"^(?:\+?91|0)?[789]\d{9}$").WithMessage("Provide correct contact number");
        }
    }
