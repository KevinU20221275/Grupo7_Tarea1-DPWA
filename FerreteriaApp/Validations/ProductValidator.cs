using FerreteriaApp.Models;
using FluentValidation;

namespace FerreteriaApp.Validations
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductName)
                .NotEmpty().WithMessage("El nombre del producto es obligarotio")
                .MaximumLength(150).WithMessage("Solo puede ingresar un maximo de 150 caracteres");

            RuleFor(product => product.ProductDescription)
                .NotEmpty().WithMessage("La Descripcion es obligarotia")
                .MaximumLength(250).WithMessage("Solo puede ingresar un maximo de 250 caracteres");

            RuleFor(product => product.ProductCategory)
                .NotEmpty().WithMessage("Debe ingresar la Categoria");

            RuleFor(product => product.Stock)
                .NotEmpty().WithMessage("Debe Ingresar la Cantidad de Producto")
                .GreaterThan(-1).WithMessage("La cantidad debe ser al menos 0");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Debe Ingresar el Precio del Producto")
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0");

            RuleFor(product => product.ExpirationDate)
                .NotEmpty().WithMessage("Debe Ingresar la fecha de Vencimiento");
        }
    }
}
