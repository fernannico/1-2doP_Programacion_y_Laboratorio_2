using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuarios
{
    public class Cliente : Usuario
    {
        private decimal dinero;
        public Cliente(string mail, string contrasena) : base(mail, contrasena)
        {

        }
        public Cliente(string mail, string contrasena, decimal dinero) : base(mail, contrasena)
        {
            this.dinero = dinero;
        }
        public decimal GastoMaximoPropiedad
        {
            get { return dinero; }
            set { dinero = value; }
        }
        public override string ToString()
        {
            return $"Cliente - {mail}";
        }

        public void EfectuarCompraventa(decimal importe)
        {
            GastoMaximoPropiedad -= importe;
        }
    }
}
