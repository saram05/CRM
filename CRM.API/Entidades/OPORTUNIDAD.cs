using System.ComponentModel.DataAnnotations;

namespace CRM.API.Entidades
{
    public class OPORTUNIDAD
    {



        public int IdOportunidad { get; set; }
        [Required]
        public double VALOR { get; set; }

        [StringLength(50)]
        public string NOMBRE { get; set; }
        [StringLength(10)]
        public string FECHA_CREACION{ get; set; }
        public string FECHA_INICIO{ get; set; }
        public string FECHA_FINAL{ get; set; }
        public string idActividad{ get; set; }

        public int idCliente { get; set; }

        public CLIENTE CLIENTE { get; set; }

        public ACTIVIDAD ACTIVIDAD { get; set; }




    }
}