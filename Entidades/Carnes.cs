using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosNs
{
    public class Carne : Productos
    {
        private string animal;
        private string corte;

        public Carne(float precioPorKg, int kgEnStock, string animal, string corte) : base(precioPorKg, kgEnStock)
        {
            this.animal = animal;
            this.corte = corte;
        }
        public string AnimalPropiedad
        {
            get { return animal; }
            set { animal = value; }
        }

        public override float PrecioPropiedad
        {
            get { return precioPorKg; }
            set { precioPorKg = value; }
        }
        public string CortePropiedad
        {
            get { return corte; }
            set { corte = value; }
        }
        public override int KgEnStockPropiedad
        {
            get { return kgEnStock; }
            set { kgEnStock = value; }
        }

        public override string MostrarDetalle()
        {
            StringBuilder sbDetalles = new StringBuilder();
            sbDetalles.AppendLine($"Carne de {AnimalPropiedad}");
            sbDetalles.AppendLine($"Corte: {CortePropiedad}");
            sbDetalles.AppendLine($"Kg en stock: {KgEnStockPropiedad}");
            sbDetalles.AppendLine($"Precio por kg: {PrecioPropiedad}");

            return sbDetalles.ToString();
        }

        public override string ToString()
        {
            return $"{CortePropiedad} de {AnimalPropiedad} - ${precioPorKg}/Kg";
        }

        public static explicit operator decimal(Carne item)
        {
            return (decimal)item.precioPorKg;
        }
    }
}
