using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//References: https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
namespace DAL
{
    class dbConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public dbConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "benhvien";
            uid = "root"; // Thay đổi theo máy lúc cấu hình
            password = "root";// Thay đổi theo máy lúc cấu hình
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool GetOpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Không thể kết nối với máy chủ, vui lòng liên hệ với quản trị viên để biết thêm thông tin.");
                        break;

                    case 1045:
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
  
    }
}
