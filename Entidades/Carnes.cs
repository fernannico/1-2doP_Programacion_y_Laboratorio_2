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

        /// <summary>
        /// para obtener o asignar el tipo de animal de la carne
        /// </summary>
        public string AnimalPropiedad
        {
            get { return animal; }
            set { animal = value; }
        }

        /// <summary>
        /// para obtener o asignar el precio de la carne
        /// </summary>
        public override float PrecioPropiedad
        {
            get { return precioPorKg; }
            set { precioPorKg = value; }
        }

        /// <summary>
        /// para obtener o asignar el corte de la carne
        /// </summary>
        public string CortePropiedad
        {
            get { return corte; }
            set { corte = value; }
        }

        /// <summary>
        /// para obtener o asignar el stock
        /// </summary>
        public override int KgEnStockPropiedad
        {
            get { return kgEnStock; }
            set { kgEnStock = value; }
        }

        /// <summary>
        /// para mostrar una descripcion mas detallada de la carne 
        /// </summary>
        /// <returns></returns>
        public override string MostrarDetalle()
        {
            StringBuilder sbDetalles = new StringBuilder();
            sbDetalles.AppendLine($"Carne de {AnimalPropiedad}");
            sbDetalles.AppendLine($"Corte: {CortePropiedad}");
            sbDetalles.AppendLine($"Kg en stock: {KgEnStockPropiedad}");
            sbDetalles.AppendLine($"Precio por kg: {PrecioPropiedad}");

            return sbDetalles.ToString();
        }

        /// <summary>
        /// para mostrar una descripcion mas sencilla de la carne
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{CortePropiedad} de {AnimalPropiedad} - ${precioPorKg}/Kg";
        }

        /// <summary>
        /// para convertir el tipo de dato Carne al tipo de dato decimal, retornando el precio por kg correspondiente
        /// </summary>
        /// <param name="item"></param>
        public static explicit operator decimal(Carne item)
        {
            return (decimal)item.precioPorKg;
        }
    }
}
