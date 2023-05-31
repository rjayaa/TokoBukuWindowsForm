using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AoLv2.ConnectionHelper;
namespace AoLv2
{
    public partial class InsertBuku : Form
    {
        SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
        DataTable dataTable = new DataTable();
        public InsertBuku()
        {
            InitializeComponent();
        }
        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }



        public string GenerateID()
        {
            string prefix = "BOK"; // ganti dengan tiga huruf awalan yang diinginkan
            string query = "SELECT TOP 1 BookID FROM Books WHERE LEFT(BookID, 3) = @prefix ORDER BY BookID DESC";
            string id = "";

            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@prefix", prefix);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string lastID = reader.GetString(0);
                    string subString = lastID.Substring(3, 3);
                    int intID = int.Parse(subString) + 1;
                    id = prefix + intID.ToString("D3");
                }
                else
                {
                    id = prefix + "001";
                }

                reader.Close();
            }

            return id;
        }

        public void fillData()
        {
            DataGridBuku.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridBuku.Columns.Add(colBut);

            DataGridBuku.Columns[0].ReadOnly = true;
            DataGridBuku.Columns[1].ReadOnly = true;
            DataGridBuku.Columns[2].ReadOnly = true;
            DataGridBuku.Columns[3].ReadOnly = true;
            DataGridBuku.Columns[4].ReadOnly = true;
            DataGridBuku.Columns[5].ReadOnly = true;
            DataGridBuku.Columns[6].ReadOnly = true;


            // dua kode dibawah ini buat menghapus default column & row di datagrid
            DataGridBuku.AllowUserToAddRows = false;
            DataGridBuku.RowHeadersVisible = false;
            DisableViewAndButton();
            con.Close();
            fixSearchBug();
        }
        public void DisableViewAndButton()
        {
            btnClear.Enabled  = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void ButtonUpdateDeleteEnable() {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void ClearInsert()
        {
            txtIDBuku.Text = GenerateID();
            txtJudulBuku.Text = "";
            txtPengarang.Text = "";
            txtPenerbit.Text = "";
            txtTahunTerbit.Text = "";
            txtHarga.Value = 0;
            txtStock.Value = 0;
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Books VALUES (@BookID, @Title, @Author, @Publisher, @PublicationYear, @Price,@Stock)", con);
            cmd.Parameters.AddWithValue("@BookID", txtIDBuku.Text);
            cmd.Parameters.AddWithValue("@Title", txtJudulBuku.Text);
            cmd.Parameters.AddWithValue("@Author", txtPengarang.Text);
            cmd.Parameters.AddWithValue("@Publisher", txtPenerbit.Text);
            cmd.Parameters.AddWithValue("@PublicationYear", txtTahunTerbit.Text);
            cmd.Parameters.AddWithValue("@Price", (int)txtHarga.Value);
            cmd.Parameters.AddWithValue("@Stock", (int)txtStock.Value);

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridBuku.Columns.Clear();
            dataTable.Clear();

            fillData();

        }
        public void DeleteData()
        {
            string t0 = txtIDBuku.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Books WHERE BookID = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridBuku.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void UpdateData()
        {
            con.Open();
            string tid = txtIDBuku.Text;
            string t0 = txtJudulBuku.Text;
            string t1 = txtPengarang.Text;
            string t2 = txtPenerbit.Text;
            string t3 = txtTahunTerbit.Text;
            decimal t4 = txtHarga.Value;
            decimal t5 = txtStock.Value;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Books SET Title = @t0, Author = @t1, Publisher = @t2, PublicationYear = @t3, Price = @t4, Stock = @t5  WHERE BookID = @tid;";
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@t1", t1);
            cmd.Parameters.AddWithValue("@t2", t2);
            cmd.Parameters.AddWithValue("@t3", t3);
            cmd.Parameters.AddWithValue("@t4", t4);
            cmd.Parameters.AddWithValue("@t5", t5);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridBuku.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
            MessageBox.Show("Update Buku Berhasil!!!");

        }

       public void DisplayDataSearch()
        {
            con.Open();
            if(comboBox.Text == "")
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock FROM Books WHERE BookID LIKE '" + txtSearch.Text + "%' OR Title LIKE '" + txtSearch.Text + "%' OR Author LIKE '" + txtSearch.Text + "%' OR Publisher LIKE '" + txtSearch.Text + "%' OR PublicationYear LIKE '" + txtSearch.Text + "%' OR Price LIKE '" + txtSearch.Text + "%' OR Stock LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;

            }
            else if(comboBox.Text == "BookID")
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock  FROM Books WHERE BookID LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }else if (comboBox.Text == "Title") 
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock  FROM Books WHERE Title LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Author")
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock  FROM Books WHERE Author LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Publisher")
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock  FROM Books WHERE Publisher LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Publication Year")
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock  FROM Books WHERE PublicationYear LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Price")
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock  FROM Books WHERE Harga LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            else if (comboBox.Text == "Stock")
            {
                string q = "SELECT BookID, Title, Author, Publisher, PublicationYear, Price, Stock  FROM Books WHERE Stock LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBuku.DataSource = st;
            }
            con.Close();
        }
        
        public void fixSearchBug()
        {
            txtSearch.Text = "BOK001";
            txtSearch.Text = "";
        }
        public void ViewData()
        {
            
            ButtonUpdateDeleteEnable();
            int selectedIndex = DataGridBuku.CurrentCell.RowIndex;
            txtIDBuku.Text = DataGridBuku.Rows[selectedIndex].Cells[0 + 1].Value.ToString();
            txtJudulBuku.Text = DataGridBuku.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
            txtPengarang.Text = DataGridBuku.Rows[selectedIndex].Cells[2 + 1].Value.ToString();
            txtPenerbit.Text = DataGridBuku.Rows[selectedIndex].Cells[3 + 1].Value.ToString();
            txtTahunTerbit.Text = DataGridBuku.Rows[selectedIndex].Cells[4 + 1].Value.ToString();

            // i dont know how tf this code works
            string hargaStr = DataGridBuku.Rows[selectedIndex].Cells[5 + 1].Value.ToString();
            decimal harga;
            if (!string.IsNullOrEmpty(hargaStr) && decimal.TryParse(hargaStr, out harga))
            {
                txtHarga.Value = harga;
            }
            string stocktemp = DataGridBuku.Rows[selectedIndex].Cells[6 + 1].Value.ToString();
            decimal stock;
            if (!string.IsNullOrEmpty(stocktemp) && decimal.TryParse(stocktemp, out stock))
            {
                txtStock.Value = stock;
            }
        }



        // validasi buat textbox hanya menerima tahun
        private void txtTahunTerbit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka dan tombol khusus
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTahunTerbit_Leave(object sender, EventArgs e)
        {
            
            // Pastikan bahwa tahun yang dimasukkan memiliki panjang 4 digit
            if (txtTahunTerbit.Text.Length != 4)
            {
                MessageBox.Show("Tahun harus memiliki panjang 4 digit.");
                txtTahunTerbit.Focus();
            }
        }

       

        private void _2InsertBuku_Load(object sender, EventArgs e)
        {
            txtIDBuku.Text = GenerateID();
            fillData();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearInsert();
            txtIDBuku.Text= GenerateID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            txtIDBuku.Text = GenerateID();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void txtJudulBuku_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJudulBuku.Text))
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayDataSearch();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridBuku.Columns[e.ColumnIndex].Name == "")
            {
                ViewData();
            }
        }
    }
}
