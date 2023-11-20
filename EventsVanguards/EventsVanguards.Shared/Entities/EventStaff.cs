using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class EventStaff
    {

        public int Id { get; set; }

        [Display(Name = "Personal del Evento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 caracteres")] 
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Rol en el Evento")]
        [MaxLength(100, ErrorMessage = "El campo {1} debe contener únicamente 100 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        public string EventRole{ get; set; }

        [Display(Name = "Información de Contacto")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo {2} es obligatorio")]

        public string ContactInfo { get; set; }
        public ICollection<MeetingStaff> MeetingStaffs { get; set; }

    }
}
