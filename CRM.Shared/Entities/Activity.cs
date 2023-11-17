using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Nombre")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Observaciones")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Observations { get; set; } = null!;

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Fecha fin")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FinishDate { get; set; } = DateTime.Now;

        [Display(Name = "Tipo")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Type { get; set; } = null!;
        public int OportunityId { get; set; }
    }
}
