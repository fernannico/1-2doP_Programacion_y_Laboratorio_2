using Facturas;
using ProductosNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuarios
{
    public class Vendedor : Usuario
    {
        public Vendedor(string mail, string contrasena) : base(mail, contrasena)
        {

        }

        /// <summary>
        /// para pasar el vendedor a string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Vendedor - {mail}";
        }

        /// <summary>
        /// para que el vendedor pueda modificar el tipo de animal de la carne seleccionada
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="nuevoPrecio"></param>
        public void FijarAnimal(Carne carneItem, string animal)
        {
            if (carneItem is not null && animal is not null)
            {
                carneItem.AnimalPropiedad = animal;
            }
        }

        /// <summary>
        /// para que el vendedor pueda modificar el corte del tipo de dato Carne seleccionado
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="nuevoPrecio"></param>
        public void FijarCorteDeCarne(Carne carneItem, string corte)
        {
            if (carneItem is not null && corte is not null)
            {
                carneItem.CortePropiedad = corte;
            }
        }

        /// <summary>
        /// para que el vendedor pueda modificar el nombre del tipo de dato embutido seleccionado
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="nuevoPrecio"></param>
        public void FijarTipoEmbutido(Embutido embutidoItem, string tipoEmbutido)
        {
            if (embutidoItem is not null && tipoEmbutido is not null)
            {
                embutidoItem.TipoEmbutidoPropiedad = tipoEmbutido;
            }
        }
        /// <summary>
        /// para que el vendedor pueda modificar el precio del producto seleccionado
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="nuevoPrecio"></param>
        public void FijarPrecioKg(Productos producto, float nuevoPrecio)
        {
            if (producto is not null && nuevoPrecio > 0)
                producto.PrecioPropiedad = nuevoPrecio;
        }

        /// <summary>
        /// para que el vendedor pueda reponer el stock del producto seleccionado
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="kgAReponer"></param>
        public void ReponerProductos(Productos producto, int kgAReponer)
        {
            producto.KgEnStockPropiedad = producto.KgEnStockPropiedad + kgAReponer;
        }

        /// <summary>
        /// para que el vendedor pueda ver los detalles completos del producto seleccionado
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public string VerDetallesProducto(Productos producto)
        {
            return producto.MostrarDetalle();
        }

        /// <summary>
        /// para cobrar al cliente y que te de el dinero (reducir su monto a gastar)
        /// </summary>
        /// <param name="clienteAPagar"></param>
        /// <param name="importe"></param>
        public void Cobrar(Cliente clienteAPagar, decimal importe)
        {
            clienteAPagar.EfectuarCompraventa(importe);
        }

        /// <summary>
        /// para crear un tipo de dato factura sobre la compra realizada
        /// </summary>
        /// <param name="nombreVendedor"></param>
        /// <param name="nombreCliente"></param>
        /// <param name="monto"></param>
        /// <param name="productosList"></param>
        /// <returns></returns>
        public Factura HacerFactura(string nombreVendedor, string nombreCliente, decimal monto, List<Productos> productosList)
        {
            Factura factura = new Factura(nombreVendedor, nombreCliente, monto, productosList, DateTime.Now);
            return factura;
        }

    }
}
