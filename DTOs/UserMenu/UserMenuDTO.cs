namespace CausaViva.DTOs.UserMenu
{
    public class UserMenuDTO
    {
        public Int32 IdUserMenu { get; set; }
        public Int32 IdUserType { get; set; }
        public Int32 IdMenu { get; set; }
        public String Nombre { get; set; }
        public String Icono { get; set; }
        public String Ruta { get; set; }
        public Boolean Estado { get; set; }
    }
}
