using Facturas;
using ProductosNs;

namespace usuarios
{
    public abstract class Usuario
    {
        protected string mail;
        protected string contrasena;

        protected Usuario(string mail, string contrasena)
        {
            this.mail = mail;
            this.contrasena = contrasena;
        }

        public virtual string MailPropiedad
        {
            get { return mail; }
        }

        public virtual string PwdPropiedad
        {
            get { return contrasena; }
        }

        public static bool operator ==(Usuario usuario1, Usuario usuario2)
        {
            if (usuario1 is not null && usuario2 is not null)
            {
                return usuario1.MailPropiedad == usuario2.MailPropiedad;
            }
            return false;
        }

        public static bool operator !=(Usuario usuario1, Usuario usuario2)
        {
            return !(usuario1 == usuario2);
        }

        public override bool Equals(object obj)
        {
            Usuario usuario = obj as Usuario;
            return usuario is not null && this == usuario;
        }
    }

}