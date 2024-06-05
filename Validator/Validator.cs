using FluentValidation;
using FiltroApi.Models;

namespace FluentValidation{
    public class OwnerValidator : AbstractValidator<Owner>{
        public OwnerValidator(){
            RuleFor(x => x.Names)
                .NotEmpty().WithMessage("This field is required")
                .MinimumLength(3).WithMessage("Names must be at least 3 characters")
                .MaximumLength(50).WithMessage("Names must be at least 50 characters");

            RuleFor(x => x.LastNames)
                .NotEmpty().WithMessage("This field is required")
                .MinimumLength(3).WithMessage("LastNames must be at least 3 characters")
                .MaximumLength(50).WithMessage("LastNames must be at least 50 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("This field is required")
                .MinimumLength(5).WithMessage("Address must be at least 5 characters")
                .MaximumLength(30).WithMessage("Address must be at least 30 characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("This field is required")
                .MinimumLength(6).WithMessage("Phone must be at least 6 characters")
                .MaximumLength(25).WithMessage("Phone must be at least 25 characters");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email address")
                .NotEmpty().WithMessage("This field is required")
                .MinimumLength(10).WithMessage("Email must be at least 10 characters")
                .MaximumLength(100).WithMessage("Email must be at least 100 characters");
            
        }
    }

    public class PetValidator : AbstractValidator<Pet>{
        public PetValidator(){
            RuleFor(x => x.Names)
                .NotEmpty().WithMessage("This field is required")
                .MinimumLength(3).WithMessage("Names must be at least 3 characters")
                .MaximumLength(25).WithMessage("Names must be at least 25 characters");
            
            RuleFor(x => x.Specie)
                .NotEmpty().WithMessage("This field is required")
                .Must(x => x.Equals("Perro", StringComparison.OrdinalIgnoreCase) || x.Equals("Gato", StringComparison.OrdinalIgnoreCase) || x.Equals("Pajaro", StringComparison.OrdinalIgnoreCase))
                .WithMessage("This field must be 'Perro' or 'Gato' or 'Pajaro'");

            RuleFor(x => x.Race)
                .NotEmpty().WithMessage("This field is required")
                .Must(x => x.Equals("Angora", StringComparison.OrdinalIgnoreCase) || x.Equals("Maicoon", StringComparison.OrdinalIgnoreCase) || x.Equals("Pastor aleman", StringComparison.OrdinalIgnoreCase) || x.Equals("Labrador", StringComparison.OrdinalIgnoreCase) || x.Equals("Cacatua", StringComparison.OrdinalIgnoreCase))
                .WithMessage("This field must be 'Angora' , 'Maicoon' , 'Pastor aleman' , 'Labrador' , 'Cacatua' ");

            RuleFor(x =>x.DateBirth)
                .NotEmpty().WithMessage("This field is required") 
                .WithErrorCode("The format of the birth date must be 'YYYY-MM-DD'");  

            RuleFor(x => x.OwnerId)
                .NotEmpty().WithMessage("This field is required");

            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage("This field is required");
        }
    }

    public class QuoteValidator: AbstractValidator<Quote>{
        public QuoteValidator(){
            RuleFor(x =>x.Date)
                .NotEmpty().WithMessage("This field is required") 
                .WithErrorCode("The format of the birth date must be 'YYYY-MM-DD'");  

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("This field is required");

            RuleFor(x => x.PetId)
                .NotEmpty().WithMessage("This field is required")
                .GreaterThanOrEqualTo(1).WithMessage("The id are not negative");
            
            RuleFor(x => x.VetId)
                .NotEmpty().WithMessage("This field is required")
                .GreaterThanOrEqualTo(1).WithMessage("The id are not negative");

        }
    }
}