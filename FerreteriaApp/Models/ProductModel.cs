using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FerreteriaApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        public string? ProductName { get; set; }

        [Display(Name = "Descripcion")]
        public string? ProductDescription { get; set; }

        [Display(Name = "Categoria")]
        public string? ProductCategory { get; set; }

        [Display(Name = "Existencias")]
        public int? Stock { get; set; }

        [Display(Name = "Precio")]
        public double? Price { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        public string? ExpirationDate { get; set; }
    }
}
