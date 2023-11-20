using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class Organizer
    {
        public int Id { get; set; }//Primary key, identity(1,1)

        //Etiquetas
        [Display(Name = "Organizador")]//Son etiquetas del nombre del campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Poner campo obligatorio
        public string Name { get; set; } //? (Indica que hace un salto de nulos)

        [Display(Name = "Organizacion")]
        [MaxLength(100, ErrorMessage = "El campo {1} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        public string Organization { get; set; }

        [Display(Name = "Contacto de informacion")]
        [MaxLength(100, ErrorMessage = "El campo {2} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {2} es obligatorio")]
        public string Contact_Info { get; set; }


        public ICollection<Meeting> Meetings { get; set; }

    }
}