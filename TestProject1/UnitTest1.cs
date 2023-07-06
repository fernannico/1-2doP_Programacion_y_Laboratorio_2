using Entidades;
using ProductosNs;
using System.Diagnostics;
using usuarios;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBaseDeDatosUsuariosNoVacia()
        {
            List<Usuario> usuarios;

            usuarios = UsuariosBDD.Leer<Usuario>();
            Assert.AreNotEqual(usuarios.Count, 0);

        }
        
        [TestMethod]
        public void TestBaseDeDatosProductosNoVacia()
        {
            List<Productos> productos;

            productos = ProductosBDD.Leer<Productos>();
            Assert.AreNotEqual(productos.Count, 0);
        }


        [TestMethod]
        public void TestCorreoElectronicoUsuarios()
        {
            List<Usuario> usuarios = UsuariosBDD.Leer<Usuario>();

            foreach (var usuario in usuarios)
            {
                Assert.IsTrue(usuario.MailPropiedad.EsMail());
            }
        }
    }
}