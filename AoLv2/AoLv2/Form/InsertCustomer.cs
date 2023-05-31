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
using System.Text.RegularExpressions;
using AoLv2.ConnectionHelper;
namespace AoLv2
{
    public partial class InsertCustomer : Form
    {
        SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
        DataTable dataTable = new DataTable();
        public InsertCustomer()
        {
            InitializeComponent();
        }
        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }
        public string GenerateID()
        {
            string prefix = "CUS"; // ganti dengan tiga huruf awalan yang diinginkan
            string query = "SELECT TOP 1 CustomerID FROM Customers WHERE LEFT(CustomerID, 3) = @prefix ORDER BY CustomerID DESC";
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
            DataGridPelanggan.DataSource = getDataTable();
            var colBut = new DataGridViewButtonColumn
            {
                Name = "",
                Text = "View",
                UseColumnTextForButtonValue = true
            };
            DataGridPelanggan.Columns.Add(colBut);

            foreach (DataGridViewColumn column in DataGridPelanggan.Columns)
            {
                column.ReadOnly = true;
            }

            DataGridPelanggan.AllowUserToAddRows = false;
            DataGridPelanggan.RowHeadersVisible = false;
            DisableViewAndButton();
            con.Close();
            fixSearchBug();
        }

        public void DisableViewAndButton()
        {
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void ButtonUpdateDeleteEnable()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        public void ClearInsert()
        {
            txtIDPelanggan.Text = GenerateID();
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtTelepon.Text = "";
            txtEmail.Text = "";
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES (@CustomerID, @Name, @Address,@Phone, @Email)", con);
            cmd.Parameters.AddWithValue("@CustomerID", txtIDPelanggan.Text);
            cmd.Parameters.AddWithValue("@Name", txtNama.Text);
            cmd.Parameters.AddWithValue("@Address", txtAlamat.Text);
            cmd.Parameters.AddWithValue("@Phone", txtTelepon.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            DataGridPelanggan.Columns.Clear();
            dataTable.Clear();

            fillData();
        }

        public void DeleteData()
        {
            string t0 = txtIDPelanggan.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Customers WHERE CustomerID = @t0;";
            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridPelanggan.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
            
        }

        public void UpdateData()
        {
            con.Open();
            string tid = txtIDPelanggan.Text;
            string t0 = txtNama.Text;
            string t1 = txtAlamat.Text;
            string t2 = txtTelepon.Text;
            string t3 = txtEmail.Text;


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Customers SET Name = @t0, Address = @t1, Phone = @t2, Email = @t3 WHERE CustomerID = @tid;";
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@t1", t1);
            cmd.Parameters.AddWithValue("@t2", t2);
            cmd.Parameters.AddWithValue("@t3", t3);


            cmd.ExecuteNonQuery();
            con.Close();

            DataGridPelanggan.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
            MessageBox.Show("Update Pelanggan Berhasil!!!");

        }

        public void DisplayDataSearch()
        {
            
            con.Open();
            if (comboSearch.Text == "")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email FROM Customers WHERE CustomerID LIKE '" + txtSearch.Text + "%' OR Name LIKE '" + txtSearch.Text + "%' OR Address LIKE '" + txtSearch.Text + "%' OR Email LIKE '" + txtSearch.Text + "%' OR Phone LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;

            }
            else if (comboSearch.Text == "Customer ID")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email FROM Customers WHERE CustomerID LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboSearch.Text == "Name")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Customers WHERE Name LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboSearch.Text == "Address")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Customers WHERE Address LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboSearch.Text == "Phone")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Customers WHERE Phone LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            else if (comboSearch.Text == "Email")
            {
                string q = "SELECT CustomerID, Name, Address, Phone, Email  FROM Customers WHERE Email LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPelanggan.DataSource = st;
            }
            con.Close();
        }

        public void ViewData()
        {
            ButtonUpdateDeleteEnable();
            txtIDPelanggan.Text = DataGridPelanggan.SelectedRows[0].Cells[0 + 1].Value.ToString();
            txtNama.Text = DataGridPelanggan.SelectedRows[0].Cells[1 + 1].Value.ToString();
            txtAlamat.Text = DataGridPelanggan.SelectedRows[0].Cells[2 + 1].Value.ToString();
            txtTelepon.Text = DataGridPelanggan.SelectedRows[0].Cells[3 + 1].Value.ToString();
            txtEmail.Text = DataGridPelanggan.SelectedRows[0].Cells[4 + 1].Value.ToString();
        }
 
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            // Regular expression untuk validasi email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Cek apakah nilai textbox sesuai dengan regular expression
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Input harus berupa email yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                e.Cancel = true;
            }
        }

        private void InsertCustomer_Load(object sender, EventArgs e)
        {
            txtIDPelanggan.Text = GenerateID();
            fillData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearInsert();
            txtIDPelanggan.Text = GenerateID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            txtIDPelanggan.Text = GenerateID();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text))
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

        public void fixSearchBug()
        {
            txtSearch.Text = "CUS001";
            txtSearch.Text = "";
        }
        private void DataGridPelanggan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(DataGridPelanggan.Columns[e.ColumnIndex].Name == "")
            {
                ViewData();
            }
        }
    }

}
