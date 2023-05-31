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
using System.Data.SqlClient;
namespace AoLv2
{
    public partial class InsertInvoices : Form
    {
        SqlConnection con = new SqlConnection(ConnectionStringHelper.GetConnectionString());
        DataTable dataTable = new DataTable();
        SqlCommand cmd;
        SqlDataReader dr;
        public InsertInvoices()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Invoices", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }

        public void fillData()
        {
            DataGridInvoices.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridInvoices.Columns.Add(colBut);

            DataGridInvoices.Columns[0].ReadOnly = true;
            DataGridInvoices.Columns[1].ReadOnly = true;
            DataGridInvoices.Columns[2].ReadOnly = true;
            DataGridInvoices.Columns[3].ReadOnly = true;


            // dua kode dibawah ini buat menghapus default column & row di datagrid
            DataGridInvoices.AllowUserToAddRows = false;
            DataGridInvoices.RowHeadersVisible = false;
            DisableViewAndButton();
            con.Close();
            fixSearchBug();
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
            string prefix = "TRD"; // ganti dengan tiga huruf awalan yang diinginkan
            string query = "SELECT TOP 1 InvoiceID FROM Invoices WHERE LEFT(InvoiceID, 3) = @prefix ORDER BY InvoiceID DESC";
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
            SqlCommand cmd = new SqlCommand("INSERT INTO Invoices VALUES (@InvoiceID, @OrderID, @Amount, @IssuedDate)", con);
            cmd.Parameters.AddWithValue("@InvoiceID", txtInvoiceID.Text);
            cmd.Parameters.AddWithValue("@OrderID", comboOrderID.Text);
            int amount = Convert.ToInt32(txtAmount.Text.Replace(",", ""));
            cmd.Parameters.AddWithValue("@Amount", amount);
            DateTime tanggalKeluarBuku = DateTime.Parse(txtInvoiceDate.Text);
            cmd.Parameters.AddWithValue("@IssuedDate", tanggalKeluarBuku);
            

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridInvoices.Columns.Clear();
            dataTable.Clear();

            fillData();
            ClearInsert();
        }

        public void DeleteData()
        {
            string temp = txtInvoiceID.Text;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Invoices WHERE InvoiceID = @t0;";
            cmd.Parameters.AddWithValue("@t0", temp);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridInvoices.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void ViewData()
        {
            ButtonUpdateDeleteEnable();

            int selectedIndex = DataGridInvoices.CurrentCell.RowIndex;

            txtInvoiceID.Text = DataGridInvoices.Rows[selectedIndex].Cells[0].Value.ToString();
            comboOrderID.Text = DataGridInvoices.Rows[selectedIndex].Cells[1].Value.ToString();
            txtAmount.Text = DataGridInvoices.Rows[selectedIndex].Cells[2].Value.ToString();
            DateTime dateValues;
            if (DateTime.TryParse(DataGridInvoices.Rows[selectedIndex].Cells[3].Value.ToString(), out dateValues))
            {
                txtInvoiceDate.Value = dateValues;
            }
            FillCustomerName(comboOrderID.Text, txtOrder);


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

        private void InsertInvoices_Load(object sender, EventArgs e)
        {
            fetchDataOrder();
            txtInvoiceID.Text = GenerateID();
            fillData();
        }

        public void ButtonUpdateDeleteEnable()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void ClearInsert()
        {
            txtInvoiceID.Text = GenerateID();
            comboOrderID.Text = "";
            txtOrder.Text = "";
            txtAmount.Text = "";
            txtInvoiceDate.Value = DateTime.Now;
            txtResult.Text = "";
        }

        public void fixSearchBug()
        {
            txtSearch.Text = "TRD001";
            txtSearch.Text = "";
        }
        public void DisableViewAndButton()
        {
            btnClear.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void comboOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCustomerName(comboOrderID.Text, txtOrder);
            CalculateAmount();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
            txtInvoiceID.Text = GenerateID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            txtInvoiceID.Text = GenerateID();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }


        private void DataGridInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridInvoices.Columns[e.ColumnIndex].Name == "")
            {
                ViewData();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DataTable GetBooksAndQuantitiesFromOrder(string orderID)
        {
            // Create a data table to store the results
            DataTable orderDetails = new DataTable();
            orderDetails.Columns.Add("BookID", typeof(string));
            orderDetails.Columns.Add("Title", typeof(string));
            orderDetails.Columns.Add("Quantity", typeof(int));

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                connection.Open();

                // Retrieve the book and quantity information for the order
                string query = "SELECT oi.BookID, b.Title, oi.Quantity FROM OrderItems oi JOIN Books b ON oi.BookID = b.BookID WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderID);

                // Execute the query and fill the data table
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(orderDetails);
            }

            return orderDetails;
        }

        public decimal GetBookPrice(string bookID)
        {
            // Connect to the database
            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                connection.Open();

                // Retrieve the book's price
                string query = "SELECT Price FROM Books WHERE BookID = @BookID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);

                // Execute the query and return the price
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int price = Convert.ToInt32(result);
                    return price / 100m;
                }
                else
                {
                    return 0m;
                }
            }
        }

        private void DisplayOrderDetails(string orderId, string customerName)
        {
            DataTable orderDetails = GetBooksAndQuantitiesFromOrder(orderId);

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                connection.Open();

                // Retrieve the payment method for the order
                string query = "SELECT PaymentMethod FROM Payments WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                // Execute the query and get the payment method
                string paymentMethod = command.ExecuteScalar().ToString();

                // Create a variable to store the output
                StringBuilder result = new StringBuilder();
                result.AppendLine("==============================================");
                result.AppendLine("=\t\t\tINVOICES\t\t\t=");
                result.AppendLine("==============================================");
                result.AppendLine("Order ID\t\t: " + orderId);
                result.AppendLine("Customer Name\t\t: " + customerName);
                result.AppendLine("Payment Method\t: " + paymentMethod);
                result.AppendLine("==============================================\n");
                result.AppendLine("Book Title\t\t\tQuantity\t\t  Price\t\t\tSub Total");
                result.AppendLine("=========================================================================");

                decimal totalPrice = 0;

                foreach (DataRow row in orderDetails.Rows)
                {
                    string bookTitle = row["Title"].ToString();
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal price = GetBookPrice(row["BookID"].ToString());

                    totalPrice += price * quantity;

                    result.AppendLine(bookTitle + "\t\t\t" + "      " + quantity + "\t\tx\tRp." + price.ToString("0.00") + "\t\tRp." + (price * quantity).ToString("0.00"));
                }

                result.AppendLine("=========================================================================");
                result.AppendLine();
                result.AppendLine("Total:\t\t\t\t\tRp." + totalPrice.ToString("0.00"));

                txtResult.Text = result.ToString();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DisplayOrderDetails(comboOrderID.Text, txtOrder.Text);
 
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtResult.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
