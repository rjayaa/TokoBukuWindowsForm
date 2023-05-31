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
    public partial class FormHargaBarang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=crudPerusahaan;Integrated Security=True;");

        DataTable dataTable = new DataTable();
        SqlCommand cmd;
        SqlDataReader dr;
        public FormHargaBarang()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Harga_Barang", con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }

            return dataTable;
        }


        public void DisableViewButton()
        {
            txtViewIDPerusahaan.Enabled = false;
            txtViewPerusahaan.Enabled = false;
            txtViewIDNamaBarang.Enabled = false;
            txtViewNamaBarang.Enabled = false;
            txtViewHargaBarang.Enabled = false;

            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;


        }
        public void ClearInsert()
        {
            comboNamaBarang.Text = "";
            comboPerusahaan.Text = "";
            txtHarga.Text = "";
            txtIDNamaBarang.Text = "";
            txtIDPerusahaan.Text = "";
            txtViewNamaBarang.Text = "";
            txtViewPerusahaan.Text = "";
            txtViewHargaBarang.Text = "";
            txtViewIDNamaBarang.Text = "";
            txtViewIDPerusahaan.Text = "";
        }
        public void fillData()
        {
            DataGridHargaBarang.DataSource = getDataTable();
            DataGridViewButtonColumn colEdit = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Name = "";
            colEdit.Text = "View";
            colEdit.UseColumnTextForButtonValue = true;
            DataGridHargaBarang.Columns.Add(colEdit);

            DataGridHargaBarang.Columns[0].ReadOnly = true;
            DataGridHargaBarang.Columns[1].ReadOnly = true;
            DataGridHargaBarang.Columns[2].ReadOnly = true;
            DataGridHargaBarang.Columns[3].ReadOnly = true;

            DisableViewAndButton();
            con.Close();
        }

        public void fetchDataPerusahaan()
        {
            string sql = "SELECT * FROM Perusahaan";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboPerusahaan.Items.Add(dr["Nama_Perusahan"]);
            }
            con.Close();
        }

        public void fetchDataBarang()
        {
            string sql = "SELECT * FROM Barang";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboNamaBarang.Items.Add(dr["Nama_Barang"]);
            }
            con.Close();

        }

        public void DisableViewAndButton()
        {
            txtViewIDPerusahaan.Enabled = false;
            txtViewIDNamaBarang.Enabled = false;
            txtViewHargaBarang.Enabled = false;
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void ButtonUpdateDeleteEnable()
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
        private void FormHargaBarang_Load(object sender, EventArgs e)
        {
            fillData();
            fetchDataPerusahaan();
            fetchDataBarang();
        }

        public void InsertData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Harga_Barang VALUES (@ID_Perusahaan, @ID_Barang,  @Harga_Satuan)", con);
            cmd.Parameters.AddWithValue("@ID_Perusahaan", txtIDPerusahaan.Text);
            cmd.Parameters.AddWithValue("@ID_Barang", txtIDNamaBarang.Text);
            cmd.Parameters.AddWithValue("@Harga_Satuan", txtHarga.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            DataGridHargaBarang.Columns.Clear();
            dataTable.Clear();

            fillData();
            ClearInsert();
        }

        public void UpdateData()
        {
            con.Open();

            string t0 = txtIDPerusahaan.Text;
            string t1 = txtIDNamaBarang.Text;
            string t2 = txtHarga.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Harga_Barang Set Harga_Satuan = @t2 WHERE ID_Perusahaan = @t0 AND ID_Barang = @t1;";
            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.Parameters.AddWithValue("@t1", t1);
            cmd.Parameters.AddWithValue("@t2", t2);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridHargaBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
             ClearInsert();
        }

        public void DeleteData()
        {
            string t0 = txtIDPerusahaan.Text;
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Harga_Barang WHERE ID_Perusahaan = @t0;";

            cmd.Parameters.AddWithValue("@t0", t0);
            cmd.ExecuteNonQuery();
            con.Close();

            DataGridHargaBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void InsertComboPerusahaan()
        {
            string t0 = txtIDPerusahaan.Text;

            string sql = "SELECT Nama_Perusahan FROM Perusahaan WHERE ID_Perusahaan = @id";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", t0);

            con.Open();
            string temp = (string)cmd.ExecuteScalar();
            con.Close();
            comboPerusahaan.Text = temp;
            txtViewPerusahaan.Text = temp;
        }

        public void InsertComboBarang()
        {
            string t0 = txtIDNamaBarang.Text;

            string sql = "SELECT Nama_Barang FROM Barang WHERE ID_Barang = @id";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", t0);

            con.Open();
            string temp = (string)cmd.ExecuteScalar();
            con.Close();
            comboNamaBarang.Text = temp;
            txtViewNamaBarang.Text = temp;
        }

        public void DisplaySearch()
        {
            con.Open();
            if(comboBox.Text == "Harga Barang")
            {
                string q = "SELECT ID_Perusahaan, ID_Barang, Harga_Satuan FROM Harga_Barang WHERE Harga_Satuan LIKE'" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridHargaBarang.DataSource = st;
            }
            con.Close();
        }
        public void ViewData()
        {
            ButtonUpdateDeleteEnable();
            int selectedIndex = DataGridHargaBarang.CurrentCell.RowIndex;
            txtIDPerusahaan.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[0+1].Value.ToString();
            txtIDNamaBarang.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[1+1].Value.ToString();
            InsertComboPerusahaan();
            InsertComboBarang();
            txtHarga.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[2].Value.ToString();
            
            
            txtViewIDPerusahaan.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[0 + 1].Value.ToString();
            txtViewIDNamaBarang.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
            txtViewHargaBarang.Text =  DataGridHargaBarang.Rows[selectedIndex].Cells[2 + 1].Value.ToString();

        }
        public void ViewData2()
        {
            ButtonUpdateDeleteEnable();
            int selectedIndex = DataGridHargaBarang.CurrentCell.RowIndex;
            txtIDPerusahaan.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[0].Value.ToString();
            txtIDNamaBarang.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[1].Value.ToString();
            InsertComboPerusahaan();
            InsertComboBarang();
            txtHarga.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[2].Value.ToString();


            txtViewIDPerusahaan.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[0].Value.ToString();
            txtViewIDNamaBarang.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[1].Value.ToString();
            txtViewHargaBarang.Text = DataGridHargaBarang.Rows[selectedIndex].Cells[2].Value.ToString();
        }
        private void comboPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM Perusahaan WHERE Nama_Perusahan=@companyName", con);
            cmd.Parameters.AddWithValue("@companyName", comboPerusahaan.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string temp_Id = dr["ID_Perusahaan"].ToString();

                txtIDPerusahaan.Text = temp_Id;
            }

            con.Close();
        }

        private void comboNamaBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM Barang WHERE Nama_Barang=@productName", con);
            cmd.Parameters.AddWithValue("@productName", comboNamaBarang.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string temp_Id = dr["ID_Barang"].ToString();

                txtIDNamaBarang.Text = temp_Id;
            }

            con.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void txtIDPerusahaan_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDPerusahaan.Text))
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }
        }

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }

        private void DataGridHargaBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                ViewData();
            }
        }

        private void DataGridHargaBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                ViewData2();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplaySearch();
        }
    }
}
