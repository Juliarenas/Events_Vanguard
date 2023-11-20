using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class Sponsor
    {
        public int Id { get; set; }//Primary key, identity(1,1)

        //Etiquetas
        [Display(Name = "Nombre Empresa")]//Son etiquetas del nombre del campo
        [MaxLength(256, ErrorMessage = "El campo {0} debe contener únicamente 256 " + "caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Poner campo obligatorio
        public string Name { get; set; } //? (Indica que hace un salto de nulos)

        [RequiredAttribute]
        [Display(Name = "Tipo de Patrocinio")]//Son etiquetas del nombre del campo
        [MaxLength(256, ErrorMessage = "El {0} debe contener únicamente un maximo de 256 caracteres")]
        public string Type_Sponsorship { get; set; }  

        [RequiredAttribute]
        [Display(Name = "Informacion de contacto")]//Son etiquetas del nombre del campo
        [MaxLength(950, ErrorMessage = "La {0} debe contener únicamente un maximo de 950 caracteres")]
        public string Contact_inf { get; set; }

        public ICollection<MeetingSponsor> MeetingSponsors { get; set; }


    }
}
