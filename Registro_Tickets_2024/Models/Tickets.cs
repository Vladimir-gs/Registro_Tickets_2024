using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Tickets_2024.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public DateTime Fecha { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una Prioridad")]
        [ForeignKey("Prioridades")]
        public int PrioridadId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecciona un Cliente")]
        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }

        public int SistemaId { get; set; }

        [Required(ErrorMessage = "El campo Solicitado por es obligatorio")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo debe contener letras.")]
        public string? Solicitadopor { get; set; }

        [Required(ErrorMessage = "El campo Asunto es obligatorio")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string? Descripcion { get; set; }
    }
}
