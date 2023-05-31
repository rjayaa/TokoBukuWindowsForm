
namespace AoLPsD
{
    partial class FormPerusahaan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnExit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.DataGridPerusahaan = new System.Windows.Forms.DataGridView();
            this.txtViewAlamat = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtViewKontak2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtViewKontak = new System.Windows.Forms.TextBox();
            this.txtViewNPWP = new System.Windows.Forms.TextBox();
            this.txtViewNama = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtIDPerusahaan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtAlamatPerusahaan = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKontakPerusahaan2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKontakPerusahaan = new System.Windows.Forms.TextBox();
            this.txtNPWP = new System.Windows.Forms.TextBox();
            this.txtNamaPerusahaan = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPerusahaan)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(845, 9);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 66;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Pt Tae Young Abadi Jaya  |   Tabel Perusahaan";
            // 
            // DataGridPerusahaan
            // 
            this.DataGridPerusahaan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridPerusahaan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPerusahaan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGridPerusahaan.Location = new System.Drawing.Point(0, 518);
            this.DataGridPerusahaan.Name = "DataGridPerusahaan";
            this.DataGridPerusahaan.Size = new System.Drawing.Size(961, 277);
            this.DataGridPerusahaan.TabIndex = 64;
            this.DataGridPerusahaan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPerusahaan_CellClick);
            this.DataGridPerusahaan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPerusahaan_CellContentClick);
            // 
            // txtViewAlamat
            // 
            this.txtViewAlamat.Location = new System.Drawing.Point(479, 252);
            this.txtViewAlamat.Name = "txtViewAlamat";
            this.txtViewAlamat.Size = new System.Drawing.Size(312, 63);
            this.txtViewAlamat.TabIndex = 63;
            this.txtViewAlamat.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Alamat Perusahaan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Kontak 2";
            // 
            // txtViewKontak2
            // 
            this.txtViewKontak2.Location = new System.Drawing.Point(643, 187);
            this.txtViewKontak2.Name = "txtViewKontak2";
            this.txtViewKontak2.Size = new System.Drawing.Size(148, 20);
            this.txtViewKontak2.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Kontak 1";
            // 
            // txtViewKontak
            // 
            this.txtViewKontak.Location = new System.Drawing.Point(479, 187);
            this.txtViewKontak.Name = "txtViewKontak";
            this.txtViewKontak.Size = new System.Drawing.Size(148, 20);
            this.txtViewKontak.TabIndex = 58;
            // 
            // txtViewNPWP
            // 
            this.txtViewNPWP.Location = new System.Drawing.Point(582, 116);
            this.txtViewNPWP.Name = "txtViewNPWP";
            this.txtViewNPWP.Size = new System.Drawing.Size(209, 20);
            this.txtViewNPWP.TabIndex = 57;
            // 
            // txtViewNama
            // 
            this.txtViewNama.Location = new System.Drawing.Point(582, 81);
            this.txtViewNama.Name = "txtViewNama";
            this.txtViewNama.Size = new System.Drawing.Size(209, 20);
            this.txtViewNama.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "NPWP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Nama Perusahaan";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.txtIDPerusahaan);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(446, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 370);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Data";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(374, 296);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtIDPerusahaan
            // 
            this.txtIDPerusahaan.Enabled = false;
            this.txtIDPerusahaan.Location = new System.Drawing.Point(399, 67);
            this.txtIDPerusahaan.Name = "txtIDPerusahaan";
            this.txtIDPerusahaan.Size = new System.Drawing.Size(75, 20);
            this.txtIDPerusahaan.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID Perusahaan";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(33, 296);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 50);
            this.btnClear.TabIndex = 52;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtAlamatPerusahaan
            // 
            this.txtAlamatPerusahaan.Location = new System.Drawing.Point(45, 252);
            this.txtAlamatPerusahaan.Name = "txtAlamatPerusahaan";
            this.txtAlamatPerusahaan.Size = new System.Drawing.Size(312, 63);
            this.txtAlamatPerusahaan.TabIndex = 51;
            this.txtAlamatPerusahaan.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Alamat Perusahaan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Kontak 2";
            // 
            // txtKontakPerusahaan2
            // 
            this.txtKontakPerusahaan2.Location = new System.Drawing.Point(209, 187);
            this.txtKontakPerusahaan2.Name = "txtKontakPerusahaan2";
            this.txtKontakPerusahaan2.Size = new System.Drawing.Size(148, 20);
            this.txtKontakPerusahaan2.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Kontak 1";
            // 
            // txtKontakPerusahaan
            // 
            this.txtKontakPerusahaan.Location = new System.Drawing.Point(45, 187);
            this.txtKontakPerusahaan.Name = "txtKontakPerusahaan";
            this.txtKontakPerusahaan.Size = new System.Drawing.Size(148, 20);
            this.txtKontakPerusahaan.TabIndex = 46;
            // 
            // txtNPWP
            // 
            this.txtNPWP.Location = new System.Drawing.Point(148, 116);
            this.txtNPWP.Name = "txtNPWP";
            this.txtNPWP.Size = new System.Drawing.Size(209, 20);
            this.txtNPWP.TabIndex = 45;
            // 
            // txtNamaPerusahaan
            // 
            this.txtNamaPerusahaan.Location = new System.Drawing.Point(148, 81);
            this.txtNamaPerusahaan.Name = "txtNamaPerusahaan";
            this.txtNamaPerusahaan.Size = new System.Drawing.Size(209, 20);
            this.txtNamaPerusahaan.TabIndex = 44;
            this.txtNamaPerusahaan.TextChanged += new System.EventHandler(this.txtNamaPerusahaan_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "NPWP";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Nama Perusahaan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 370);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert / Update";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(245, 296);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 50);
            this.btnInsert.TabIndex = 25;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(139, 296);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 50);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Nama Perusahaan",
            "NPWP Perusahaan",
            "Kontak Perusahaan",
            "Alamat Perusahaan"});
            this.comboBox.Location = new System.Drawing.Point(48, 442);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 67;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(184, 442);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(213, 20);
            this.txtSearch.TabIndex = 68;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(51, 426);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Search";
            // 
            // FormPerusahaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 795);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DataGridPerusahaan);
            this.Controls.Add(this.txtViewAlamat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtViewKontak2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtViewKontak);
            this.Controls.Add(this.txtViewNPWP);
            this.Controls.Add(this.txtViewNama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtAlamatPerusahaan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtKontakPerusahaan2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtKontakPerusahaan);
            this.Controls.Add(this.txtNPWP);
            this.Controls.Add(this.txtNamaPerusahaan);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPerusahaan";
            this.Text = "FormPerusahaan";
            this.Load += new System.EventHandler(this.FormPerusahaan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPerusahaan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DataGridPerusahaan;
        private System.Windows.Forms.RichTextBox txtViewAlamat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtViewKontak2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtViewKontak;
        private System.Windows.Forms.TextBox txtViewNPWP;
        private System.Windows.Forms.TextBox txtViewNama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtIDPerusahaan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox txtAlamatPerusahaan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKontakPerusahaan2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKontakPerusahaan;
        private System.Windows.Forms.TextBox txtNPWP;
        private System.Windows.Forms.TextBox txtNamaPerusahaan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label13;
    }
}