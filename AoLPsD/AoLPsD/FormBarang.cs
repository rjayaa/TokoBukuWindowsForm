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
namespace AoLPsD
{
    public partial class FormBarang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=crudPerusahaan;Integrated Security=True;");

        DataTable dataTable = new DataTable();
        public FormBarang()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Barang", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }

        public string GenerateID()
        {
            string connectionString = (@"Data Source=.\SQLEXPRESS;Initial Catalog=crudPerusahaan;Integrated Security=True;");
            string query = "SELECT TOP 1 ID_Barang FROM Barang ORDER BY ID_Barang DESC";
            string id = "BD";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string lastID = reader.GetString(0);
                    string subString = lastID.Substring(2, 3);
                    int intID = int.Parse(subString) + 1;
                    id += intID.ToString("D3");
                }
                else
                {
                    id += "001";
                }

                reader.Close();
            }

            return id;
        }

        public void fillData()
        {
            DataGridBarang.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridBarang.Columns.Add(colBut);

            DataGridBarang.Columns[0].ReadOnly = true;
            DataGridBarang.Columns[1].ReadOnly = true;
            

            DisableViewAndButton();
            con.Close();
        }
        public void DisableViewAndButton()
        {
            txtViewNama.Enabled = false;
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Barang VALUES (@ID_Barang, @Nama_Barang)", con);
            cmd.Parameters.AddWithValue("@ID_Barang", GenerateID());
            cmd.Parameters.AddWithValue("@Nama_Barang", txtNamaBarang.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridBarang.Columns.Clear();
            dataTable.Clear();

            fillData();

        }

       

        public void ViewData()
        {
            ButtonUpdateDeleteEnable();
            int selectedIndex = DataGridBarang.CurrentCell.RowIndex;
            txtNamaBarang.Text = DataGridBarang.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
            txtIDBarang.Text = DataGridBarang.Rows[selectedIndex].Cells[0 + 1].Value.ToString();
            txtViewNama.Text = DataGridBarang.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
        }

        public void ViewData2()
        {
            ButtonUpdateDeleteEnable();
            int selectedIndex = DataGridBarang.CurrentCell.RowIndex;
            txtNamaBarang.Text = DataGridBarang.Rows[selectedIndex].Cells[1].Value.ToString();
            txtIDBarang.Text = DataGridBarang.Rows[selectedIndex].Cells[0].Value.ToString();
            txtViewNama.Text = DataGridBarang.Rows[selectedIndex].Cells[1].Value.ToString();
        }
       
        public void DeleteData()
        {
            string t0 = txtIDBarang.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Barang WHERE ID_Barang = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridBarang.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();

        }
        public void UpdateData()
        {
            con.Open();
            string t0 = txtIDBarang.Text;
            string t1 = txtNamaBarang.Text;
            
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Barang SET Nama_Barang = @t1 WHERE ID_Barang = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@t1", t1);
            

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();

            txtIDBarang.Text = t0;
            txtViewNama.Text = t1;
            
        }

        public void DisplaySearch()
        {
            con.Open();
               if(comboBox.Text == "Nama Barang")
            {
                string q = "SELECT ID_Barang, Nama_Barang FROM Barang WHERE Nama_Barang LIKE'" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBarang.DataSource = st;
            }
            con.Close();

        }

        public void ButtonUpdateDeleteEnable()
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
        public void ClearInsert()
        {
            txtIDBarang.Text = "";
            txtNamaBarang.Text = "";
            txtSearch.Text = "";
            txtViewNama.Text = "";
            comboBox.Text = "";

        }
       
       
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearInsert();
        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void DataGridBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewData();
            }
        }

        private void DataGridBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==2)
            {
                ViewData2();
            }
        }

        private void txtNamaBarang_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaBarang.Text))
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
            DisplaySearch();
        }
    }
}
