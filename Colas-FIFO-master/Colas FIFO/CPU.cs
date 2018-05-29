using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas_FIFO
{
    class CPU
    {
        private Random rdn = new Random();
        Proceso inicio = null;
        private int colaVacia = 0, proAtendidos = 0, proPendientes = 0, TTotal=0, faltantes=0;
        //-------------------------------------------------------------------
        public void agregar(Proceso nuevo)
        {
            if (inicio == null)
                inicio = nuevo;
            else
                agregar(nuevo, inicio);
        }
        private void agregar(Proceso nuevo, Proceso quien)
        {
            if (quien.sig != null)
                agregar(nuevo, quien.sig);
            else
            {
                quien.sig = nuevo;
            }
        }

        
        //---------------------------------------------------------------------
        public void start()
        {
            for(int i = 0; i < 300; i++)
            {
                if (probabilidad())
                {
                    agregar(new Proceso(rdn.Next(4,15)));
                    TTotal++;
                }
                if (inicio != null)
                {
                    inicio.Tiempo -= 1;
                    if (inicio.Tiempo == 0)
                    {
                        inicio = inicio.sig;
                        proAtendidos++;
                    }
                }
                else
                {
                    colaVacia++;
                }
            }
            pendientes();
            
        }
        //---------------------------------------------------------------------
        //private void ifIsNullTime()
        //{
        //    if (inicio.sig != null)
        //    {
        //        inicio = inicio.sig;
            
        //}
        //---------------------------------------------------------------------
        private void pendientes()
        {
            proPendientes = TTotal - proAtendidos;
        }
        //---------------------------------------------------------------------
        public void CiclosPendientes()
        {
            Proceso actual = inicio;
            while (actual != null)
            {
                faltantes += actual.Tiempo;
                actual = actual.sig;
            }
        }
        //---------------------------------------------------------------------
        public bool probabilidad()
        {
            int proba = rdn.Next(1, 101);
            if (proba <= 35)
                return true;
            else
                return false;
        }
        //-----------------------------------RETORNAR VALORES---------------------
        public string retornaTotales()
        {
            string total = TTotal.ToString();
            return total;
        }
        public string retornaVacias()
        {
            string vacias = colaVacia.ToString();
            return vacias;
        }
        public string retornaAtendidos()
        {
            string atendidos = proAtendidos.ToString();
            return atendidos;
        }
        public string retornaPendientes()
        {
            string pendientes = proPendientes.ToString();
            return pendientes;
        }
        public string retornaTiempoPendientes()
        {
            string pendientes = faltantes.ToString();
            return pendientes;
        }
        //--------------------------------------------------------------------------
    }
}
