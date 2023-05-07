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
        }

        public override float PrecioPropiedad
        {
            get { return precioPorKg; }
            set { precioPorKg = value; }
        }

        public override int KgEnStockPropiedad 
        {
            get { return kgEnStock; }
            set { kgEnStock = value; }
        }

        public string CortePropiedad
        {
            get { return corte; }
            set { corte = value; }
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
            return $"{CortePropiedad} de {AnimalPropiedad} - {kgEnStock} Kilos";
        }
    }

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
            return $"{TipoEmbutidoPropiedad} - {KgEnStockPropiedad} Kilos";
        }
    }

}