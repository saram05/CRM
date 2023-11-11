using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.Shared.Entities
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Observaciones")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Observations { get; set; } = null!;

        [Display(Name = "Fecha de inicio")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime CreatedDate { get; set; } = DateTime.Now!;

        [Display(Name = "Fecha fin")]
        [MaxLength(4, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public DateTime FinishDate { get; set; } = DateTime.Now!;
        public Oportunity? Oportunity{ get; set; }
        public int OportunityId { get; set; }
    }
}
