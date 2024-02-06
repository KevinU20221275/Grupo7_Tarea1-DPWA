using System.ComponentModel.DataAnnotations;

namespace FerreteriaApp.Models
{
    public class FerreteriaModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de Sucursal")]
        public string? Name { get; set; }

        [Display(Name = "Direccion")]
        public string? Address { get; set; }

        [Display(Name = "Telefono")]
        public string? Phone { get; set; }

        [Display(Name = "Correo Electronico")]
        public string? Email { get; set; }
    }
}
