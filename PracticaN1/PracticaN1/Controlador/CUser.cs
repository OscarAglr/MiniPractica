using PracticaN1.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaN1.Controlador
{
    class CUser
    {
        public static DataTable Validar(MUser u)
        {
            return u.Validar();
        }

        public static DataTable GetRol(MUser u)
        {
            return u.GetRol();
        }
    }
}
