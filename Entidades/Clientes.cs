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

        /// <summary>
        /// para obtener o asignar el dinero del cliente
        /// </summary>
        public decimal GastoMaximoPropiedad
        {
            get { return dinero; }
            set { dinero = value; }
        }

        /// <summary>
        /// para mostrar una descripcion mas sencilla del cliente con su mail
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Cliente - {mail}";
        }

        /// <summary>
        /// para que el cliente haga el pago y se le descuente el dinero gastado
        /// </summary>
        /// <param name="importe"></param>
        public void EfectuarCompraventa(decimal importe)
        {
            GastoMaximoPropiedad -= importe;
        }
    }
}
