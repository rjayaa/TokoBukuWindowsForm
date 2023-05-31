
namespace AoLv2
{
    partial class Menu
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnDetailTransaksi = new System.Windows.Forms.Button();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.btnPelanggan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInvoices);
            this.groupBox3.Controls.Add(this.btnDetailTransaksi);
            this.groupBox3.Location = new System.Drawing.Point(35, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pembayaran ||  Faktur";
            // 
            // btnInvoices
            // 
            this.btnInvoices.Location = new System.Drawing.Point(141, 32);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(100, 50);
            this.btnInvoices.TabIndex = 2;
            this.btnInvoices.Text = "Pembuatan Faktur / Invoice";
            this.btnInvoices.UseVisualStyleBackColor = true;
            this.btnInvoices.Click += new System.EventHandler(this.btnInvoices_Click);
            // 
            // btnDetailTransaksi
            // 
            this.btnDetailTransaksi.Location = new System.Drawing.Point(19, 32);
            this.btnDetailTransaksi.Name = "btnDetailTransaksi";
            this.btnDetailTransaksi.Size = new System.Drawing.Size(100, 50);
            this.btnDetailTransaksi.TabIndex = 1;
            this.btnDetailTransaksi.Text = "Pembayaran Pemesanan";
            this.btnDetailTransaksi.UseVisualStyleBackColor = true;
            this.btnDetailTransaksi.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(141, 32);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(100, 50);
            this.btnTransaksi.TabIndex = 0;
            this.btnTransaksi.Text = "Pemesanan Buku Baru";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(19, 32);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(100, 50);
            this.btnPelanggan.TabIndex = 0;
            this.btnPelanggan.Text = "Pendaftaran Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPelanggan);
            this.groupBox1.Controls.Add(this.btnTransaksi);
            this.groupBox1.Location = new System.Drawing.Point(35, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBook);
            this.groupBox2.Location = new System.Drawing.Point(35, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buku";
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(19, 32);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(222, 50);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Pengelolaan Data Buku";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 426);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu";
            this.Text = "Main Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTransaksi;
        private System.Windows.Forms.Button btnDetailTransaksi;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnPelanggan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBook;
    }
}