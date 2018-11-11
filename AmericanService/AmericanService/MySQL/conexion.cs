using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AmericanService.MySQL
{
    public class conexion
    {

        MySqlConnection conn;
        String connString;
        

        public static MySqlConnection getConexion()
        {
            connString = "SERVER= databases.000webhost.com; PORT=3326; DATABASE=id7156754_americaservice;"
                    + " UID = 	id7156754_americaservice; PASSWORD = as123123";
            
            conn = conn.

        }
        
    }
}