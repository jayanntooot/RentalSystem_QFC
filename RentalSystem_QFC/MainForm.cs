using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AesEncDec;
using MySql.Data.MySqlClient;

namespace RentalSystem_QFC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
       public bool monthPanel = false,
            pagePanel = false,
            cartridgePanel = false, 
            recordsPanel = false,
            customerPanel = false;
       public int page = 0,
            month = 0,
            cartridge = 0,
            records = 0,
            customer = 0;
        Signup_Login update_admin_acct;
        private void btn_settings_Click(object sender, EventArgs e)
        {
            if (update_admin_acct == null)
            {
                update_admin_acct = new Signup_Login();
                update_admin_acct.pnl_createAdmin.Visible = true;
                update_admin_acct.btn_createAdmin.Text = "Update";
                update_admin_acct.Owner = this;
                update_admin_acct.FormClosed += new FormClosedEventHandler(Update_admin_acct_FormClosed);
                update_admin_acct.Show();
            }
            else
            {
                update_admin_acct.Activate();
            }
            
            //payment.Show();
        }

        private void btn_monthly_MouseEnter(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.btn_monthly.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.m_btn_hover;
        }
        
        private void btn_monthly_MouseLeave(object sender, EventArgs e)
        {
            this.btn_monthly.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.btn_monthly_;
        }

        private void btn_perpage_MouseEnter(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.btn_perpage.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.pp_btn_h;
        }

        private void btn_perpage_MouseLeave(object sender, EventArgs e)
        {
            this.btn_perpage.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.btn_perpage;
        }

        private void btn_perCartridge_MouseEnter(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.btn_perCartridge.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.pc_btn_hover;
        }

        private void btn_perCartridge_MouseLeave(object sender, EventArgs e)
        {
            this.btn_perCartridge.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.pc_btn;
        }

        private void btn_records_MouseEnter(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.btn_records.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.pr_btn_hover;
        }

        private void btn_records_MouseLeave(object sender, EventArgs e)
        {
            this.btn_records.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.pr_btn;
        }

        private void btn_addCustomer_MouseEnter(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.btn_addCustomer.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.btn_ac_hover;
        }

        private void btn_addCustomer_MouseLeave(object sender, EventArgs e)
        {
            this.btn_addCustomer.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.btn_ac;
        }

        private void btn_settings_MouseEnter(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.btn_settings.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.ua_btn_hover;
        }

        private void btn_settings_MouseLeave(object sender, EventArgs e)
        {
            this.btn_settings.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.ua_btn;
        }

        private void btn_logout_MouseEnter(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.btn_logout.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.logout_hover;
        }

        private void btn_logout_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void btn_logout_MouseLeave_1(object sender, EventArgs e)
        {
            this.btn_logout.BackgroundImage = global::RentalSystem_QFC.Properties.Resources.logout_btn;
        }

        private void Update_admin_acct_FormClosed(object sender, FormClosedEventArgs e)
        {
            update_admin_acct = null;
        }

        private void btn_addCustomer_Click(object sender, EventArgs e)
        {
            recordsPanel = false;
            monthPanel = false;
            pagePanel = false;
            cartridgePanel = false;
            customerPanel = true;
            if (customerPanel == true)
            {
                if (customer == 0)
                {
                    pnl_body.Controls.Clear();
                    addCustomer addCustomerForm = new addCustomer();
                    addCustomerForm.TopLevel = false;
                    addCustomerForm.AutoScroll = false;
                    this.pnl_body.Controls.Add(addCustomerForm);
                    addCustomerForm.Show();
                    records = 0;
                    month = 0;
                    page = 0;
                    cartridge = 0;
                    customer = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recordsPanel = true;
            monthPanel = false;
            pagePanel = false;
            cartridgePanel = false;
            customerPanel = false;
            if (recordsPanel == true)
            {
                if(records == 0)
                {
                    pnl_body.Controls.Clear();
                    paymentRecords recordsForm = new paymentRecords();
                    recordsForm.TopLevel = false;
                    recordsForm.AutoScroll = false;
                    this.pnl_body.Controls.Add(recordsForm);
                    recordsForm.Show();
                    records = 1;
                    month = 0;
                    page = 0;
                    cartridge = 0;
                    customer = 0;
                }          
            }
        }
        private void btn_monthly_Click(object sender, EventArgs e)
        {
            monthPanel = true;
            cartridgePanel = false;
            recordsPanel = false;
            pagePanel = false;
            customerPanel = false;
            if (monthPanel == true)
            {
                if (month == 0)
                {
                    pnl_body.Controls.Clear();
                    monthly monthlyForm = new monthly();
                    monthlyForm.TopLevel = false;
                    monthlyForm.AutoScroll = false;
                    this.pnl_body.Controls.Add(monthlyForm);
                    monthlyForm.Show();                    
                    page = 0;
                    month = 1;
                    cartridge = 0;
                    records = 0;
                    customer = 0;
                }              
            }         
        }
        private void btn_perpage_Click(object sender, EventArgs e)
        {       
            monthPanel = false;
            cartridgePanel = false;
            recordsPanel = false;
            customerPanel = false;
            pagePanel = true;
            if (pagePanel == true)
            {               
                if (page == 0)
                {
                    pnl_body.Controls.Clear();
                    perPage pageForm = new perPage();
                    pageForm.TopLevel = false;
                    pageForm.AutoScroll = false;
                    this.pnl_body.Controls.Add(pageForm);
                    pageForm.Show();
                    month = 0;
                    page = 1;
                    cartridge = 0;
                    records = 0;
                    customer = 0;
                }              
            }      
        }
        private void btn_perCartridge_Click(object sender, EventArgs e)
        {
            cartridgePanel = true;
            monthPanel = false;
            pagePanel = false;
            recordsPanel = false;
            customerPanel = false;
            if (cartridgePanel == true)
            {
                if (cartridge == 0)
                {
                    pnl_body.Controls.Clear();
                    perCartridge cartridgeForm = new perCartridge();
                    cartridgeForm.TopLevel = false;
                    cartridgeForm.AutoScroll = false;
                    this.pnl_body.Controls.Add(cartridgeForm);
                    cartridgeForm.Show();
                    cartridge = 1;
                    month = 0;
                    page = 0;
                    records = 0;
                    customer = 0;
                }
            }         
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout ?", "Alert Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                monthly m = new monthly();
                

                Signup_Login logout = new Signup_Login();
                this.Close();
                logout.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
           

        }
        //string total_unpaid;
        //int Total_unpaid;

        //public void monthly_notification()
        //{
        //    AesCrypt dbcon = new AesCrypt();
        //    dbcon.InitializationDB();
        //    dbcon.OpenConnection();
        //    dbcon.CloseConnection();
        //    string query = "SELECT COUNT( DISTINCT acctID_bal) AS acct_unpaid FROM tbl_balance WHERE status_bal = 2 AND typesRental = 1  ";
        //    if (dbcon.OpenConnection() == true)
        //    {
        //        MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            total_unpaid = reader["acct_unpaid"].ToString();
        //        }
        //        monthly m = new monthly();

        //        Total_unpaid = Convert.ToInt32(total_unpaid);
        //        if (Total_unpaid > 0)
        //        {
        //            m.lbl_unpaid.Visible = true;
        //            m.pnl_notification.Visible = true;
        //            m.lbl_unpaid.Text = "" + Total_unpaid;
        //        }
        //        else
        //        {
        //            m.pnl_notification.Visible = false;
        //            lbl_unpaid.Visible = false;
        //        }

        //        reader.Close();
        //        dbcon.CloseConnection();
        //    }
        //}
        private void MainForm_Load(object sender, EventArgs e)
        {
           // monthly_notification();
            monthPanel = true;
            if (monthPanel == true)
            {
                monthly monthlyForm = new monthly();
                monthlyForm.TopLevel = false;
                monthlyForm.AutoScroll = false;
                this.pnl_body.Controls.Add(monthlyForm);
                monthlyForm.Show();
            }
           
        }
    }
}
