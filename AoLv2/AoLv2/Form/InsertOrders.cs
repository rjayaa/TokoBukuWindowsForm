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
using AoLv2.Insertion;
using System.Globalization;

namespace AoLv2
{
    public partial class InsertOrders : Form
    {

        SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
        private List<string> CustomerNames = new List<string>();
        DataTable dataTable = new DataTable();
        SqlCommand cmd;
        SqlDataReader dr;
        public InsertOrders()
        {
            InitializeComponent();
        }
        public DataTable getDataTable()
        {

            dataTable.Reset();
            dataTable = new DataTable();


            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }
        public void fillData()
        {
            DataGridTransaction.DataSource = getDataTable();

            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridTransaction.Columns.Add(colBut);

            DataGridTransaction.Columns[0].ReadOnly = true;
            DataGridTransaction.Columns[1].ReadOnly = true;
            DataGridTransaction.Columns[2].ReadOnly = true;


            // dua kode dibawah ini buat menghapus default column & row di datagrid
            DataGridTransaction.AllowUserToAddRows = false;
            DataGridTransaction.RowHeadersVisible = false;
            con.Close();
            fixSearchBug();
        }
        public void fixSearchBug()
        {
            txtSearch.Text = "CUS001";
            txtSearch.Text = "";
        }
        private void _4InsertTransaksi_Load(object sender, EventArgs e)
        {
            fetchDataCustomer();

            txtOrderID.Text = GenerateID();
            fillData();
            txtCustomer2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomer2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            collection.AddRange(CustomerNames.ToArray());
            txtCustomer2.AutoCompleteCustomSource = collection;

        }
        public string GenerateID()
        {
            string prefix = "ORD"; // ganti dengan tiga huruf awalan yang diinginkan
            string query = "SELECT TOP 1 OrderID FROM Orders WHERE LEFT(OrderID, 3) = @prefix ORDER BY OrderID DESC";
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
        public void fetchDataCustomer()
        {
            string sql = "SELECT * FROM Customers";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            var names = new List<string>();
            while (dr.Read())
            {
                names.Add(dr["Name"]as string);
                comboCustomer.Items.Add(dr["Name"]);
            }
            CustomerNames = names;
            con.Close();
        }
        public void GetCustomerName(string customerName)
        {
            SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE Name=@customerName", con);
            cmd.Parameters.AddWithValue("@customerName", customerName);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string temp_Id = dr["CustomerID"].ToString();
                txtCustomerID.Text = temp_Id;
            }

            con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustomerName(comboCustomer.Text);
        }
        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES (@OrderID, @CustomerID, @OrderDate)", con);
            cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
            cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
            DateTime orderDate = DateTime.Parse(DatePicker.Text);
            cmd.Parameters.AddWithValue("@OrderDate", orderDate);



            cmd.ExecuteNonQuery();
            con.Close();
            DataGridTransaction.Columns.Clear();
            dataTable.Clear();

            fillData();
        }
        public void UpdateData()
        {
            con.Open();
            string tid = txtOrderID.Text;
            string t0 = txtCustomerID.Text;
            string t1 = comboCustomer.Text;
            DateTime temp = DatePicker.Value;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Orders SET CustomerID = @t0, OrderDate = @temp WHERE OrderID = @tid;";
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@temp", temp);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridTransaction.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
            MessageBox.Show("Update Berhasil!!!");
            fixSearchBug();
        }
        public void DeleteData()
        {
            string orderId = txtOrderID.Text;

            // Check if the order is referenced by OrderItems table
            bool isReferenced = false;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM OrderItems WHERE OrderID = @OrderId", con))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                isReferenced = count > 0;
            }

            if (isReferenced)
            {
                // Display warning message box if the order is referenced by OrderItems table
                MessageBox.Show("Transaksi ini sedang berlangsung, tidak dapat dihapus!!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Delete the order if it is not referenced by OrderItems table
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderId", con))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            DataGridTransaction.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();

        }
        public void ClearInsert()
        {
            txtOrderID.Text = GenerateID();
            txtCustomerID.Text = "";
            comboCustomer.Text = "";
            comboSearch.Text = "";
            txtSearch.Text = "";
        }
        public string GetCustomerID(string id)
        {
            string customerName = "";

            SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerID=@customerId", con);
            cmd.Parameters.AddWithValue("@customerId", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                customerName = dr["Name"].ToString();
            }

            con.Close();

            return customerName;
        }
        public void ViewData()
        {

            int selectedIndex = DataGridTransaction.CurrentCell.RowIndex;
            txtOrderID.Text = DataGridTransaction.Rows[selectedIndex].Cells[0 + 1].Value.ToString();
            txtCustomerID.Text = DataGridTransaction.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
            comboCustomer.Text = GetCustomerID(txtCustomerID.Text);

            // ambil nilai tanggal dari Cells pada baris yang dipilih, lalu set ke dalam DateTimePicker
            DateTime dateValues;
            if (DateTime.TryParse(DataGridTransaction.Rows[selectedIndex].Cells[2 + 1].Value.ToString(), out dateValues))
            {
                DatePicker.Value = dateValues;
            }
        }
        public void DisplayDataSearch()
        {
            con.Open();

            if (comboSearch.Text == "")
            {
                string q = "SELECT OrderID, CustomerID, OrderDate FROM Orders WHERE OrderID LIKE '" + txtSearch.Text + "%' OR CustomerID LIKE'" + txtSearch.Text + "%' OR OrderDate LIKE'" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridTransaction.DataSource = st;
            }
            else if (comboSearch.Text == "Order ID")
            {
                string q = "SELECT OrderID, CustomerID, OrderDate FROM Orders WHERE OrderID LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridTransaction.DataSource = st;
            }
            else if (comboSearch.Text == "Customer ID")
            {
                string q = "SELECT OrderID, CustomerID, OrderDate FROM Orders WHERE CustomerID LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridTransaction.DataSource = st;
            }
            else if (comboSearch.Text == "DD-MM-YY")
            {
                string searchValue = txtSearch.Text.Trim();
                string searchQuery = "SELECT * FROM Orders WHERE OrderDate = @searchValue";

                if (DateTime.TryParseExact(searchValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                {
                    // jika input dari textbox merupakan format tanggal yang valid

                    SqlCommand cmd = new SqlCommand(searchQuery, con);
                    cmd.Parameters.AddWithValue("@searchValue", dateValue);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    dataTable.Clear();
                    sda.Fill(dataTable);
                    DataGridTransaction.DataSource = dataTable;

                }
            }

            con.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
            txtOrderID.Text = GenerateID();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearInsert();
            txtOrderID.Text = GenerateID();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            ClearInsert();
            txtOrderID.Text = GenerateID();
        }

        private void InsertOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayDataSearch();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
            ClearInsert();
            txtOrderID.Text = GenerateID();
        }

        private void DataGridTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridTransaction.Columns[e.ColumnIndex].Name == "")
            {
                ViewData();
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertOrderItems customer = new InsertOrderItems();
            customer.Show();
            customer.FormClosed += InsertOrders_FormClosed;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
