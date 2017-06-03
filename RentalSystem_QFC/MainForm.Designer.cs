namespace RentalSystem_QFC
{
    partial class MainForm
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
            this.pnl_header = new System.Windows.Forms.Panel();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_addCustomer = new System.Windows.Forms.Button();
            this.btn_records = new System.Windows.Forms.Button();
            this.btn_perCartridge = new System.Windows.Forms.Button();
            this.btn_perpage = new System.Windows.Forms.Button();
            this.btn_monthly = new System.Windows.Forms.Button();
            this.pnl_body = new System.Windows.Forms.Panel();
            this.lbl_unpaid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.pnl_header.Controls.Add(this.label2);
            this.pnl_header.Controls.Add(this.label1);
            this.pnl_header.Controls.Add(this.lbl_unpaid);
            this.pnl_header.Controls.Add(this.btn_settings);
            this.pnl_header.Controls.Add(this.btn_logout);
            this.pnl_header.Controls.Add(this.btn_addCustomer);
            this.pnl_header.Controls.Add(this.btn_records);
            this.pnl_header.Controls.Add(this.btn_perCartridge);
            this.pnl_header.Controls.Add(this.btn_perpage);
            this.pnl_header.Controls.Add(this.btn_monthly);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1366, 62);
            this.pnl_header.TabIndex = 1;
            // 
            // btn_settings
            // 
            this.btn_settings.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.ua_btn;
            this.btn_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_settings.Location = new System.Drawing.Point(1129, -1);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(105, 65);
            this.btn_settings.TabIndex = 6;
            this.btn_settings.UseVisualStyleBackColor = true;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            this.btn_settings.MouseEnter += new System.EventHandler(this.btn_settings_MouseEnter);
            this.btn_settings.MouseLeave += new System.EventHandler(this.btn_settings_MouseLeave);
            // 
            // btn_logout
            // 
            this.btn_logout.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.logout_btn;
            this.btn_logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_logout.Location = new System.Drawing.Point(1251, -1);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(105, 65);
            this.btn_logout.TabIndex = 5;
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            this.btn_logout.MouseEnter += new System.EventHandler(this.btn_logout_MouseEnter);
            this.btn_logout.MouseLeave += new System.EventHandler(this.btn_logout_MouseLeave_1);
            // 
            // btn_addCustomer
            // 
            this.btn_addCustomer.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.btn_ac;
            this.btn_addCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_addCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_addCustomer.Location = new System.Drawing.Point(1004, -1);
            this.btn_addCustomer.Name = "btn_addCustomer";
            this.btn_addCustomer.Size = new System.Drawing.Size(108, 65);
            this.btn_addCustomer.TabIndex = 4;
            this.btn_addCustomer.UseVisualStyleBackColor = true;
            this.btn_addCustomer.Click += new System.EventHandler(this.btn_addCustomer_Click);
            this.btn_addCustomer.MouseEnter += new System.EventHandler(this.btn_addCustomer_MouseEnter);
            this.btn_addCustomer.MouseLeave += new System.EventHandler(this.btn_addCustomer_MouseLeave);
            // 
            // btn_records
            // 
            this.btn_records.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.pr_btn;
            this.btn_records.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_records.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_records.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_records.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_records.Location = new System.Drawing.Point(559, -1);
            this.btn_records.Name = "btn_records";
            this.btn_records.Size = new System.Drawing.Size(105, 65);
            this.btn_records.TabIndex = 3;
            this.btn_records.UseVisualStyleBackColor = true;
            this.btn_records.Click += new System.EventHandler(this.button1_Click);
            this.btn_records.MouseEnter += new System.EventHandler(this.btn_records_MouseEnter);
            this.btn_records.MouseLeave += new System.EventHandler(this.btn_records_MouseLeave);
            // 
            // btn_perCartridge
            // 
            this.btn_perCartridge.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.pc_btn;
            this.btn_perCartridge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_perCartridge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_perCartridge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_perCartridge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_perCartridge.Location = new System.Drawing.Point(438, -1);
            this.btn_perCartridge.Name = "btn_perCartridge";
            this.btn_perCartridge.Size = new System.Drawing.Size(105, 65);
            this.btn_perCartridge.TabIndex = 2;
            this.btn_perCartridge.UseVisualStyleBackColor = true;
            this.btn_perCartridge.Click += new System.EventHandler(this.btn_perCartridge_Click);
            this.btn_perCartridge.MouseEnter += new System.EventHandler(this.btn_perCartridge_MouseEnter);
            this.btn_perCartridge.MouseLeave += new System.EventHandler(this.btn_perCartridge_MouseLeave);
            // 
            // btn_perpage
            // 
            this.btn_perpage.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.btn_perpage;
            this.btn_perpage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_perpage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_perpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_perpage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_perpage.Location = new System.Drawing.Point(317, -1);
            this.btn_perpage.Name = "btn_perpage";
            this.btn_perpage.Size = new System.Drawing.Size(105, 65);
            this.btn_perpage.TabIndex = 1;
            this.btn_perpage.UseVisualStyleBackColor = true;
            this.btn_perpage.Click += new System.EventHandler(this.btn_perpage_Click);
            this.btn_perpage.MouseEnter += new System.EventHandler(this.btn_perpage_MouseEnter);
            this.btn_perpage.MouseLeave += new System.EventHandler(this.btn_perpage_MouseLeave);
            // 
            // btn_monthly
            // 
            this.btn_monthly.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.btn_monthly_;
            this.btn_monthly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_monthly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_monthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_monthly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_monthly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_monthly.Location = new System.Drawing.Point(196, -1);
            this.btn_monthly.Name = "btn_monthly";
            this.btn_monthly.Size = new System.Drawing.Size(105, 65);
            this.btn_monthly.TabIndex = 0;
            this.btn_monthly.UseVisualStyleBackColor = true;
            this.btn_monthly.Click += new System.EventHandler(this.btn_monthly_Click);
            this.btn_monthly.MouseEnter += new System.EventHandler(this.btn_monthly_MouseEnter);
            this.btn_monthly.MouseLeave += new System.EventHandler(this.btn_monthly_MouseLeave);
            // 
            // pnl_body
            // 
            this.pnl_body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.pnl_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_body.Location = new System.Drawing.Point(0, 62);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(1366, 706);
            this.pnl_body.TabIndex = 2;
            // 
            // lbl_unpaid
            // 
            this.lbl_unpaid.AutoSize = true;
            this.lbl_unpaid.BackColor = System.Drawing.Color.Transparent;
            this.lbl_unpaid.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_unpaid.ForeColor = System.Drawing.Color.Red;
            this.lbl_unpaid.Location = new System.Drawing.Point(201, 1);
            this.lbl_unpaid.Name = "lbl_unpaid";
            this.lbl_unpaid.Size = new System.Drawing.Size(19, 21);
            this.lbl_unpaid.TabIndex = 0;
            this.lbl_unpaid.Text = "0";
            this.lbl_unpaid.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(320, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "0";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(434, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "0";
            this.label2.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pnl_body);
            this.Controls.Add(this.pnl_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Button btn_monthly;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_addCustomer;
        private System.Windows.Forms.Button btn_records;
        private System.Windows.Forms.Button btn_perCartridge;
        private System.Windows.Forms.Button btn_perpage;
        public System.Windows.Forms.Panel pnl_body;
        public System.Windows.Forms.Label lbl_unpaid;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
    }
}