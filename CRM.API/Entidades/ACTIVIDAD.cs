using System.ComponentModel.DataAnnotations;

namespace CRM.API.Entidades
{
    public class ACTIVIDAD
    {


        
        public int IdActividad { get; set; }
        [Required]

        [StringLength(100)]
        public string DESCRIPCION { get; set; }
        public string OBSERVACIONES { get; set; }
        [StringLength(30)]
        public string TIPO { get; set; }
        [StringLength(10)]
        public string FECHA_INICIO{ get; set; }
        public string FECHA_FINAL{ get; set; }
        public string HORA_INICIO{ get; set; }
        public string HORA_FINAL{ get; set; }


        public int idCliente { get; set; }

        public CLIENTE CLIENTE { get; set; }

        public ACTIVIDAD ACTIVIDAD { get; set; }




    }
}