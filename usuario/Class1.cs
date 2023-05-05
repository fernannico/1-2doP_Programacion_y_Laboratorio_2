namespace usuarios
{
    public abstract class usuario
    {
        protected string mail;
        protected string contraseña;

        public usuario()
        {
            this.mail = "";
            this.contraseña = "";
        }

        public abstract string mailPropiedad
        {
            get;
        }

    }

    public class vendedor : usuario
    {
        public vendedor()
        {

        }

        public override string mailPropiedad
        {
            get
            {
                return mail;
            }
        } 
    }

    public class cliente : usuario
    {
        public cliente()
        {

        }
        public override string mailPropiedad
        {
            get
            {
                return mail;
            }
        }

    }
}