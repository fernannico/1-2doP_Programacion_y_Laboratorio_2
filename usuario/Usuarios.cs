using Facturas;
using ProductosNs;

namespace usuarios
{
    public abstract class Usuario
    {
        protected decimal dinero;
        protected string mail;
        protected string contrasena;

        protected Usuario(string mail, string contrasena)
        {
            this.mail = mail;
            this.contrasena = contrasena;
        }

        public virtual string MailPropiedad
        {
            get { return mail; }
        }

        public virtual string PwdPropiedad
        {
            get { return contrasena; }
        }

        public virtual void EfectuarCompraventa(decimal importe){ }
    }

    public class Vendedor : Usuario
    {
        //● Puede vender productos seleccionando a un cliente de la lista de clientes.
        //● Puede ver los detalles de los productos
        //● Puede reponer los productos de la heladera principal
        //● Fijar precios por kilo
        //● Fijar tipos de cortes de carnes

        public Vendedor(string mail, string contrasena) : base(mail, contrasena)
        {

        }

        public override string ToString()
        {
            return $"Vendedor - {mail}";
        }
        public decimal DineroPropiedad
        {
            get { return dinero; }
            set { dinero = value; }
        }

        public void FijarAnimal(Carne carneItem, string animal)
        {
            if (carneItem is not null && animal is not null)
            {
                carneItem.AnimalPropiedad = animal;
            }
        }
        public void FijarCorteDeCarne(Carne carneItem, string corte)
        {
            if( carneItem is not null && corte is not null)
            {
                carneItem.CortePropiedad = corte;
            }
        }
        public void FijarTipoEmbutido(Embutido embutidoItem, string tipoEmbutido)
        {
            if( embutidoItem is not null && tipoEmbutido is not null)
            {
                embutidoItem.TipoEmbutidoPropiedad = tipoEmbutido;
            }
        }
        public void FijarPrecioKg(Productos producto, float nuevoPrecio)
        {
            if (producto is not null && nuevoPrecio > 0) 
                producto.PrecioPropiedad = nuevoPrecio;
        }
        public void ReponerProductos(Productos producto, int kgAReponer)
        {
            producto.KgEnStockPropiedad = producto.KgEnStockPropiedad + kgAReponer;
        }
        public string VerDetallesProducto(Productos producto)
        {
            return producto.MostrarDetalle();
        }

        public override void EfectuarCompraventa(decimal importe)
        {
            base.EfectuarCompraventa(importe);
            DineroPropiedad = DineroPropiedad - importe;
        }

        public Factura HacerFactura(string nombreVendedor, string nombreCliente, decimal monto, List<Productos> productosList)
        {
            Factura factura = new Factura(nombreVendedor, nombreCliente, monto, productosList, DateTime.Now); 
            return factura;
        }

    }

    public class Cliente : Usuario
    {
        public Cliente(string mail, string contrasena) : base(mail, contrasena)
        {

        }
        public decimal GastoMaximoPropiedad
        {
            get { return dinero; }
            set { dinero = value; }
        }
        public override string ToString()
        {
            return $"Cliente - {mail}";
        }

        public override void EfectuarCompraventa(decimal importe)
        {
            base.EfectuarCompraventa(importe);
            GastoMaximoPropiedad = GastoMaximoPropiedad - importe;
        }
    }
}