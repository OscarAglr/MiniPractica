using PracticaN1.Modelo;
using PracticaN1.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaN1
{
    public partial class Form1 : Form
    {
        MUser mu;
        public Form1(MUser u)
        {
            InitializeComponent();
            this.mu = u;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (mu.Rol == "Administrador")
            {
                usuariosToolStripMenuItem.Enabled = true;
            }
            else
            {
                usuariosToolStripMenuItem.Enabled = false;
            }
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente(mu);
            frmCliente.MdiParent = this;
            frmCliente.Show();
        }
    }
}
