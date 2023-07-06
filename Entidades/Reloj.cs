using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reloj : IAccionamiento
    {
        int hora;
        int minutos;
        int segundos;

        public delegate void NotificadorCambioDeTiempo(Reloj reloj);
        public event NotificadorCambioDeTiempo SegundoCambiado;

        public void Iniciar()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    DateTime dateTime = DateTime.Now;
                    Thread.Sleep(10);
                    
                    if(dateTime.Second != segundos)
                    {
                        if(SegundoCambiado is not null)
                        {
                            SegundoCambiado(this);
                        }
                    }
                    hora = dateTime.Hour; 
                    minutos = dateTime.Minute; 
                    segundos = dateTime.Second;
                }
            });
        }

        public override string ToString()
        {
            return $"{hora}:{minutos}:{segundos}";
        }

    }
}
