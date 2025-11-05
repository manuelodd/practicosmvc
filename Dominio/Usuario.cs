namespace Dominio
{
    public class Usuario
    {
        public string Nombre { get; }
        public string Password { get; }
        public RolUsuario Rol { get; }

        public Usuario(string nombre, string password, RolUsuario rol)
        {
            Nombre = nombre;
            Password = password;
            Rol = rol;
        }

    }
}
