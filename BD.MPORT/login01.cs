using controle.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using System.Data;
using MySql.Data.MySqlClient;

namespace BD.MPORT
{

    public class login01
    {
        public string email;
        public string senha;

        public bool getUserVerificar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT count(*) FROM mport.user WHERE");
            sql.AppendLine("    USER.EMAIL = '" + email + "'");
            sql.AppendLine("AND USER.SENHA = '" + senha + "'");

            if(Convert.ToInt32(Factory.ExecuteScalar(CommandType.Text, sql.ToString())) > 0)
            {
                return true;
            }

            return false;
        }
    }
}
