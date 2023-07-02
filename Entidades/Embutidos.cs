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
        public Embutido(int id, float precioPorKg, int kgEnStock, string tipoEmbutido) : base(id, precioPorKg, kgEnStock)
        {
            this.tipoEmbutido = tipoEmbutido;
        }

        public override int Id { get { return id; } }

        /// <summary>
        /// para recibir y asignar el tipo de embutido
        /// </summary>
        public string TipoEmbutido
        {
            get { return tipoEmbutido; }
            set { tipoEmbutido = value; }
        }

        /// <summary>
        /// para recibir y asignar el stock 
        /// </summary>
        public override int KgEnStock
        {
            get { return kgEnStock; }
            set { kgEnStock = value; }
        }

        /// <summary>
        /// para recibir y asignar el precio del embutido
        /// </summary>
        public override float Precio
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
            sbDetalles.AppendLine($"Tipo de embutido {TipoEmbutido}");
            sbDetalles.AppendLine($"Kg en stock: {KgEnStock}");
            sbDetalles.AppendLine($"Precio por kg: {Precio}");

            return sbDetalles.ToString();
        }
        public override string ToString()
        {
            return $"{TipoEmbutido} - ${precioPorKg}/Kg";
        }
    }
}
