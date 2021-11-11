using PracticaN1.Controlador;
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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                MUser mu = new MUser();
                mu.Username = txtUsername.Text;
                mu.Password = txtPswrd.Text;
                CUser cu = new CUser();
                DataTable dt;
                DataTable dr;
                dt = CUser.Validar(mu);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "Aceptado")
                    {
                        dr = CUser.GetRol(mu);
                        mu.Rol = dr.Rows[0][0].ToString();
                        MessageBox.Show("Bienvenido al sistema " + mu.Rol);
                        Form1 form1 = new Form1(mu);
                        this.Hide();
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Acceso denegado");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
