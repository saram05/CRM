using System.ComponentModel.DataAnnotations;

namespace CRM.API.Entidades
{
    public class ROL
    {

        [StringLength(10)]
        public int IdRol { get; set; }
        [StringLength(50)]
        public string DESCRIPCION { get; set; }
        public string FECHA_CREACION { get; set; }
        [Required]





    }
}