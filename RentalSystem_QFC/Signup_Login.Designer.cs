namespace RentalSystem_QFC
{
    partial class Signup_Login
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel_bg = new System.Windows.Forms.Panel();
            this.pnl_createAdmin = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_confirmPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_adminPword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_adminUname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_createAdmin = new System.Windows.Forms.Button();
            this.pnl_login = new System.Windows.Forms.Panel();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_close = new System.Windows.Forms.PictureBox();
            this.panel_bg.SuspendLayout();
            this.pnl_createAdmin.SuspendLayout();
            this.pnl_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_close)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_bg
            // 
            this.panel_bg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.panel_bg.Controls.Add(this.pnl_createAdmin);
            this.panel_bg.Controls.Add(this.pnl_login);
            this.panel_bg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bg.Location = new System.Drawing.Point(0, 0);
            this.panel_bg.Name = "panel_bg";
            this.panel_bg.Padding = new System.Windows.Forms.Padding(1);
            this.panel_bg.Size = new System.Drawing.Size(351, 388);
            this.panel_bg.TabIndex = 0;
            this.panel_bg.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_bg_Paint);
            // 
            // pnl_createAdmin
            // 
            this.pnl_createAdmin.BackColor = System.Drawing.Color.White;
            this.pnl_createAdmin.Controls.Add(this.btn_cancel);
            this.pnl_createAdmin.Controls.Add(this.txt_confirmPassword);
            this.pnl_createAdmin.Controls.Add(this.label3);
            this.pnl_createAdmin.Controls.Add(this.txt_adminPword);
            this.pnl_createAdmin.Controls.Add(this.label4);
            this.pnl_createAdmin.Controls.Add(this.txt_adminUname);
            this.pnl_createAdmin.Controls.Add(this.label5);
            this.pnl_createAdmin.Controls.Add(this.btn_createAdmin);
            this.pnl_createAdmin.Location = new System.Drawing.Point(12, 12);
            this.pnl_createAdmin.Name = "pnl_createAdmin";
            this.pnl_createAdmin.Size = new System.Drawing.Size(351, 388);
            this.pnl_createAdmin.TabIndex = 10;
            this.pnl_createAdmin.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.White;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_cancel.Location = new System.Drawing.Point(207, 295);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(112, 45);
            this.btn_cancel.TabIndex = 20;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click_1);
            // 
            // txt_confirmPassword
            // 
            this.txt_confirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_confirmPassword.Location = new System.Drawing.Point(29, 246);
            this.txt_confirmPassword.Name = "txt_confirmPassword";
            this.txt_confirmPassword.PasswordChar = '●';
            this.txt_confirmPassword.Size = new System.Drawing.Size(290, 29);
            this.txt_confirmPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Confirm password";
            // 
            // txt_adminPword
            // 
            this.txt_adminPword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adminPword.Location = new System.Drawing.Point(30, 170);
            this.txt_adminPword.Name = "txt_adminPword";
            this.txt_adminPword.PasswordChar = '●';
            this.txt_adminPword.Size = new System.Drawing.Size(289, 29);
            this.txt_adminPword.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password";
            // 
            // txt_adminUname
            // 
            this.txt_adminUname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adminUname.Location = new System.Drawing.Point(29, 99);
            this.txt_adminUname.Name = "txt_adminUname";
            this.txt_adminUname.Size = new System.Drawing.Size(290, 29);
            this.txt_adminUname.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "Username";
            // 
            // btn_createAdmin
            // 
            this.btn_createAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(197)))), ((int)(((byte)(52)))));
            this.btn_createAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createAdmin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createAdmin.ForeColor = System.Drawing.Color.White;
            this.btn_createAdmin.Location = new System.Drawing.Point(28, 295);
            this.btn_createAdmin.Name = "btn_createAdmin";
            this.btn_createAdmin.Size = new System.Drawing.Size(173, 45);
            this.btn_createAdmin.TabIndex = 4;
            this.btn_createAdmin.Text = "Create";
            this.btn_createAdmin.UseVisualStyleBackColor = false;
            this.btn_createAdmin.Click += new System.EventHandler(this.btn_createAdmin_Click_1);
            // 
            // pnl_login
            // 
            this.pnl_login.BackColor = System.Drawing.Color.White;
            this.pnl_login.Controls.Add(this.pic_close);
            this.pnl_login.Controls.Add(this.txt_username);
            this.pnl_login.Controls.Add(this.txt_password);
            this.pnl_login.Controls.Add(this.btn_login);
            this.pnl_login.Controls.Add(this.label2);
            this.pnl_login.Controls.Add(this.label1);
            this.pnl_login.Location = new System.Drawing.Point(4, 39);
            this.pnl_login.Name = "pnl_login";
            this.pnl_login.Size = new System.Drawing.Size(351, 388);
            this.pnl_login.TabIndex = 9;
            this.pnl_login.Visible = false;
            // 
            // txt_username
            // 
            this.txt_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(30, 180);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(290, 29);
            this.txt_username.TabIndex = 0;
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(30, 248);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '●';
            this.txt_password.Size = new System.Drawing.Size(289, 29);
            this.txt_password.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(29, 303);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(291, 50);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // pic_close
            // 
            this.pic_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_close.Image = global::RentalSystem_QFC.Properties.Resources.Cancel_50px;
            this.pic_close.Location = new System.Drawing.Point(316, 3);
            this.pic_close.Name = "pic_close";
            this.pic_close.Size = new System.Drawing.Size(27, 26);
            this.pic_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_close.TabIndex = 4;
            this.pic_close.TabStop = false;
            this.pic_close.Click += new System.EventHandler(this.pic_close_Click);
            // 
            // Signup_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(351, 388);
            this.Controls.Add(this.panel_bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Signup_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Signup_Login_Load);
            this.panel_bg.ResumeLayout(false);
            this.pnl_createAdmin.ResumeLayout(false);
            this.pnl_createAdmin.PerformLayout();
            this.pnl_login.ResumeLayout(false);
            this.pnl_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel_bg;
        public System.Windows.Forms.Panel pnl_createAdmin;
        public System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_confirmPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_adminPword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_adminUname;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btn_createAdmin;
        private System.Windows.Forms.Panel pnl_login;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_close;
    }
}

