using PracticaN1.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaN1.Vista
{
    public partial class FrmCliente : Form
    {
        MUser mu;
        public FrmCliente(MUser mu)
        {
            InitializeComponent();
            this.mu = mu;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            if (mu.Rol != "Agregar")
            {
                btnAdd.Enabled = false;
            }
            if (mu.Rol != "Actualizar")
            {
                btnUpdate.Enabled = false;
            }
        }
    }
}
