using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class Register
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del Evento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NameEvent { get; set; }

        [Display(Name = "Tipo de Registro(por ejemplo, preinscrito, en el lugar)")]
        [MaxLength(220, ErrorMessage = "El campo {1} debe contener únicamente 220 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        public string RegistType { get; set; }

        [Display(Name = "Estado del Pago")]
        [MaxLength(100, ErrorMessage = "El campo {2} debe contener únicamente 100 caracteres")]
        [Required(ErrorMessage = "El campo {2} es obligatorio")]
        public string PaymentStatus { get; set; }

        [Display(Name = "Información de Acreditación")]
        [MaxLength(250, ErrorMessage = "El campo {3} debe contener únicamente 250 caracteres")]
        [Required(ErrorMessage = "El campo {3} es obligatorio")]
        public string CredentialingInf { get; set; }

        public Participant Participant { get; set; } //esta se envia porque se necesita tener cualquier campo que tenga la entidad padre
        public int IdParticipant { get; set; }
        public Meeting Meeting { get; set; }
        public int IdMeeting { get; set; }  
    }
}