using CausaViva.DTOs.UserMenu;

namespace CausaViva.DTOs.SeguridadLoginUsuario
{
    public class SeguridadLoginDTO
    {
        public Int32 IdUser { get; set; }
        public Int32 IdUserType { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public List<UserMenuDTO> Menus { get; set; } = new List<UserMenuDTO>();
    }
}
