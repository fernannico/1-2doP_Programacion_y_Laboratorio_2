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

        public override string ToString()
        {
            return $"Vendedor - {mail}";
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
            if (carneItem is not null && corte is not null)
            {
                carneItem.CortePropiedad = corte;
            }
        }
        public void FijarTipoEmbutido(Embutido embutidoItem, string tipoEmbutido)
        {
            if (embutidoItem is not null && tipoEmbutido is not null)
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

        public void Cobrar(Cliente clienteAPagar, decimal importe)
        {
            clienteAPagar.EfectuarCompraventa(importe);
        }

        public Factura HacerFactura(string nombreVendedor, string nombreCliente, decimal monto, List<Productos> productosList)
        {
            Factura factura = new Factura(nombreVendedor, nombreCliente, monto, productosList, DateTime.Now);
            return factura;
        }

    }
}
