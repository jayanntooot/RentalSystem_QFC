using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using AesEncDec;
using System.IO;
namespace RentalSystem_QFC
{
    public partial class Signup_Login : Form
    {
        public Signup_Login()
        {
            InitializeComponent();
            server = "localhost";
            database = "db_qfcrentalsystem";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        bool checkAdminAcct;
        string hash_password ="";
        string hash_username = "";
        string uname = "";
        string pword = "";
        //Open the connection
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        //Close the connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //Check if the admin account exist
        public void checkAdmin()
        {
            string query = "SELECT * FROM tbl_admin";

            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    checkAdminAcct = true;
                }
                else
                {
                    checkAdminAcct = false;
                }
                startUpForm();
                //close Data Reader
                dataReader.Close();

                //close connection
                this.CloseConnection();
            }
        }
        //Create Admin account
        public void createAdminAcct()
        {
            hash_username = AesCrypt.Encrypt(txt_adminUname.Text);
            hash_password = AesCrypt.Encrypt(txt_adminPword.Text);
            string query = "INSERT INTO tbl_admin (admin_username, admin_password) VALUES('" + hash_username + "', '" + hash_password + "')";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin account has been successfully created.");
                //close connection
                this.CloseConnection();
            }
        }
        //Login Account
        public void userLogin()
        {
            uname = AesCrypt.Encrypt(txt_username.Text);
            pword = AesCrypt.Encrypt(txt_password.Text);
            string query = "SELECT admin_username,admin_password FROM tbl_admin WHERE admin_username='"+uname+"' && admin_password='"+pword+"'";

            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();
                }
                else
                { 
                    MessageBox.Show("Invalid username or password.");
                }
               
                //close Data Reader
                dataReader.Close();

                //close connection
                this.CloseConnection();
            }
        }
        public void startUpForm()
        {
            if (checkAdminAcct == true){
                this.txt_username.Focus();          
                pnl_login.Visible = true;
                
            }
            else {
                 this.txt_adminUname.Focus();
                pnl_createAdmin.Visible = true;
                
            }
        }

        private void Signup_Login_Load(object sender, EventArgs e)
        {
            //MainForm main = new MainForm();
            //main.Show();
            //this.Hide();
            pnl_createAdmin.Location = new Point(0,0);
            pnl_createAdmin.Dock = DockStyle.Fill;
            pnl_login.Location = new Point(0, 0);
            pnl_login.Dock = DockStyle.Fill;
            checkAdmin();

        }
        private void btn_createAdmin_Click(object sender, EventArgs e)
        {
           
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
         
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
           
        }

        private void panel_bg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_login_Click_1(object sender, EventArgs e)
        {
            userLogin();
        }

        private void btn_createAdmin_Click_1(object sender, EventArgs e)
        {
            if (txt_adminPword.Text != txt_confirmPassword.Text)
            {
                MessageBox.Show("Your password did not match.");
            }
            else
            {
                createAdminAcct();
                pnl_createAdmin.Visible = false;
                pnl_login.Visible = true;
                txt_username.Focus();
            }
        }
        public void exit_form()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel ?", "Alert Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                this.Close();

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            exit_form();
        }

        private void pic_close_Click(object sender, EventArgs e)
        {
            exit_form();
        }

    }
}
