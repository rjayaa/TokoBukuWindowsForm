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
    public partial class FormPerusahaan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=crudPerusahaan;Integrated Security=True;");
        
        DataTable dataTable = new DataTable();


        public FormPerusahaan()
        {
            InitializeComponent();
        }

        

        public DataTable getDataTable() {
            dataTable.Reset();
            dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Perusahaan", con)) {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dataTable.Load(rd);
            }
           
            return dataTable;
        }
        public string GenerateID()
        {
            string connectionString = "Data Source=RJAYAA\\SQLEXPRESS;Initial Catalog=crudPerusahaan;Integrated Security=True";
            string query = "SELECT TOP 1 ID_Perusahaan FROM Perusahaan ORDER BY ID_Perusahaan DESC";
            string id = "PD";

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
        
       

        public void fillData() {
            DataGridPerusahaan.DataSource = getDataTable();
            DataGridViewButtonColumn colBut = new DataGridViewButtonColumn();
            colBut.Name = "";
            colBut.Text = "View";
            colBut.UseColumnTextForButtonValue = true;
            DataGridPerusahaan.Columns.Add(colBut);

            DataGridPerusahaan.Columns[0].ReadOnly = true;
            DataGridPerusahaan.Columns[1].ReadOnly = true;
            DataGridPerusahaan.Columns[2].ReadOnly = true;
            DataGridPerusahaan.Columns[3].ReadOnly = true;
            DataGridPerusahaan.Columns[4].ReadOnly = true;
            DataGridPerusahaan.Columns[5].ReadOnly = true;
            DisableViewAndButton();
            con.Close();
        }
        public void InsertData() {

            con.Open();
            
            SqlCommand cmd = new SqlCommand("INSERT INTO Perusahaan VALUES (@ID_Perusahaan,@Nama_Perusahaan,@NPWP_Perusahaan,@Kontak_Perusahaan,@Kontak_2_Perusahaan,@Alamat_Perusahaan)", con);
            cmd.Parameters.AddWithValue("@ID_Perusahaan", GenerateID());
            cmd.Parameters.AddWithValue("@Nama_Perusahaan", txtNamaPerusahaan.Text);
            cmd.Parameters.AddWithValue("@NPWP_Perusahaan", txtNPWP.Text);
            cmd.Parameters.AddWithValue("@Kontak_Perusahaan", txtKontakPerusahaan.Text);
            cmd.Parameters.AddWithValue("@Kontak_2_Perusahaan", txtKontakPerusahaan2.Text);
            cmd.Parameters.AddWithValue("@Alamat_Perusahaan", txtAlamatPerusahaan.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            DataGridPerusahaan.Columns.Clear();
            dataTable.Clear();
            
            fillData();
            
        }

        public void ButtonUpdateDeleteEnable()
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
        public void ViewData()
        {
            ButtonUpdateDeleteEnable();

            int selectedIndex = DataGridPerusahaan.CurrentCell.RowIndex;

            txtNamaPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[1 + 1].Value.ToString();
            txtNPWP.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[2 + 1].Value.ToString();
            txtKontakPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[3 + 1].Value.ToString();
            txtKontakPerusahaan2.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[4 + 1].Value.ToString();
            txtAlamatPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[5 + 1].Value.ToString();

            txtIDPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[0+1].Value.ToString();
            txtViewNama.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[1+1].Value.ToString();
            txtViewNPWP.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[2+1].Value.ToString();
            txtViewKontak.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[3+1].Value.ToString();
            txtViewKontak2.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[4+1].Value.ToString();
            txtViewAlamat.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[5+1].Value.ToString();


        }

        public void ViewData2()
        {
            ButtonUpdateDeleteEnable();

            int selectedIndex = DataGridPerusahaan.CurrentCell.RowIndex;

            txtNamaPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[1].Value.ToString();
            txtNPWP.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[2].Value.ToString();
            txtKontakPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[3].Value.ToString();
            txtKontakPerusahaan2.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[4].Value.ToString();
            txtAlamatPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[5].Value.ToString();

            txtIDPerusahaan.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[0 ].Value.ToString();
            txtViewNama.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[1].Value.ToString();
            txtViewNPWP.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[2].Value.ToString();
            txtViewKontak.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[3].Value.ToString();
            txtViewKontak2.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[4].Value.ToString();
            txtViewAlamat.Text = DataGridPerusahaan.Rows[selectedIndex].Cells[5].Value.ToString();
        }
        public void DeleteData()
        {
            string t0 = txtIDPerusahaan.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Perusahaan WHERE ID_Perusahaan = @t0;";

            cmd.Parameters.AddWithValue("@t0", t0);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridPerusahaan.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void UpdateData()
        {
            con.Open();
            string t0 = txtIDPerusahaan.Text;
            string t1 = txtNamaPerusahaan.Text;
            string t2 = txtNPWP.Text;
            string t3 = txtKontakPerusahaan.Text;
            string t4 = txtKontakPerusahaan2.Text;
            string t5 = txtAlamatPerusahaan.Text;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Perusahaan SET Nama_Perusahan = @t1,NPWP_Perusahaan = @t2,Kontak_1_Perusahaan = @t3,Kontak_2_Perusahaan = @t4,Alamat_Perusahaan = @t5 WHERE ID_Perusahaan = @t0;";
            cmd.Parameters.AddWithValue("@t0",t0);
            cmd.Parameters.AddWithValue("@t1",t1);
            cmd.Parameters.AddWithValue("@t2",t2);
            cmd.Parameters.AddWithValue("@t3",t3);
            cmd.Parameters.AddWithValue("@t4",t4);
            cmd.Parameters.AddWithValue("@t5",t5);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridPerusahaan.Columns.Clear();

            dataTable.Clear();
            fillData();

            txtIDPerusahaan.Text = t0;
            txtViewNama.Text = t1;
            txtViewNPWP.Text = t2;
            txtViewKontak.Text = t3;
            txtViewKontak2.Text = t4;
            txtViewAlamat.Text = t5;
            ClearInsert();


        }


        public void DisplaySearch()
        {
            con.Open();
            if(comboBox.Text == "Nama Perusahaan")
            {
                string q = "SELECT ID_Perusahaan, Nama_Perusahan, NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE Nama_Perusahan LIKE '"+txtSearch.Text+"%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;
                
            }else if(comboBox.Text == "NPWP Perusahaan")
            {
                string q = "SELECT ID_Perusahaan, Nama_Perusahan, NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE NPWP_Perusahaan LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;
                con.Close();
            }else if(comboBox.Text == "Kontak Perusahaan")
            {
                string query = "SELECT ID_Perusahaan, Nama_Perusahan,NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE Kontak_1_Perusahaan OR Kontak_2_Perusahaan LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;
            }else if(comboBox.Text == "Alamat Perusahaan")
            {
                string query = "SELECT ID_Perusahaan, Nama_Perusahan,NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE Alamat_Perusahaan LIKE '" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;
            }
            con.Close();
        }
        public void DisableViewAndButton(){
            txtViewNama.Enabled     = false;
            txtViewNPWP.Enabled   = false;
            txtViewKontak.Enabled     = false;
            txtViewKontak2.Enabled = false;
            txtViewAlamat.Enabled   = false;
            btnClear.Enabled        = false;
            btnDelete.Enabled       = false;
            btnUpdate.Enabled       = false;
        }
        private void FormPerusahaan_Load(object sender, EventArgs e)
        {
            fillData();
        }

    

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            InsertData();
            ClearInsert();
        }

        private void txtNamaPerusahaan_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaPerusahaan.Text))
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }
        }

        public void ClearInsert()
        {
            txtIDPerusahaan.Text = "";
            txtNamaPerusahaan.Text = "";
            txtNPWP.Text = "";
            txtKontakPerusahaan.Text = "";
            txtKontakPerusahaan2.Text = "";
            txtAlamatPerusahaan.Text = "";

            txtViewNama.Text = "";
            txtViewNPWP.Text = "";
            txtViewKontak.Text = "";
            txtViewKontak2.Text = "";
            txtViewAlamat.Text = "";

            comboBox.Text = "";
            txtSearch.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void DataGridPerusahaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                ViewData();
            }
        }

        private void DataGridPerusahaan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                ViewData2();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplaySearch();
        }
    }
}
