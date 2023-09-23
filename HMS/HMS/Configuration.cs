using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMS
{
    class Configuration
    {
        static string connectionStr = @"Data Source=DESKTOP-4I6VU4A\LENOVODESKTOP;Initial Catalog=HospitalDB;Integrated Security=True";
        SqlConnection con;
        private static Configuration _instance;

        
        public static string ConnectionStr { get => connectionStr; set => connectionStr = value; }
        public SqlConnection Con { get => con; set => con = value; }
        public static Configuration Instance { get => _instance; set => _instance = value; }

        public static Configuration getInstance()
        {
            if (Instance == null)
                Instance = new Configuration();
            return Instance;
        }
        public Configuration()
        {
            Con = new SqlConnection(ConnectionStr);
            Con.Open();
        }
        public SqlConnection getConnection()
        {
            return Con;
        }
    }
}
