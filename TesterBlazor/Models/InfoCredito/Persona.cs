using System.ComponentModel.DataAnnotations;

namespace TesterBlazor.Models.InfoCredito
{
    public class Persona
    {
        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        public int? NroDocumento { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        public string Nombre1 { get; set; } = string.Empty;

        public string? Nombre2 { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        public string Apellido1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "El segundo apellido es obligatorio.")]
        public string Apellido2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public DireccionPersona Direccion { get; set; } = new DireccionPersona();
        public ContactoPersona Contacto { get; set; } = new ContactoPersona();
        public int? IdRelacionEnNucleo { get; set; }
    }
}