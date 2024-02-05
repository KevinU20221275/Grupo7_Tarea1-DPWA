using System.ComponentModel.DataAnnotations;

namespace FerreteriaApp.Models
{
    public class FerreteriaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligarotio")]
        [MinLength(5, ErrorMessage = "Debe ingresar almenos 5 letras")]
        [MaxLength(150, ErrorMessage = "Puede ingresar como maximo 150 letras")]
        [Display(Name = "Nombre de Sucursal")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "La Dirrecion es obligarotia")]
        [Length(5, 250)]
        [Display(Name = "Direccion")]
        public string? Address { get; set; }


        [Required(ErrorMessage = "El numero de Telefono es obligarotio")]
        [MinLength(5, ErrorMessage = "Debe ingresar almenos 8 digitos")]
        [MaxLength(25, ErrorMessage = "Puede ingresar como maximo 25 digitos")]
        [Display(Name = "Telefono")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [MaxLength(50, ErrorMessage = "Puede ingresar como máximo 50 caracteres")]
        public string? Email { get; set; }
    }
}
