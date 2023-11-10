namespace CRM.API.Entidades
{
    public class PeliculasGeneros
    {
        public int codUsuario { get; set; }
        [StringLength(10)]
        public string idRol { get; set; }


        public USUARIO USUARIO { get; set; }
       
        public ROL ROL { get; set; }

    }
}