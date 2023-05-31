using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AoLv2.ConnectionHelper;
using AoLv2.Insertion;
using System.Data.SqlClient;
namespace AoLv2
{
    public partial class InsertPayment : Form
    {
        SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
        DataTable dataTable = new DataTable();
        SqlCommand cmd;
        SqlDataReader dr;
        public InsertPayment()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Payments", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }

        public void fillData()
        {
            DataGridPayment.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridPayment.Columns.Add(colBut);

            DataGridPayment.Columns[0].ReadOnly = true;
            DataGridPayment.Columns[1].ReadOnly = true;
            DataGridPayment.Columns[2].ReadOnly = true;
            DataGridPayment.Columns[3].ReadOnly = true;
            DataGridPayment.Columns[4].ReadOnly = true;

            // dua kode dibawah ini buat menghapus default column & row di datagrid
            DataGridPayment.AllowUserToAddRows = false;
            DataGridPayment.RowHeadersVisible = false;
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
        public void fetchDataOrder()
        {
            string sql = "SELECT * FROM Orders";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboOrderID.Items.Add(dr["OrderID"]);
            }
            con.Close();
        }
        public string GenerateID()
        {
            string prefix = "PAY"; // ganti dengan tiga huruf awalan yang diinginkan
            string query = "SELECT TOP 1 PaymentID FROM Payments WHERE LEFT(PaymentID, 3) = @prefix ORDER BY PaymentID DESC";
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

        // method untuk cari nama dari table customers
        public void FillCustomerName(string orderID, TextBox textBox)
        {
            string query = "SELECT C.Name FROM Customers C INNER JOIN Orders O ON C.CustomerID = O.CustomerID WHERE O.OrderID = @orderID";

            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderID", orderID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string customerName = reader.GetString(0);
                    textBox.Text = customerName;
                }
                else
                {
                    textBox.Text = "";
                }

                reader.Close();
            }
        }
       
        public void InsertData()
        {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Payments VALUES (@PaymentID, @OrderID, @Amount, @PaymentDate, @PaymentMethod)", con);
                cmd.Parameters.AddWithValue("@PaymentID", txtPaymentID.Text);
                cmd.Parameters.AddWithValue("@OrderID", comboOrderID.Text);
                int amount = Convert.ToInt32(txtAmount.Text.Replace(",", ""));
                cmd.Parameters.AddWithValue("@Amount", amount);
                DateTime orderDate = DateTime.Parse(txtPaymentDate.Text);
                cmd.Parameters.AddWithValue("@PaymentDate", orderDate);
                cmd.Parameters.AddWithValue("@PaymentMethod", comboPayment.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                DataGridPayment.Columns.Clear();
                dataTable.Clear();
                
                fillData();
                ClearInsert();
        }

        public void DeleteData()
        {
            string temp = txtPaymentID.Text;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Payments WHERE PaymentID = @t0;";
            cmd.Parameters.AddWithValue("@t0", temp);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridPayment.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }
        public void ButtonUpdateDeleteEnable()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void fixSearchBug()
        {
            txtSearch.Text = "PAY001";
            txtSearch.Text = "";
        }
        public void ViewData()
        {
            ButtonUpdateDeleteEnable();

            int selectedIndex = DataGridPayment.CurrentCell.RowIndex; 
            txtPaymentID.Text = DataGridPayment.Rows[selectedIndex].Cells[0].Value.ToString();
            comboOrderID.Text = DataGridPayment.Rows[selectedIndex].Cells[1].Value.ToString();
            txtAmount.Text = DataGridPayment.Rows[selectedIndex].Cells[2].Value.ToString();
            DateTime dateValues;
            if (DateTime.TryParse(DataGridPayment.Rows[selectedIndex].Cells[3].Value.ToString(), out dateValues))
            {
                txtPaymentDate.Value = dateValues;
            }
            comboPayment.Text = DataGridPayment.Rows[selectedIndex].Cells[4].Value.ToString();
        }

        public void ClearInsert()
        {
            comboOrderID.Text = "";
            txtCusName.Text = "";
            txtPaymentDate.Value = DateTime.Now;
            comboPayment.Text = "";
            txtAmount.Text = "";
            comboSearch.Text = "";
            txtSearch.Text = "";
            txtPaymentID.Text = GenerateID();
        }

        public void CalculateAmount()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                string query = @"SELECT SUM(Books.Price * OrderItems.Quantity) AS TotalAmount 
                         FROM Orders 
                         INNER JOIN OrderItems ON Orders.OrderID = OrderItems.OrderID 
                         INNER JOIN Books ON OrderItems.BookID = Books.BookID 
                         WHERE Orders.OrderID = @OrderID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", comboOrderID.Text);

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    decimal amount = Convert.ToDecimal(result);
                    txtAmount.Text = amount.ToString("N0");
                }
                else
                {
                    txtAmount.Text = "0";
                }
            }
        }

        private void InsertPayment_Load(object sender, EventArgs e)
        {
            fetchDataOrder();
            txtPaymentID.Text = GenerateID();
            fillData();
        }

        private void comboOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCustomerName(comboOrderID.Text, txtCusName);
            CalculateAmount();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
            txtPaymentID.Text = GenerateID();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            txtPaymentID.Text = GenerateID();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridPayment.Columns[e.ColumnIndex].Name == "")
            {
                ViewData();
            }
        }
    }
}
