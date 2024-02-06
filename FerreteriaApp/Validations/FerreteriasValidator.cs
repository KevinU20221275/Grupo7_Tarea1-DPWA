using FerreteriaApp.Models;
using FluentValidation;

namespace FerreteriaApp.Validations
{
    public class FerreteriasValidator : AbstractValidator<FerreteriaModel>
    {
        public FerreteriasValidator()
        {
            RuleFor(ferreteria => ferreteria.Name)
                .NotEmpty().WithMessage("El nombre es obligarotio")
                .NotNull()
                .MinimumLength(5).WithMessage("Debe ingresar almenos 5 caracteres")
                .MaximumLength(150).WithMessage("Solo puede ingresar un maximo de 150 caracteres");

            RuleFor(ferreteria => ferreteria.Address)
                .NotEmpty().WithMessage("La Dirrecion es obligarotia")
                .NotNull()
                .MinimumLength(5).WithMessage("Debe ingresar almenos 5 caracteres")
                .MaximumLength(250).WithMessage("Solo puede ingresar un maximo de 250 caracteres");

            RuleFor(ferreteria => ferreteria.Phone)
                .NotEmpty().WithMessage("El numero de Telefono es obligarotio")
                .NotNull()
                .MinimumLength(8).WithMessage("Debe ingresar almenos 8 digitos")
                .MaximumLength(25).WithMessage("Puede ingresar como maximo 25 digitos");

            RuleFor(ferreteria => ferreteria.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio")
                .NotNull()
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido")
                .MaximumLength(50).WithMessage("Puede ingresar como máximo 50 caracteres");
        }
    }
}
