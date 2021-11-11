using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaN1.Modelo
{
    public class MUser
    {
        int id;
        string username;
        string password;
        string rol;
        string estado;
        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Estado { get => estado; set => estado = value; }

        public DataTable Validar()
        {
            DataTable DtResultado = new DataTable("Inicio_Sesión");
            SqlConnection connect = new SqlConnection(Connect.c);
            connect.Open();
            SqlCommand command = new SqlCommand("Exec log_in @user, @pass", connect);
            command.Parameters.AddWithValue("@user", Username);
            command.Parameters.AddWithValue("@pass", Password);

            SqlDataAdapter sda = new SqlDataAdapter(command);

            sda.Fill(DtResultado);
            connect.Close();
            sda.Dispose();
            return DtResultado;
        }

        public DataTable GetRol()
        {
            DataTable DtResultado = new DataTable("Inicio_Sesión");
            SqlConnection connect = new SqlConnection(Connect.c);
            connect.Open();
            SqlCommand command = new SqlCommand("Exec GetRol @user, @pass", connect);
            command.Parameters.AddWithValue("@user", Username);
            command.Parameters.AddWithValue("@pass", Password);

            SqlDataAdapter sda = new SqlDataAdapter(command);

            sda.Fill(DtResultado);
            connect.Close();
            sda.Dispose();
            return DtResultado;
        }
    }
}
