using System.Text;

namespace ProductosNs
{
    public abstract class Productos
    {
        protected float precioPorKg;
        protected int kgEnStock;

        public Productos(float precioPorKg, int kgEnStock)
        {
            this.precioPorKg = precioPorKg;
            this.kgEnStock = kgEnStock;
        }

        public abstract float PrecioPropiedad { get; set; }
        public abstract int KgEnStockPropiedad { get; set; }
        public abstract string MostrarDetalle();
    }
}