using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using DTO;
using System.Data;
//References: https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
namespace DAL
{
    public class DAL_dbConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        
        //Constructor
        public DAL_dbConnect()
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

        private bool OpenConnection()
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
        //Thêm bệnh nhân
        public void ThemBenhNhan()
        {
            string query = "insert into user(MANV, enabled,role,passwordresethash,temppassword) values(8,1,2,'12112','11212324')";

            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //Thêm nhân viên
        public void ThemNhanVien(string TENNV, Date NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled, role, temppassword)
        {
            
            string query2 = " insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled, role, temppassword) values('h', '0000-00-00', 1, '12323hjgjhg', 099898, 'h', 1, 2, '11212324')";
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query2, connection);
                cmd.Connection = connection;
                MySqlTransaction myTrans;
                myTrans = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = myTrans;
                try
                {
                    //cmd.CommandText = query;
                    //cmd.ExecuteNonQuery();
                    cmd.CommandText =query2;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Thành công!");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Thêm không thành công!");
                    myTrans.Rollback();
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Neither record was written to database.");
                }
                finally
                {
                    this.CloseConnection();
                }
                
            }
        }

        public void SuaNhanVien()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void XoaNhanVien(int a)
        {
            string query = " UPDATE profile SET enabled = 0 WHERE MANV = " + a.ToString();

            //Open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public List<DTO_Profile> DanhSachNhanVien()
        {
            string query = "SELECT * FROM profile where enabled >= 0";

            //Create a list to store the result
            List<DTO_Profile> list = new List<DTO_Profile>();
            
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    DTO_Profile nv = new DTO_Profile(
                    Convert.ToInt64(dataReader["MANV"])
                    , Convert.ToString(dataReader["TENNV"])
                    , Convert.ToDateTime("12-01-1996")
                    , Convert.ToBoolean(dataReader["GTINH"])
                    , Convert.ToString(dataReader["DIACHI"])
                    , Convert.ToInt32(dataReader["SDT"])
                    , Convert.ToString(dataReader["CHUCVU"])
                    , Convert.ToBoolean(dataReader["enabled"])
                    , Convert.ToInt32(dataReader["role"])
                    , Convert.ToString(dataReader["passwordresethash"])
                    , Convert.ToString(dataReader["temppassword"]));
                    list.Add(nv);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}
