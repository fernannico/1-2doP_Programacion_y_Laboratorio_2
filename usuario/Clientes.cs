using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuarios
{
    public class Cliente : Usuario
    {
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

        public override void EfectuarCompraventa(decimal importe)
        {
            base.EfectuarCompraventa(importe);
            GastoMaximoPropiedad = GastoMaximoPropiedad - importe;
        }
    }
}
