namespace restaurant
{
    partial class Menulerigor
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
            this.Menus = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AnaYemek = new System.Windows.Forms.Button();
            this.Icecek = new System.Windows.Forms.Button();
            this.Corba = new System.Windows.Forms.Button();
            this.Tatli = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Ara_Sıcak = new System.Windows.Forms.Button();
            this.Hepsi = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Geri_don = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Menus)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menus
            // 
            this.Menus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Menus.Location = new System.Drawing.Point(3, 3);
            this.Menus.Name = "Menus";
            this.Menus.Size = new System.Drawing.Size(794, 326);
            this.Menus.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Menus, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 332);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.tableLayoutPanel2.Controls.Add(this.Tatli, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.Corba, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Icecek, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AnaYemek, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 332);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 118);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // AnaYemek
            // 
            this.AnaYemek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnaYemek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AnaYemek.Location = new System.Drawing.Point(3, 3);
            this.AnaYemek.Name = "AnaYemek";
            this.AnaYemek.Size = new System.Drawing.Size(92, 53);
            this.AnaYemek.TabIndex = 0;
            this.AnaYemek.Text = "Ana Yemek";
            this.AnaYemek.UseVisualStyleBackColor = true;
            this.AnaYemek.Click += new System.EventHandler(this.AnaYemek_Click);
            // 
            // Icecek
            // 
            this.Icecek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Icecek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icecek.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icecek.Location = new System.Drawing.Point(101, 3);
            this.Icecek.Name = "Icecek";
            this.Icecek.Size = new System.Drawing.Size(96, 53);
            this.Icecek.TabIndex = 1;
            this.Icecek.Text = "Icecek";
            this.Icecek.UseVisualStyleBackColor = true;
            this.Icecek.Click += new System.EventHandler(this.Icecek_Click_1);
            // 
            // Corba
            // 
            this.Corba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Corba.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Corba.Location = new System.Drawing.Point(3, 62);
            this.Corba.Name = "Corba";
            this.Corba.Size = new System.Drawing.Size(92, 53);
            this.Corba.TabIndex = 2;
            this.Corba.Text = "Corba";
            this.Corba.UseVisualStyleBackColor = true;
            this.Corba.Click += new System.EventHandler(this.Corba_Click);
            // 
            // Tatli
            // 
            this.Tatli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tatli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tatli.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Tatli.Location = new System.Drawing.Point(101, 62);
            this.Tatli.Name = "Tatli";
            this.Tatli.Size = new System.Drawing.Size(96, 53);
            this.Tatli.TabIndex = 3;
            this.Tatli.Text = "Tatli";
            this.Tatli.UseVisualStyleBackColor = true;
            this.Tatli.Click += new System.EventHandler(this.Tatli_Click_1);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.5F));
            this.tableLayoutPanel3.Controls.Add(this.Hepsi, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Ara_Sıcak, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(200, 332);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(103, 118);
            this.tableLayoutPanel3.TabIndex = 3;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // Ara_Sıcak
            // 
            this.Ara_Sıcak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ara_Sıcak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Ara_Sıcak.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Ara_Sıcak.Location = new System.Drawing.Point(3, 3);
            this.Ara_Sıcak.Name = "Ara_Sıcak";
            this.Ara_Sıcak.Size = new System.Drawing.Size(97, 55);
            this.Ara_Sıcak.TabIndex = 2;
            this.Ara_Sıcak.Text = "Ara Sıcak";
            this.Ara_Sıcak.UseVisualStyleBackColor = true;
            this.Ara_Sıcak.Click += new System.EventHandler(this.Ara_Sıcak_Click);
            // 
            // Hepsi
            // 
            this.Hepsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hepsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Hepsi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Hepsi.Location = new System.Drawing.Point(3, 64);
            this.Hepsi.Name = "Hepsi";
            this.Hepsi.Size = new System.Drawing.Size(97, 51);
            this.Hepsi.TabIndex = 3;
            this.Hepsi.Text = "Hepsi";
            this.Hepsi.UseVisualStyleBackColor = true;
            this.Hepsi.Click += new System.EventHandler(this.Hepsi_Click_1);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.Geri_don, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(303, 332);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(497, 118);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // Geri_don
            // 
            this.Geri_don.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Geri_don.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Geri_don.Location = new System.Drawing.Point(3, 3);
            this.Geri_don.Name = "Geri_don";
            this.Geri_don.Size = new System.Drawing.Size(491, 112);
            this.Geri_don.TabIndex = 3;
            this.Geri_don.Text = "Geri Dön";
            this.Geri_don.UseVisualStyleBackColor = true;
            this.Geri_don.Click += new System.EventHandler(this.Geri_don_Click);
            // 
            // Menulerigor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Menulerigor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menulerigor";
            ((System.ComponentModel.ISupportInitialize)(this.Menus)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Menus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Tatli;
        private System.Windows.Forms.Button Corba;
        private System.Windows.Forms.Button Icecek;
        private System.Windows.Forms.Button AnaYemek;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button Hepsi;
        private System.Windows.Forms.Button Ara_Sıcak;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Geri_don;
    }
}