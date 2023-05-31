
namespace AoLPsD
{
    partial class FormHargaBarang
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboNamaBarang = new System.Windows.Forms.ComboBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtIDNamaBarang = new System.Windows.Forms.TextBox();
            this.txtIDPerusahaan = new System.Windows.Forms.TextBox();
            this.comboPerusahaan = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DataGridHargaBarang = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtViewHargaBarang = new System.Windows.Forms.TextBox();
            this.txtViewIDNamaBarang = new System.Windows.Forms.TextBox();
            this.txtViewNamaBarang = new System.Windows.Forms.TextBox();
            this.txtViewPerusahaan = new System.Windows.Forms.TextBox();
            this.txtViewIDPerusahaan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridHargaBarang)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(663, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "PT Tae Young Abadi Jaya   -    Harga Barang";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(163, 180);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 50);
            this.btnUpdate.TabIndex = 35;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nama Barang";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nama Perusahaan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboNamaBarang);
            this.groupBox1.Controls.Add(this.txtHarga);
            this.groupBox1.Controls.Add(this.txtIDNamaBarang);
            this.groupBox1.Controls.Add(this.txtIDPerusahaan);
            this.groupBox1.Controls.Add(this.comboPerusahaan);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Location = new System.Drawing.Point(16, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 246);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Harga";
            // 
            // comboNamaBarang
            // 
            this.comboNamaBarang.FormattingEnabled = true;
            this.comboNamaBarang.Location = new System.Drawing.Point(136, 65);
            this.comboNamaBarang.Name = "comboNamaBarang";
            this.comboNamaBarang.Size = new System.Drawing.Size(173, 21);
            this.comboNamaBarang.TabIndex = 38;
            this.comboNamaBarang.SelectedIndexChanged += new System.EventHandler(this.comboNamaBarang_SelectedIndexChanged);
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(136, 110);
            this.txtHarga.Multiline = true;
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(99, 20);
            this.txtHarga.TabIndex = 21;
            // 
            // txtIDNamaBarang
            // 
            this.txtIDNamaBarang.Enabled = false;
            this.txtIDNamaBarang.Location = new System.Drawing.Point(332, 65);
            this.txtIDNamaBarang.Name = "txtIDNamaBarang";
            this.txtIDNamaBarang.Size = new System.Drawing.Size(99, 20);
            this.txtIDNamaBarang.TabIndex = 21;
            // 
            // txtIDPerusahaan
            // 
            this.txtIDPerusahaan.Enabled = false;
            this.txtIDPerusahaan.Location = new System.Drawing.Point(332, 34);
            this.txtIDPerusahaan.Name = "txtIDPerusahaan";
            this.txtIDPerusahaan.Size = new System.Drawing.Size(99, 20);
            this.txtIDPerusahaan.TabIndex = 21;
            this.txtIDPerusahaan.TextChanged += new System.EventHandler(this.txtIDPerusahaan_TextChanged);
            // 
            // comboPerusahaan
            // 
            this.comboPerusahaan.FormattingEnabled = true;
            this.comboPerusahaan.Location = new System.Drawing.Point(136, 33);
            this.comboPerusahaan.Name = "comboPerusahaan";
            this.comboPerusahaan.Size = new System.Drawing.Size(173, 21);
            this.comboPerusahaan.TabIndex = 38;
            this.comboPerusahaan.SelectedIndexChanged += new System.EventHandler(this.comboPerusahaan_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(57, 180);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 50);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Harga Barang";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(269, 180);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 50);
            this.btnInsert.TabIndex = 34;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 312);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(173, 309);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(212, 20);
            this.txtSearch.TabIndex = 52;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // DataGridHargaBarang
            // 
            this.DataGridHargaBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridHargaBarang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridHargaBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridHargaBarang.Location = new System.Drawing.Point(12, 358);
            this.DataGridHargaBarang.Name = "DataGridHargaBarang";
            this.DataGridHargaBarang.Size = new System.Drawing.Size(957, 188);
            this.DataGridHargaBarang.TabIndex = 51;
            this.DataGridHargaBarang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridHargaBarang_CellClick);
            this.DataGridHargaBarang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridHargaBarang_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(888, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Harga Barang"});
            this.comboBox.Location = new System.Drawing.Point(66, 309);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(83, 21);
            this.comboBox.TabIndex = 54;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtViewHargaBarang);
            this.groupBox2.Controls.Add(this.txtViewIDNamaBarang);
            this.groupBox2.Controls.Add(this.txtViewNamaBarang);
            this.groupBox2.Controls.Add(this.txtViewPerusahaan);
            this.groupBox2.Controls.Add(this.txtViewIDPerusahaan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(509, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 246);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // txtViewHargaBarang
            // 
            this.txtViewHargaBarang.Enabled = false;
            this.txtViewHargaBarang.Location = new System.Drawing.Point(136, 110);
            this.txtViewHargaBarang.Name = "txtViewHargaBarang";
            this.txtViewHargaBarang.Size = new System.Drawing.Size(99, 20);
            this.txtViewHargaBarang.TabIndex = 21;
            // 
            // txtViewIDNamaBarang
            // 
            this.txtViewIDNamaBarang.Enabled = false;
            this.txtViewIDNamaBarang.Location = new System.Drawing.Point(332, 65);
            this.txtViewIDNamaBarang.Name = "txtViewIDNamaBarang";
            this.txtViewIDNamaBarang.Size = new System.Drawing.Size(99, 20);
            this.txtViewIDNamaBarang.TabIndex = 21;
            // 
            // txtViewNamaBarang
            // 
            this.txtViewNamaBarang.Enabled = false;
            this.txtViewNamaBarang.Location = new System.Drawing.Point(136, 66);
            this.txtViewNamaBarang.Name = "txtViewNamaBarang";
            this.txtViewNamaBarang.Size = new System.Drawing.Size(173, 20);
            this.txtViewNamaBarang.TabIndex = 21;
            // 
            // txtViewPerusahaan
            // 
            this.txtViewPerusahaan.Enabled = false;
            this.txtViewPerusahaan.Location = new System.Drawing.Point(136, 37);
            this.txtViewPerusahaan.Name = "txtViewPerusahaan";
            this.txtViewPerusahaan.Size = new System.Drawing.Size(173, 20);
            this.txtViewPerusahaan.TabIndex = 21;
            // 
            // txtViewIDPerusahaan
            // 
            this.txtViewIDPerusahaan.Enabled = false;
            this.txtViewIDPerusahaan.Location = new System.Drawing.Point(332, 34);
            this.txtViewIDPerusahaan.Name = "txtViewIDPerusahaan";
            this.txtViewIDPerusahaan.Size = new System.Drawing.Size(99, 20);
            this.txtViewIDPerusahaan.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Harga Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nama Barang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Nama Perusahaan";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(331, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 50);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormHargaBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 559);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.DataGridHargaBarang);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox);
            this.Name = "FormHargaBarang";
            this.Text = "FormHargaBarang";
            this.Load += new System.EventHandler(this.FormHargaBarang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridHargaBarang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView DataGridHargaBarang;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.ComboBox comboNamaBarang;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtIDNamaBarang;
        private System.Windows.Forms.TextBox txtIDPerusahaan;
        private System.Windows.Forms.ComboBox comboPerusahaan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtViewHargaBarang;
        private System.Windows.Forms.TextBox txtViewIDNamaBarang;
        private System.Windows.Forms.TextBox txtViewIDPerusahaan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtViewNamaBarang;
        private System.Windows.Forms.TextBox txtViewPerusahaan;
    }
}