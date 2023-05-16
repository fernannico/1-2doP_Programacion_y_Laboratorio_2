using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosNs
{
    public class Embutido : Productos
    {
        private string tipoEmbutido;
        public Embutido(float precioPorKg, int kgEnStock, string tipoEmbutido) : base(precioPorKg, kgEnStock)
        {
            this.tipoEmbutido = tipoEmbutido;
        }

        /// <summary>
        /// para recibir y asignar el tipo de embutido
        /// </summary>
        public string TipoEmbutidoPropiedad
        {
            get { return tipoEmbutido; }
            set { tipoEmbutido = value; }
        }

        /// <summary>
        /// para recibir y asignar el stock 
        /// </summary>
        public override int KgEnStockPropiedad
        {
            get { return kgEnStock; }
            set { kgEnStock = value; }
        }

        /// <summary>
        /// para recibir y asignar el precio del embutido
        /// </summary>
        public override float PrecioPropiedad
        {
            get { return precioPorKg; }
            set { precioPorKg = value; }
        }

        /// <summary>
        /// para mostrar los detalles del embutido
        /// </summary>
        /// <returns></returns>
        public override string MostrarDetalle()
        {
            StringBuilder sbDetalles = new StringBuilder();
            sbDetalles.AppendLine($"Tipo de embutido {TipoEmbutidoPropiedad}");
            sbDetalles.AppendLine($"Kg en stock: {KgEnStockPropiedad}");
            sbDetalles.AppendLine($"Precio por kg: {PrecioPropiedad}");

            return sbDetalles.ToString();
        }
        public override string ToString()
        {
            return $"{TipoEmbutidoPropiedad} - ${precioPorKg}/Kg";
        }
    }
}
