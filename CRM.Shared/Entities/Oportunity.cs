using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.Shared.Entities
{
    public class Oportunity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Fecha fin")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FinishDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Value { get; set; }
        public int ClientId { get; set; }

    }
}
