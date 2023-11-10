namespace CRM.API.Entidades
{
    public class UsuarioRol
    {
        public int codUsuario { get; set; }
        [StringLength(10)]
        public string idRol { get; set; }


        public USUARIO USUARIO { get; set; }

        public ROL ROL { get; set; }

    }
}