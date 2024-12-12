
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace TabuniarFinalExam
{
    internal class DBConnect
    {
        public MySqlConnection connection { get; set; }
        public MySqlCommand command { get; set; }
        public MySqlDataAdapter dataAdapter { get; set; }
        public DataTable dataTable { get; set; }
        public string server { get; set; }
        public string database { get; set; }
        public string uid { get; set; }
        public string password { get; set; }
        public string connectionString { get; set; }
        public DBConnect()
        {
            connection = new MySqlConnection();
            command = new MySqlCommand();
            dataAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            server = string.Empty;
            database = string.Empty;
            uid = string.Empty;
            password = string.Empty;
            connectionString = string.Empty;
        }
        public void OpenDB()
        {
            try
            {
                server = "localhost";
                database = "DBSubjectA";
                uid = "root";
                password = "root";
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid +
                    ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void CloseDB()
        {
            connection.Close();
        }
        public DataTable ReadRegistrationRecord()
        {
            OpenDB();
            string sql = "SELECT * FROM tblsubject";
            dataTable = new DataTable();
            command = new MySqlCommand(sql, connection);
            dataTable.Load(command.ExecuteReader());
            CloseDB();
            return dataTable;
        }
        public void InsertRegistration(Subject subj)
        {
            OpenDB();
            string sql1 = "INSERT INTO tblsubject (code, courseno, description, schedule, room)" + "VALUES ('" + subj.code + "', " +
                "'" + subj.courseno + "', '" + subj.description + "', '" + subj.schedule + "', '" + subj.room + "')";
            command = new MySqlCommand(sql1, connection);
            command.ExecuteNonQuery();
            CloseDB();
        }
      
    }
}