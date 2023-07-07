using Facturas;
using ProductosNs;

namespace usuarios
{
    public abstract class Usuario
    {
        protected int id;
        protected string mail;
        protected string contrasena;

        protected Usuario(int id, string mail, string contrasena)
        {
            this.id = id;
            this.mail = mail;
            this.contrasena = contrasena;
        }

        public virtual int Id { get { return id; } }

        /// <summary>
        /// para retornar el mail del usuario
        /// </summary>
        public virtual string MailPropiedad
        {
            get { return mail; }
        }

        /// <summary>
        /// para retornar la contraseña del usuario
        /// </summary>
        public virtual string PwdPropiedad
        {
            get { return contrasena; }
        }

        /// <summary>
        /// para comparar la igualdad de usuarios segun el criterio de mismo mail
        /// </summary>
        /// <param name="usuario1"></param>
        /// <param name="usuario2"></param>
        /// <returns></returns>
        public static bool operator ==(Usuario usuario1, Usuario usuario2)
        {
            if (usuario1 is not null && usuario2 is not null)
            {
                return usuario1.MailPropiedad == usuario2.MailPropiedad;
            }
            return false;
        }

        /// <summary>
        /// para comparar la desigualdad
        /// </summary>
        /// <param name="usuario1"></param>
        /// <param name="usuario2"></param>
        /// <returns></returns>
        public static bool operator !=(Usuario usuario1, Usuario usuario2)
        {
            return !(usuario1 == usuario2);
        }

        /// <summary>
        /// para determinar la igualdad de usuarios de la coleccion
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Usuario usuario = obj as Usuario;
            return usuario is not null && this == usuario;
        }
    }

}