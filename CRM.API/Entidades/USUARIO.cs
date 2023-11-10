using System.ComponentModel.DataAnnotations;

namespace CRM.API.Entidades
{
    public class USUARIO
    {

        public int CODIGO { get; set; }
        [StringLength(30)]
        public string NOMBRE { get; set; }
        public string CONTRASENA { get; set; }
        [Required]





    }
}