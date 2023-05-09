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

        public string TipoEmbutidoPropiedad
        {
            get { return tipoEmbutido; }
            set { tipoEmbutido = value; }
        }
        public override int KgEnStockPropiedad
        {
            get { return kgEnStock; }
            set { kgEnStock = value; }
        }
        public override float PrecioPropiedad
        {
            get { return precioPorKg; }
            set { precioPorKg = value; }
        }

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
