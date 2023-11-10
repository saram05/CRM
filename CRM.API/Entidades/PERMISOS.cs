using System.ComponentModel.DataAnnotations;

namespace CRM.API.Entidades
{
    public class ROL
    {

        [StringLength(10)]
        public int IdPermiso { get; set; }
        [StringLength(50)]
        public string DESCRIPCION { get; set; }
        [Required]





    }
}