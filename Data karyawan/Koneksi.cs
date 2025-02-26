using MySql.Data.MySqlClient;
using System.Data;

namespace Data_karyawan
{
    internal class Koneksi
    {
        private string connectionString = "Server=localhost;Database=perusahaan;Uid=root;pwd=;";
        public MySqlConnection kon { get; private set; }  // Membuat kon dapat diakses tapi hanya bisa diset di class ini

        public void OpenConnection()
        {
            kon = new MySqlConnection(connectionString);
            kon.Open();
        }

        public void CloseConnection()
        {
            if (kon != null && kon.State == ConnectionState.Open)
            {
                kon.Close();
            }
        }

        public object showData(string query)
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
            {
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data.Tables[0];
            }
        }
    }
}
