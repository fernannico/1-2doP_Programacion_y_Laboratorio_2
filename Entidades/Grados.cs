using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grados : IAccionamiento
    {
        private Random random;
        private int numero;

        public delegate void NotificadorGrados(int numero);
        public event NotificadorGrados NumeroGenerado;

        public void Iniciar()
        {
            random = new Random();

            Task.Run(() =>
            {
                while (true)
                {
                    numero = random.Next(-15, -9);
                    Thread.Sleep(2000);

                    if (NumeroGenerado is not null)
                    {
                        NumeroGenerado(numero);
                    }
                }
            });
        }

    }
}
