using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colas_FIFO
{
    public partial class Form1 : Form
    {
        //CPU cpu = new CPU();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            CPU cpu = new CPU();
            cpu.start();
            limpiar();
            lblAtendidos.Text = cpu.retornaAtendidos();
            lblPendientes.Text = cpu.retornaPendientes();
            lblProcesos.Text = cpu.retornaTotales();
            lblCiclos.Text = cpu.retornaVacias();
            for(int i=0; i<300; i++)
            {
                if (timer())
                    textBox1.Text += "|";
                else
                    textBox1.Text += "-";
            }
        }

        private bool timer()
        {
            Random ono = new Random();
            int ol = ono.Next(0, 2);
            if (ol == 0)
                return false;
            else
                return true;
        }

        private void limpiar()
        {
            textBox1.Clear();
            lblAtendidos.Text = "";
            lblCiclos.Text = "";
            lblPendientes.Text = "";
            lblProcesos.Text = "";
        }
    }
}
