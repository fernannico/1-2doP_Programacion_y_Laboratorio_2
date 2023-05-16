using ProductosNs;
using System.Text;

namespace Facturas
{
    public class Factura
    {
        private string nombreVendedor;
        private string nombreCliente;
        private decimal monto;
        private DateTime fecha;
        private List<Productos> productosList;

        public Factura(string nombreVendedor, string nombreCliente, decimal monto, List<Productos> productosList, DateTime fecha)
        {
            this.nombreVendedor = nombreVendedor;
            this.nombreCliente = nombreCliente;
            this.monto = monto;
            this.productosList = productosList;
            this.fecha = fecha;
        }

        private DateTime FechaPropiedad
        {
            get { return fecha; }
        }

        public decimal MontoPropiedad
        {
            get { return monto; }
        }

        public string VendedorPropiedad
        {
            get { return nombreVendedor;}
        }
        public string ClientePropiedad
        {
            get { return nombreCliente; }
        }

        public string MostrarFactura()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"fecha: {fecha}");
            sb.AppendLine($"nombre del vendedor: {nombreVendedor}");
            sb.AppendLine($"nombre del cliente: {nombreCliente}");
            sb.AppendLine(MostrarDetallesProductos(productosList));
            sb.AppendLine($"monto: ${monto}");

            return sb.ToString();
        }

        private string MostrarDetallesProductos(List<Productos> listaProductosComprados)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Productos p in listaProductosComprados)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"Factura del {FechaPropiedad}";
        }
    }
}