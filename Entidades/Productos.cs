using System.Text;
using System.Xml.Serialization;

namespace ProductosNs
{
    [XmlInclude(typeof(Carne))]
    [XmlInclude(typeof(Embutido))]
    public abstract class Productos
    {
        protected int id;
        protected float precioPorKg;
        protected int kgEnStock;

        public Productos()
        {

        }

        public Productos(int id, float precioPorKg, int kgEnStock)
        {
            this.id = id;
            this.precioPorKg = precioPorKg;
            this.kgEnStock = kgEnStock;
        }

        public abstract int Id { get; }
        public abstract float Precio { get; set; }
        public abstract int KgEnStock { get; set; }
        public abstract string MostrarDetalle();
    }
}