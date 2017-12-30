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

        public bool OpenConnection()
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
        //=======================================================================================
        //Các hàm xử lí trên nhân viên
        public void ThemNhanVien(string TENNV, string NGAYSINH, Boolean GTINH, String DIACHI, 
            int SDT, string CHUCVU, int enabled, int role, string temppassword)
        {          
            string query2 = "insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) "+
                "values('"+TENNV+"','"+NGAYSINH+"',"+GTINH+",'"+DIACHI+"',"+SDT+", '"+CHUCVU+"',"+enabled+","+role+",'"+temppassword+"')";

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

        public void SuaNhanVien(int MANV , string TENNV, string NGAYSINH, Boolean GTINH, String DIACHI,
            int SDT, string CHUCVU, int enabled, int role, string temppassword)
        {
            string query2 = "Update profile set TENNV = '"+TENNV +"', NGAYSINH = '12-01-1996', GTINH = "+GTINH+", DIACHI = '"+DIACHI+"', SDT = "+SDT+", CHUCVU = '"+CHUCVU+"', enabled = "+ enabled+
                ",role = "+role+",temppassword = '"+temppassword+"' where MANV = "+MANV;

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
                    cmd.CommandText = query2;
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

        public void XoaNhanVien(int a)
        {
            string query = " UPDATE profile SET enabled = -1 WHERE MANV = " + a.ToString();

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
                    //string s = dataReader["NGAYSINH"].ToString();
                    //MessageBox.Show(s);
                    DTO_Profile nv = new DTO_Profile(
                    Convert.ToInt64(dataReader["MANV"])
                    , Convert.ToString(dataReader["TENNV"])
                    , Convert.ToDateTime(dataReader["NGAYSINH"])
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
        //Kết thúc các hàm xử lí dành cho nhân viên


        //=======================================================================================
        //Các hàm xử lí trên dịch vụ
        public void ThemDichVu(string _TENDV1, long _MANV1, double _GIADV1)
        {
            string query2 = "insert into dichvu(`TENDICHVU`,`MANV`, `GIADICHVU`) values('"+_TENDV1+"',"+_MANV1+","+_GIADV1+");";

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
                    cmd.CommandText = query2;
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

        public void SuaDichVu(long _MADV, string _TENDV1, long _MANV1, double _GIADV1)
        {
            string query2 = "update dichvu set TENDICHVU = '"+_TENDV1+"', MANV = '"+_MANV1+"', GIADICHVU = '"+_GIADV1+"' where MADV = " + _MADV ;

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
                    cmd.CommandText = query2;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Thành công!");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Sửa không thành công!");
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

        public void XoaDichVu(int a)
        {
            string query = " UPDATE dichvu SET enabled = -1 WHERE MADV = " + a.ToString();

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

        public List<DTO_DichVu> DanhSachDichvu()
        {
            string query = "SELECT * FROM dichvu where enabled > -1";

            //Create a list to store the result
            List<DTO_DichVu> list = new List<DTO_DichVu>();

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
                    DTO_DichVu dv = new DTO_DichVu(
                    Convert.ToInt64(dataReader["MADV"]),
                    Convert.ToString(dataReader["TENDICHVU"]),
                     Convert.ToInt64(dataReader["MANV"]),
                     Convert.ToDouble(dataReader["GIADICHVU"]));
                    list.Add(dv);
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


        //Kết thúc các hàm xử lí dành cho dịch vụ

        

        //=======================================================================================
        public DTO_Profile KiemTraUser(string username, string password)
        {
            string query2 = "SELECT * FROM profile WHERE MANV ='" + username + "' and temppassword ='" + password + "'";
            //string query2 = "SELECT * FROM profile WHERE MANV = 2 and temppassword ='123456'";
            DTO_Profile prf = null;
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query2, connection);
                cmd.Connection = connection;
                MySqlTransaction myTrans;
                myTrans = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = myTrans;
                //DataTable dt = new DataTable();
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //sda.Fill(dt);
                try
                {
                    while (dataReader.Read())
                    {
                      prf = new DTO_Profile(
                    Convert.ToInt64(dataReader["MANV"])
                    , Convert.ToString(dataReader["TENNV"])
                    , Convert.ToDateTime(dataReader["NGAYSINH"])
                    , Convert.ToBoolean(dataReader["GTINH"])
                    , Convert.ToString(dataReader["DIACHI"])
                    , Convert.ToInt32(dataReader["SDT"])
                    , Convert.ToString(dataReader["CHUCVU"])
                    , Convert.ToBoolean(dataReader["enabled"])
                    , Convert.ToInt32(dataReader["role"])
                    , Convert.ToString(dataReader["passwordresethash"])
                    , Convert.ToString(dataReader["temppassword"]));
                    }
                    return prf;
                    //if (dt.Rows.Count > 0)
                    //    if (dt.Rows[0][0].ToString() == "2") return 2;
                    //    else
                    //        if (dt.Rows[0][0].ToString() == "1") return 1;
                    //    else
                    //        return 0;
                    //else
                    //    return -1;
                    ////cmd.CommandText = query;
                    ////cmd.ExecuteNonQuery();
                    //cmd.CommandText = query2;
                    //cmd.ExecuteNonQuery();
                    //myTrans.Commit();
                    //MessageBox.Show("Tài khoản hợp lệ");

                }
                catch (Exception e)
                {
                    //MessageBox.Show("Tài khoản không hợp lệ");
                    //myTrans.Rollback();
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Neither record was written to database.");
                    return null;
                }
                finally
                {
                    this.CloseConnection();
                }
                
            }
            else
                return null;
        }

       
    }
}
