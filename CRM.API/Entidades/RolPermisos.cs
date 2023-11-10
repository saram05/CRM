namespace CRM.API.Entidades
{
    public class RolPermisos
    {
        public int idRol { get; set; }      
        public string idPermiso { get; set; }


        public PERMISO PERMISO { get; set; }

        public ROL ROL { get; set; }

    }
}