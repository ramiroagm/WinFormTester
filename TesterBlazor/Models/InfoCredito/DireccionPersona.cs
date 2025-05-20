using System.ComponentModel.DataAnnotations;

namespace TesterBlazor.Models.InfoCredito
{
    public class DireccionPersona
    {
        [Required(ErrorMessage = "El país es obligatorio.")]
        public string Pais { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El barrio/localidad es obligatorio.")]
        public string BarrioLocalidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "La calle es obligatoria.")]
        public string Calle { get; set; } = string.Empty;
        public string? NumeroPuerta { get; set; }
        public string? NumeroApartamento { get; set; }
        public string? Manzana { get; set; }
        public string? Solar { get; set; }
        public string? Observaciones { get; set; }
    }
}
