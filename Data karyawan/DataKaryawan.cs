using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Data_karyawan
{
    public partial class DataKaryawan : Form
    {
        Koneksi koneksi = new Koneksi();

        public DataKaryawan()
        {
            InitializeComponent();
            TampilData(); 
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void TampilData()
        {
            try
            {
                koneksi.OpenConnection();
                dataGridView1.DataSource = koneksi.showData("SELECT * FROM karyawan");

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO karyawan (nik, nama, jabatan, alamat, email, telpon) VALUES (@nik, @nama, @jabatan, @alamat, @email, @telpon)";
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                cmd.Parameters.AddWithValue("@nik", textBox1.Text);
                cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                cmd.Parameters.AddWithValue("@jabatan", textBox3.Text);
                cmd.Parameters.AddWithValue("@alamat", textBox4.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@telpon", textBox6.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan.");

                ClearForm();
                TampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE karyawan SET nama = @nama, jabatan = @jabatan, alamat = @alamat, email = @email, telpon = @telpon WHERE nik = @nik";
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                cmd.Parameters.AddWithValue("@nik", textBox1.Text);
                cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                cmd.Parameters.AddWithValue("@jabatan", textBox3.Text);
                cmd.Parameters.AddWithValue("@alamat", textBox4.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@telpon", textBox6.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah.");
                ClearForm();
                TampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM karyawan WHERE nik = @nik";
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                cmd.Parameters.AddWithValue("@nik", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus.");
                ClearForm();
                TampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            TampilData();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                TampilData(); 
            }
            else
            {
                try
                {
                    koneksi.OpenConnection();
                    string query = "SELECT * FROM karyawan WHERE nama LIKE @keyword OR jabatan LIKE @keyword";
                    MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    koneksi.CloseConnection();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["nik"].Value.ToString();
                textBox2.Text = row.Cells["nama"].Value.ToString();
                textBox3.Text = row.Cells["jabatan"].Value.ToString();
                textBox4.Text = row.Cells["alamat"].Value.ToString();
                textBox5.Text = row.Cells["email"].Value.ToString();
                textBox6.Text = row.Cells["telpon"].Value.ToString();
            }
        }

        private void DataKaryawan_Load(object sender, EventArgs e)
        {
            groupBox1.Dock = DockStyle.Top;  
            dataGridView1.Dock = DockStyle.Fill;      

        }
    }
}
