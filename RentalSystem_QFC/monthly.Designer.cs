namespace RentalSystem_QFC
{
    partial class monthly
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
            this.label9 = new System.Windows.Forms.Label();
            this.txt_searchMonthly = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnl_table = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_notification = new System.Windows.Forms.Panel();
            this.lbl_unpaid = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.pnl_notification.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 32);
            this.label9.TabIndex = 40;
            this.label9.Text = "Monthly Printer Rental";
            // 
            // txt_searchMonthly
            // 
            this.txt_searchMonthly.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txt_searchMonthly.Location = new System.Drawing.Point(438, 122);
            this.txt_searchMonthly.Name = "txt_searchMonthly";
            this.txt_searchMonthly.Size = new System.Drawing.Size(398, 32);
            this.txt_searchMonthly.TabIndex = 41;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pnl_table
            // 
            this.pnl_table.Location = new System.Drawing.Point(61, 216);
            this.pnl_table.Name = "pnl_table";
            this.pnl_table.Size = new System.Drawing.Size(1252, 427);
            this.pnl_table.TabIndex = 59;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(547, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 21);
            this.label10.TabIndex = 62;
            this.label10.Text = "Item Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(912, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 21);
            this.label13.TabIndex = 65;
            this.label13.Text = "Due Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(806, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 21);
            this.label12.TabIndex = 64;
            this.label12.Text = "Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(357, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 21);
            this.label8.TabIndex = 61;
            this.label8.Text = "Branch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(96, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 60;
            this.label6.Text = "Company ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(711, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 21);
            this.label14.TabIndex = 66;
            this.label14.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1175, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 67;
            this.label1.Text = "Action";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1049, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 68;
            this.label2.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.panel1.Location = new System.Drawing.Point(100, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 2);
            this.panel1.TabIndex = 69;
            // 
            // pnl_notification
            // 
            this.pnl_notification.BackColor = System.Drawing.Color.Transparent;
            this.pnl_notification.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.icon_notify;
            this.pnl_notification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_notification.Controls.Add(this.lbl_unpaid);
            this.pnl_notification.Location = new System.Drawing.Point(348, 12);
            this.pnl_notification.Name = "pnl_notification";
            this.pnl_notification.Size = new System.Drawing.Size(45, 39);
            this.pnl_notification.TabIndex = 72;
            this.pnl_notification.Visible = false;
            // 
            // lbl_unpaid
            // 
            this.lbl_unpaid.AutoSize = true;
            this.lbl_unpaid.BackColor = System.Drawing.Color.Transparent;
            this.lbl_unpaid.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_unpaid.ForeColor = System.Drawing.Color.White;
            this.lbl_unpaid.Location = new System.Drawing.Point(6, 5);
            this.lbl_unpaid.Name = "lbl_unpaid";
            this.lbl_unpaid.Size = new System.Drawing.Size(34, 25);
            this.lbl_unpaid.TabIndex = 71;
            this.lbl_unpaid.Text = "00";
            this.lbl_unpaid.Visible = false;
            // 
            // btn_search
            // 
            this.btn_search.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.search_btn;
            this.btn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(842, 120);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(79, 36);
            this.btn_search.TabIndex = 70;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // monthly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 703);
            this.Controls.Add(this.pnl_notification);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_searchMonthly);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnl_table);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "monthly";
            this.Text = "monthly";
            this.Load += new System.EventHandler(this.monthly_Load);
            this.pnl_notification.ResumeLayout(false);
            this.pnl_notification.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_searchMonthly;
        private System.Windows.Forms.Panel pnl_table;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbl_unpaid;
        public System.Windows.Forms.Panel pnl_notification;
    }
}