using System.ComponentModel.DataAnnotations;

namespace CRM.API.Entidades
{
    public class CLIENTE
    {


        
        public int IdCliente { get; set; }
        [Required]
        public int CEDULA { get; set; }

        [StringLength(50)]
        public string NOMBRE { get; set; }
        public string DIRECCION{ get; set; }
        public string CORREO{ get; set; }

        public int TELEFONO { get; set; }

        public int CodUsuario { get; set; }

        public USUARIO USUARIO { get; set; }




    }
}
