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

        /// <summary>
        /// para recibir la fecha que se realiza la factura
        /// </summary>
        private DateTime FechaPropiedad
        {
            get { return fecha; }
        }

        /// <summary>
        /// para recibir el monto total de la factura
        /// </summary>
        public decimal MontoPropiedad
        {
            get { return monto; }
        }

        /// <summary>
        /// para recibir quien efectuó la venta
        /// </summary>
        public string VendedorPropiedad
        {
            get { return nombreVendedor;}
        }

        /// <summary>
        /// para recibir quien efectuó las compras
        /// </summary>
        public string ClientePropiedad
        {
            get { return nombreCliente; }
        }

        /// <summary>
        /// para realizar una descripcion detallada de la factura
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// para mostrar los productos comprados 
        /// </summary>
        /// <param name="listaProductosComprados"></param>
        /// <returns></returns>
        private string MostrarDetallesProductos(List<Productos> listaProductosComprados)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Productos p in listaProductosComprados)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// para mostrar una descripcion mas sencilla de la factura, con menos detalles
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Factura del {FechaPropiedad}";
        }
    }
}