using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class Meeting
    {
        public int Id { get; set; }//Primary key, identity(1,1)

        //Etiquetas
        [Display(Name = "Evento")]//Son etiquetas del nombre del campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Poner campo obligatorio
        public string Name { get; set; } //? (Indica que hace un salto de nulos)

        [RequiredAttribute]
        [Display(Name = "Fecha")]//Son etiquetas del nombre del campo
        public DateTime DateEvent { get; set; }

        [RequiredAttribute]
        [Display(Name = "Ubicacion")]//Son etiquetas del nombre del campo
        [MaxLength(256, ErrorMessage = "La {0} debe contener únicamente un maximo de 256 caracteres")]
        public string Location { get; set; }

        [Display(Name = "Descripcion")]//Son etiquetas del nombre del campo
        [MaxLength(256, ErrorMessage = "La {0} debe contener únicamente un maximo de 256 caracteres")]
        public string Description { get; set; }

        [Display(Name = "Tipo de Evento")]//Son etiquetas del nombre del campo
        [MaxLength(256, ErrorMessage = "La {0} debe contener únicamente un maximo de 256 caracteres")]
        public string EventType { get; set; }

        [RequiredAttribute]
        [Display(Name = "Hora")]//Son etiquetas del nombre del campo
        public DateTime Hour { get; set; }

        public Organizer Organizer { get; set; }
        public int OrganizerId { get; set; }
        public ICollection<MeetingStaff> MeetingStaffs { get; set; }
        public ICollection<MeetingSponsor> MeetingSponsors { get; set; }
        public ICollection<Register> Registers { get; set; }

    }

}
