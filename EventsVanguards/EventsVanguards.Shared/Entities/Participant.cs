using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVanguards.Shared.Entities
{
    public class Participant
    {
        public int Id { get; set; }//Primary key, identity(1,1)

        //Etiquetas
        [Display(Name = "Participante")]//Son etiquetas del nombre del campo
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Poner campo obligatorio
        public string Name { get; set; } //? (Indica que hace un salto de nulos)

        [Display(Name = "Apellido")]

        [MaxLength(100, ErrorMessage = "El campo {1} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        public string Last_Name { get; set; }

        [Display(Name = "Correo Electronico")]
        [MaxLength(100, ErrorMessage = "El campo {2} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {2} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Telefono")]
        [MaxLength(100, ErrorMessage = "El campo {3} debe contener únicamente 100 " + "caracteres")]
        [Required(ErrorMessage = "El campo {3} es obligatorio")]
        public string Phone { get; set; }

        public ICollection<Register> Registers { get; set; } //quien lleva el collection es la entidad padre de la que recibe la foranea    }
    }
}