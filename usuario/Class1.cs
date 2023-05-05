namespace usuarios
{
    public abstract class Usuario
    {
        protected string mail;
        protected string contrasena;

        public Usuario(string mail, string contrasena)
        {
            this.mail = mail;
            this.contrasena = contrasena;
        }
        public abstract string MailPropiedad { get; }
        public abstract string PwdPropiedad { get; }
    }

    public class Vendedor : Usuario
    {
        public Vendedor(string mail, string contrasena) : base(mail, contrasena)
        {

        }

        public override string MailPropiedad
        {
            get { return mail; }
        }

        public override string PwdPropiedad
        {
            get { return contrasena; }
        }

        public override string ToString()
        {
            return mail;
        }
    }

    public class Cliente : Usuario
    {
        public Cliente(string mail, string contrasena) : base(mail, contrasena)
        {

        }
        public override string MailPropiedad
        {
            get { return mail; }
        }
        public override string PwdPropiedad
        {
            get { return contrasena; }
        }

        public override string ToString()
        {
            return mail;
        }
    }
}