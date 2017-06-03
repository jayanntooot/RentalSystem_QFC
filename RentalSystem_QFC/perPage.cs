using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AesEncDec;
using MySql.Data.MySqlClient;
using System.Threading;

namespace RentalSystem_QFC
{
    public partial class perPage : Form
    {
        public perPage()
        {
            InitializeComponent();
        }
        int numberOfRecords, i, inc = 1, height = 35;
        string stat, paymentStatus, id, name, due_d, due_m, due_yr, due_date;
        public class RetriveTableData
        {
            //CompanyName,Branch,TypesRental, ProductID,dueDate,payment_status
            public string CompanyName, Branch, TypesRental, ProductID, dueDate, payment_status, AccountNo, productName,
                product_qty, product_price;
        }
        void updatePaymentStatus_dueDate()
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "update tbl_customersinfo set payment_status = 2 where curdate() >= dueDate";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                numberOfRecords = cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }
        }

        private void perPage_Load(object sender, EventArgs e)
        {
            updatePaymentStatus_dueDate();
            if (!backgroundWorker1.IsBusy)
            {
                RetriveTableData TObj = new RetriveTableData();
                backgroundWorker1.RunWorkerAsync(TObj);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            RetriveTableData Obj = (RetriveTableData)e.Argument;
            string query = "SELECT *,YEAR(dueDate) AS duedate_year,MONTH(dueDate) as duedate_month, DAY(dueDate) as duedate_day FROM qry_monthly WHERE type_rentalDescription = 'Per Page Rental' ORDER BY payment_status DESC";

            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Obj.product_qty = reader["product_qty"].ToString();
                    Obj.product_price = reader["product_price"].ToString();
                    Obj.AccountNo = reader["AccountNo"].ToString();
                    Obj.CompanyName = reader["CompanyName"].ToString();
                    Obj.Branch = reader["Branch"].ToString();
                    stat = reader["payment_status"].ToString();
                    due_d = reader["duedate_day"].ToString();
                    due_m = reader["duedate_month"].ToString();
                    due_yr = reader["duedate_year"].ToString();
                    if (stat.Equals("1"))
                    {
                        paymentStatus = "PAID";
                    }
                    else
                    {
                        paymentStatus = "UNPAID";
                    }

                    if (due_m.Equals("1"))
                    {
                        due_m = "Jan";
                    }
                    else if (due_m.Equals("2"))
                    {
                        due_m = "Feb";
                    }
                    else if (due_m.Equals("3"))
                    {
                        due_m = "Mar";
                    }
                    else if (due_m.Equals("4"))
                    {
                        due_m = "Apr";
                    }
                    else if (due_m.Equals("5"))
                    {
                        due_m = "May";
                    }
                    else if (due_m.Equals("6"))
                    {
                        due_m = "Jun";
                    }
                    else if (due_m.Equals("7"))
                    {
                        due_m = "Jul";
                    }
                    else if (due_m.Equals("8"))
                    {
                        due_m = "Aug";
                    }
                    else if (due_m.Equals("9"))
                    {
                        due_m = "Sep";
                    }
                    else if (due_m.Equals("10"))
                    {
                        due_m = "Oct";
                    }
                    else if (due_m.Equals("11"))
                    {
                        due_m = "Nov";
                    }
                    else
                    {
                        due_m = "Dec";
                    }
                    Obj.TypesRental = reader["type_rentalDescription"].ToString();
                    Obj.ProductID = reader["ProductID"].ToString();
                    Obj.productName = reader["product_name"].ToString();
                    due_date = due_m + ". " + due_d + "," + due_yr;
                    Obj.dueDate = due_date;
                    Obj.payment_status = paymentStatus;
                    backgroundWorker1.ReportProgress(i, Obj);
                    Thread.Sleep(300);
                    i++;
                    inc++;
                }
                reader.Close();
                dbcon.CloseConnection();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                //34, 19

                RetriveTableData Obj = (RetriveTableData)e.UserState;
                Label displayCompany = new Label();
                this.Controls.Add(displayCompany);
                displayCompany.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayCompany.Size = new Size(255, 21);
                displayCompany.Location = new Point(34, inc * height);
                displayCompany.Text = Obj.CompanyName.ToString();
                pnl_table.Controls.Add(displayCompany);

                Label displayBranch = new Label();
                this.Controls.Add(displayBranch);
                displayBranch.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayBranch.Size = new Size(190, 21);
                displayBranch.Location = new Point(300, inc * height);
                displayBranch.Text = Obj.Branch.ToString();
                pnl_table.Controls.Add(displayBranch);

                //Label displayProductNo = new Label();
                //this.Controls.Add(displayProductNo);
                //displayProductNo.Font = new Font("Segoe", 12, FontStyle.Regular);
                //displayProductNo.AutoSize = true;
                //displayProductNo.Location = new Point(370, inc * height);
                //displayProductNo.Text = Obj.ProductID.ToString();
                //pnl_table.Controls.Add(displayProductNo);

                Label displayProductName = new Label();
                this.Controls.Add(displayProductName);
                displayProductName.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayProductName.AutoSize = true;
                displayProductName.Location = new Point(490, inc * height);
                displayProductName.Text = Obj.productName.ToString();
                pnl_table.Controls.Add(displayProductName);

                Label displayProductPrice = new Label();
                this.Controls.Add(displayProductPrice);
                displayProductPrice.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayProductPrice.AutoSize = true;
                displayProductPrice.Location = new Point(650, inc * height);
                displayProductPrice.Text = Obj.product_price.ToString();
                pnl_table.Controls.Add(displayProductPrice);

                Label displayProductQty = new Label();
                this.Controls.Add(displayProductQty);
                displayProductQty.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayProductQty.AutoSize = true;
                displayProductQty.Location = new Point(750, inc * height);
                displayProductQty.Text = Obj.product_qty.ToString();
                pnl_table.Controls.Add(displayProductQty);

                Label displayDueDate = new Label();
                this.Controls.Add(displayDueDate);
                displayDueDate.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayDueDate.AutoSize = true;
                displayDueDate.Location = new Point(850, inc * height);
                displayDueDate.Text = Obj.dueDate.ToString();
                pnl_table.Controls.Add(displayDueDate);

                Label displayStatus = new Label();
                this.Controls.Add(displayStatus);
                displayStatus.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayStatus.AutoSize = true;
                displayStatus.Location = new Point(980, inc * height);
                displayStatus.Text = Obj.payment_status.ToString();
                if (Obj.payment_status.ToString().Equals("UNPAID"))
                {
                    displayStatus.ForeColor = Color.Red;
                }
                pnl_table.Controls.Add(displayStatus);


                Button btnEdit = new Button();
                this.Controls.Add(btnEdit);
                //btnEdit.BackgroundImage = global::WindowsFormsApplication.Properties.Resources.edit;
                btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnEdit.Size = new System.Drawing.Size(40, 25);
                btnEdit.Text = "Edit";
                btnEdit.Name = Obj.AccountNo.ToString();
                btnEdit.Location = new Point(1080, inc * height);
                // btnEdit.FlatStyle(Flat);
                btnEdit.Click += new EventHandler(this.btn_Click);
                pnl_table.Controls.Add(btnEdit);

                Button btnPayment = new Button();
                this.Controls.Add(btnPayment);
                //btnPayment.BackgroundImage = global::WindowsFormsApplication.Properties.Resources.Coins_48px;
                btnPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnPayment.Size = new System.Drawing.Size(40, 25); ;
                btnPayment.Location = new Point(1125, inc * height);
                btnPayment.Name = Obj.AccountNo.ToString();
                btnPayment.Text = "Pay";
                btnPayment.Click += new EventHandler(this.btn_Click);
                pnl_table.Controls.Add(btnPayment);

                Button btnBill = new Button();
                this.Controls.Add(btnBill);
                //btnBill.BackgroundImage = global::WindowsFormsApplication.Properties.Resources.rFines;
                btnBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnBill.Size = new System.Drawing.Size(40, 25);
                btnBill.Name = Obj.AccountNo.ToString();
                btnBill.Text = "Bill";
                btnBill.Location = new Point(1170, inc * height);
                btnBill.Click += new EventHandler(this.btn_Click);
                pnl_table.Controls.Add(btnBill);

            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();

            }
        }
        bool edit = false, pay = false, bill = false;
        private void btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            id = b.Name;
            name = b.Text;
            if (name.Equals("Edit"))
            {
                edit = true;
                if (edit == true)
                {
                    //    pnl_editCustomerInfo.Visible = true;
                    editCustomer edit_customer = new editCustomer();
                    //   edit_customer.TopLevel = false;
                    //   edit_customer.AutoScroll = false;
                    //  this.pnl_editCustomerInfo.Controls.Add(edit_customer);
                    edit_customer.id_customer = id;
                    edit_customer.loadData(id);
                    edit_customer.Show();
                    edit = false;
                }
            }
            else if (name.Equals("Pay"))
            {

            }
        }
    }
}
