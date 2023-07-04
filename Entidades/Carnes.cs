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

        public Carne()
        {

        }
        public Carne(int id, float precioPorKg, int kgEnStock, string animal, string corte) : base(id, precioPorKg, kgEnStock)
        {
            this.id = id;
            this.animal = animal;
            this.corte = corte;
        }
        public Carne(float precioPorKg, int kgEnStock, string animal, string corte) : base()
        {
            this.precioPorKg = precioPorKg;
            this.kgEnStock = kgEnStock;
            this.animal = animal;
            this.corte = corte;
        }

        public override int Id{ get { return id; } }

        /// <summary>
        /// para obtener o asignar el tipo de animal de la carne
        /// </summary>
        public string Animal
        {
            get { return animal; }
            set { animal = value; }
        }

        /// <summary>
        /// para obtener o asignar el precio de la carne
        /// </summary>
        public override float Precio
        {
            get { return precioPorKg; }
            set { precioPorKg = value; }
        }

        /// <summary>
        /// para obtener o asignar el corte de la carne
        /// </summary>
        public string Corte
        {
            get { return corte; }
            set { corte = value; }
        }

        /// <summary>
        /// para obtener o asignar el stock
        /// </summary>
        public override int KgEnStock
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
            sbDetalles.AppendLine($"Carne de {Animal}");
            sbDetalles.AppendLine($"Corte: {Corte}");
            sbDetalles.AppendLine($"Kg en stock: {KgEnStock}");
            sbDetalles.AppendLine($"Precio por kg: {Precio}");

            return sbDetalles.ToString();
        }

        /// <summary>
        /// para mostrar una descripcion mas sencilla de la carne
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Corte} de {Animal} - ${precioPorKg}/Kg";
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
