﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string CreatedDate { get; set; } = null!;

        [Display(Name = "Fecha fin")]
        [MaxLength(4, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string FinishDate { get; set; } = null!;

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Value { get; set; } = 0!;


        public Client? Client { get; set; }

        public ICollection<Activity>? Activities { get; set; }

        public int CleintId { get; set; }
    }
}