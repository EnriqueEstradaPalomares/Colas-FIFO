using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas_FIFO
{
    class CPU
    {
        private Random rdn;
        Proceso inicio = null, newProceso;
        private int colaVacia = 0, proAtendidos = 0, proPendientes = 0, TTotal=0;
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
                TTotal += nuevo.Tiempo;
            }
        }

        
        //---------------------------------------------------------------------
        public void start()
        {
            addProcess();
            for(int i = 0; i < 300; i++)
            {
                if (probabilidad())
                {
                    addProcess();
                }

                if (inicio.Tiempo != 0)
                {
                    inicio.Tiempo -= 1;
                }
                else
                {
                    proAtendidos++;
                    ifIsNullTime();
                }
                pendientes();
            }
        }
        //---------------------------------------------------------------------
        private void ifIsNullTime()
        {
            if (inicio.sig != null)
            {
                inicio = inicio.sig;
            }
            else
                colaVacia++;
        }
        //---------------------------------------------------------------------
        private void pendientes()
        {
            proPendientes = TTotal - proAtendidos;
        }
        //---------------------------------------------------------------------
        public bool probabilidad()
        {
            int proba = 0;
            rdn = new Random();
            proba = rdn.Next(1, 101);
            if (proba < 35)
                return true;
            else
                return false;
        }
        //---------------------------------------------------------------------
        public void addProcess()
        {
            rdn = new Random();
            int time = rdn.Next(4, 15);
            newProceso = new Proceso(time);
            agregar(newProceso);
            TTotal ++;
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
        //--------------------------------------------------------------------------
    }
}
