using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lending_Management_System.Modules
{
    

   public class db_connect
    {
        private string server = Properties.Settings.Default.Server;
        private string user = Properties.Settings.Default.Username;
        private string db = Properties.Settings.Default.Database;
        private string pass = Properties.Settings.Default.Password;
        private string port = "3306";
        public MySqlConnection con = new MySqlConnection();
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader reader;
        public MySqlTransaction transact;
        public string ConnString { get { return  $"server= {server};user={user};password={pass};database={db};port={port};Convert Zero Datetime=True"; } }



        public void connect()
        {
            try
            {
              if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConnString;
                    cmd.Connection = con;
                    con.Open();
                }  
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message + " connect_db()");
            }

            
        }

        public void disconnect_db()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool isConnected()
        {
            string connect = $"server={server};user={user};password={pass};database={db};port={port};Convert Zero Datetime=True";

            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connect;
                cmd.Connection = con;
                con.Open();
            }
            return true;
        }

        public bool testConnectionDB(string connectionString)
        {
            string connect = $"{connectionString}port={port};";
            try
            {
                MySqlConnection _con;
                using (_con = new MySqlConnection())
                {
                    if (_con.State == ConnectionState.Closed)
                    {
                        _con.ConnectionString = connect;
                        _con.Open();
                    }
                }
                   
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
