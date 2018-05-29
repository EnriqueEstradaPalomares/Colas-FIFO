using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas_FIFO
{
    class Proceso
    {
        public Proceso(int tiempo)
        {
            this._tiempo = tiempo;
        }
        private int _tiempo;
        Proceso _sig;

        public int Tiempo
        {
            set { _tiempo = value; }
            get { return _tiempo; }
        }

        public Proceso sig
        {
            set { _sig = value; }
            get { return _sig; }
        }
    }
}
