using Facturas;
using ProductosNs;

namespace usuarios
{
    public abstract class Usuario
    {
        protected decimal dinero;
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

        public virtual void EfectuarCompraventa(decimal importe){ }
    }

}