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
    public partial class monthly : Form
    {

        public monthly()
        {
            InitializeComponent();
            

        }
 
        //#update tbl_customersinfo set payment_status = 2 where curdate() >= dueDate
        int numberOfRecords,i,inc=1,height=35,dateDue;
        string stat, paymentStatus, id,name, due_d, due_m, due_yr,due_date, current_date;
        bool search_click = false;
        //select datediff(CURDATE(), subdate) from mytable;
        public void make_balance_dueDate()
        {
            //current_date = May 24, 2017 / dateDue = Feb 24, 2017
            // temp_dateDue = June 24, 2017
            //   if (current_date == dateDue)
            //Update the payment status = 2
            //Insert balance
            // }else if (dateDue < current_date ){

            //}
            //Update the payment status = 2
            //Insert balance
            /*
            if(current_date == temp_dateDue)
            {     
            //Insert balance  
            //set new temp_dateDue = July 24, 2017
             }
            */
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
           // set_primaryKey();
            string query = "INSERT INTO tbl_balance SELECT '"+ primary_id_key + "',typesRental,AccountNo,dueDate,(product_price * product_qty) AS amount_bal,'2','" + current_date + "' FROM qry_monthly WHERE CURDATE() = dueDate";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }

        }
        int primary_id_key;
       // string p_id_key;
       //public void set_primaryKey()
       // {
       //     AesCrypt dbcon = new AesCrypt();
       //     dbcon.InitializationDB();
       //     dbcon.OpenConnection();
       //     dbcon.CloseConnection();
       //     string query = "SELECT MAX(id)AS current_id_no FROM tbl_balance ";
       //     if (dbcon.OpenConnection() == true)
       //     {
       //         MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
       //         MySqlDataReader dataReader = cmd.ExecuteReader();
       //         while (dataReader.Read())
       //         {
       //             p_id_key = dataReader["current_id_no"].ToString();

       //         }
       //         if (p_id_key.Equals("") || p_id_key.Equals(" ")) { primary_id_key = 1; }
       //         else { primary_id_key = Convert.ToInt32(p_id_key); primary_id_key = primary_id_key + 1; }
       //         dataReader.Close();
       //         dbcon.CloseConnection();
       //     }
       // }
        public void make_balance_temp_dueDate()
        {

            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
           // set_primaryKey();

            string query = "INSERT INTO tbl_balance SELECT '"+ primary_id_key + "' ,typesRental,AccountNo,dueDate,(product_price * product_qty) AS amount_bal,'2','"+ current_date + "' FROM qry_monthly WHERE CURDATE() = temp_dueDate";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }

        }
        string dueDate, temp_dueDate, set_temp_dueDate, set_tempdueDate, temp_day,temp_month,temp_year, status,
            day_dateDue, month_dateDue, year_dateDue;
        int current_day, current_month, current_year,cur_day;
        DateTime dt = DateTime.Now;
        void updateStatus_payment()
        {
           
            current_date = dt.Date.ToString("yyyy-MM-dd");

            cur_day = dt.Day;
            //current_month = dt.Month;
            //current_year = dt.Year;

            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            
            //MessageBox.Show(current_date);
            string query = "SELECT DAY(dueDate) AS day_dateDue,MONTH(dueDate) AS month_dateDue,YEAR(dueDate) AS year_dateDue,temp_dueDate,DAY(temp_dueDate)AS temp_day,MONTH(temp_dueDate)AS temp_month,YEAR(temp_dueDate)AS temp_year, payment_status  FROM tbl_customersinfo ";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    day_dateDue = reader["day_dateDue"].ToString();
                    month_dateDue = reader["month_dateDue"].ToString();
                    year_dateDue = reader["year_dateDue"].ToString();
                    temp_day = reader["temp_day"].ToString();
                    temp_month = reader["temp_month"].ToString();
                    temp_year = reader["temp_year"].ToString();
                    status = reader["payment_status"].ToString();
                }
                int day_dateDue_int = Convert.ToInt32(day_dateDue);
                int month_dateDue_int = Convert.ToInt32(month_dateDue);
                int temp_day_int = Convert.ToInt32(temp_day);
                int temp_month_int = Convert.ToInt32(temp_month);
                int update_status = Convert.ToInt32(status);
    

                if (temp_day_int <= 9) { temp_day = "0" + temp_day; }
                if (temp_month_int <= 9) { temp_month = "0" + temp_month; }

                if (month_dateDue_int <= 9) { month_dateDue = "0" + month_dateDue; }
                if (day_dateDue_int <= 9) { day_dateDue = "0"+day_dateDue; }

                temp_dueDate = temp_year + "-" + temp_month + "-" + temp_day;
                dueDate = year_dateDue + "-" + month_dateDue + "-" + day_dateDue;

                current_day = Convert.ToInt32(temp_day);
                current_year = Convert.ToInt32(temp_year);
                current_month = Convert.ToInt32(temp_month);

                if (temp_month == "12") { current_month = 1; current_year = current_year + 1; }
                else { current_month = current_month + 1; }
                set_temp_dueDate = current_year + "-" + current_month + "-" + current_day;

                if (current_date.Equals(dueDate))
                {
                    check_bal_added();
                }
               
                if (current_date == temp_dueDate)
                {
                    //if wala..
                    check_bal_added();  
                }
                monthly_notification();
                reader.Close();
                dbcon.CloseConnection();
            }
         }
        bool bal_check_temp_dueDate = false,bal_check_dueDate = false;
        public void check_bal_added()
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            //tiwasa ni, dapat ika isa ra mu update !
            string query = "SELECT acctID_bal FROM tbl_balance WHERE date_bal_added = '"+ current_date + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    bal_check_temp_dueDate = true;
                    bal_check_dueDate = true;
                }
                if (bal_check_temp_dueDate == false)
                {
                    make_balance_temp_dueDate();
                    setNew_temp_dueDate(set_temp_dueDate);
                }
                if (bal_check_dueDate == false)
                {
                    updatePaymentStatus_dueDate();
                    make_balance_dueDate();
                }

                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        void setNew_temp_dueDate(string date)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            //
            string query = "update tbl_customersinfo set temp_dueDate='"+ date + "' where curdate() = temp_dueDate";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                numberOfRecords = cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }
        }
        //void setNew_TempdueDate(string date)
        //{
        //    AesCrypt dbcon = new AesCrypt();
        //    dbcon.InitializationDB();
        //    dbcon.OpenConnection();
        //    dbcon.CloseConnection();

        //    string query = "update tbl_customersinfo set temp_dueDate='" + date + "' where curdate() = dueDate";
        //    if (dbcon.OpenConnection() == true)
        //    {
        //        MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
        //        cmd.ExecuteNonQuery();
        //        numberOfRecords = cmd.ExecuteNonQuery();
        //        dbcon.CloseConnection();
        //    }
        //}
        void updatePaymentStatus_dueDate()
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "update tbl_customersinfo set payment_status = 2 where curdate() = dueDate";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                numberOfRecords = cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }
        }
        string total_unpaid;
        int Total_unpaid;
  
        public void monthly_notification()
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            string query = "SELECT COUNT( DISTINCT acctID_bal) AS acct_unpaid FROM tbl_balance WHERE status_bal = 2 AND typesRental = 1  ";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    total_unpaid = reader["acct_unpaid"].ToString();
                }
                Total_unpaid = Convert.ToInt32(total_unpaid);
                if (Total_unpaid != 0 && Total_unpaid < 10)
                {
                    lbl_unpaid.Visible = true;
                    pnl_notification.Visible = true;
                    lbl_unpaid.Text = "" + Total_unpaid;
                    lbl_unpaid.Location = new Point(11,5);
                    if (Total_unpaid > 10)
                    {
                        lbl_unpaid.Visible = true;
                        pnl_notification.Visible = true;
                        lbl_unpaid.Text = "" + Total_unpaid;
                        lbl_unpaid.Location = new Point(6, 5);
                    }
                }
                else
                {
                    pnl_notification.Visible = false;
                    lbl_unpaid.Visible = false;
                }

                reader.Close();
                dbcon.CloseConnection();
            }
        }
        private void monthly_Load(object sender, EventArgs e)
        {

            updateStatus_payment();
            if (!backgroundWorker1.IsBusy)
            {
                RetriveTableData TObj = new RetriveTableData();
                backgroundWorker1.RunWorkerAsync(TObj);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        public class RetriveTableData
        {
            //CompanyName,Branch,TypesRental, ProductID,dueDate,payment_status
            public string CompanyName, Branch, TypesRental, ProductID, dueDate, payment_status, AccountNo,productName,
                product_qty,product_price;
        }
        string query;
        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            RetriveTableData Obj = (RetriveTableData)e.Argument;
            if (search_click == true)
            {
                query = "SELECT *,YEAR(dueDate) AS duedate_year,MONTH(dueDate) as duedate_month, DAY(dueDate) as duedate_day FROM qry_monthly WHERE accountNo = '"+txt_searchMonthly.Text+"'";
            }
            else
            {
                query = "SELECT *,YEAR(dueDate) AS duedate_year,MONTH(dueDate) as duedate_month, DAY(dueDate) as duedate_day FROM qry_monthly WHERE type_rentalDescription = 'Monthly Rental' ORDER BY payment_status DESC";

            }

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
                    if (stat.Equals("1"))
                    {
                        paymentStatus = "PAID";
                    }
                    else
                    {
                        paymentStatus = "UNPAID";
                    }
                    Obj.TypesRental = reader["type_rentalDescription"].ToString();
                    Obj.ProductID = reader["ProductID"].ToString();
                    Obj.productName = reader["product_name"].ToString();
                    due_d = reader["duedate_day"].ToString();
                    due_m = reader["duedate_month"].ToString();
                    due_yr = reader["duedate_year"].ToString();
                    if (due_m.Equals("1")){due_m = "Jan";}
                    else if (due_m.Equals("2")){due_m = "Feb";}
                    else if (due_m.Equals("3")){due_m = "Mar";}
                    else if (due_m.Equals("4")){due_m = "Apr";}
                    else if (due_m.Equals("5")){due_m = "May";}
                    else if (due_m.Equals("6")){due_m = "Jun";}
                    else if (due_m.Equals("7")){due_m = "Jul";}
                    else if (due_m.Equals("8")){due_m = "Aug";}
                    else if (due_m.Equals("9")){due_m = "Sep";}
                    else if (due_m.Equals("10")){due_m = "Oct";}
                    else if (due_m.Equals("11")){due_m = "Nov";}
                    else{due_m = "Dec";}
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

        public void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
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

                Label displayProductPrice= new Label();
                this.Controls.Add(displayProductPrice);
                displayProductPrice.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayProductPrice.AutoSize = true;
                displayProductPrice.Location = new Point(650, inc * height);
                displayProductPrice.Text ="P "+ Obj.product_price.ToString();
                pnl_table.Controls.Add(displayProductPrice);

                Label displayProductQty = new Label();
                this.Controls.Add(displayProductQty);
                displayProductQty.Font = new Font("Segoe", 12, FontStyle.Regular);
                displayProductQty.AutoSize = true;
                displayProductQty.Location = new Point(750, inc * height);
                displayProductQty.Text = Obj.product_qty.ToString();
                pnl_table.Controls.Add(displayProductQty);

                Label displayDueDate= new Label();
                this.Controls.Add(displayDueDate);
                displayDueDate.Font = new Font("Segoe", 12, FontStyle.Regular);
                //displayDueDate.Size = new Size(100, 30);
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
                if (Obj.payment_status.ToString().Equals("UNPAID")) {
                    displayStatus.ForeColor = Color.Red;
                }
                pnl_table.Controls.Add(displayStatus);


                btnEdit = new Button();
                this.Controls.Add(btnEdit);
                //btnEdit.BackgroundImage = global::WindowsFormsApplication.Properties.Resources.edit;
                btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
              //  btnEdit.ForeColor = Color.Green;
                btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnEdit.Size = new System.Drawing.Size(40, 25);
                btnEdit.Text = "Edit";
                btnEdit.Name = Obj.AccountNo.ToString();
                btnEdit.Location = new Point(1080, inc * height);
               // btnEdit.FlatStyle(Flat);
                btnEdit.Click += new EventHandler(this.btn_Click);
                pnl_table.Controls.Add(btnEdit);

                btnPayment = new Button();
                this.Controls.Add(btnPayment);
                //btnPayment.BackgroundImage = global::WindowsFormsApplication.Properties.Resources.Coins_48px;
              //  btnPayment.ForeColor = Color.Green;
                btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnPayment.Size = new System.Drawing.Size(40, 25); ;
                btnPayment.Location = new Point(1125, inc * height);
                btnPayment.Name = Obj.AccountNo.ToString();
                btnPayment.Text = "Pay";
                btnPayment.Click += new EventHandler(this.btn_Click);
                pnl_table.Controls.Add(btnPayment);

                btnBill = new Button();
                this.Controls.Add(btnBill);
                //btnBill.BackgroundImage = global::WindowsFormsApplication.Properties.Resources.rFines;
               // btnBill.ForeColor = Color.Green;
                btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnBill.Size = new System.Drawing.Size(40, 25);
                btnBill.Name = Obj.AccountNo.ToString();
                btnBill.Text = "Bill";
                btnBill.Location = new Point(1170, inc * height);
                btnBill.Click += new EventHandler(this.btn_Click);
                pnl_table.Controls.Add(btnBill);

            }
        }
        Button btnBill;
        Button btnPayment;
        //NOTE ! The dynamic controls must be clear in search function. In order to display the search output.
        private void btn_search_Click(object sender, EventArgs e)
        {

            if (txt_searchMonthly.Text == "" || txt_searchMonthly.Text == " ")
            {
                MessageBox.Show("Please input a string.");
                txt_searchMonthly.Focus();
            }
            else
            {
                search_click = true;
                updateStatus_payment();
                inc = 1;
                height = 35;       
                if (!backgroundWorker1.IsBusy)
                {
                    this.pnl_table.Controls.Clear();
                    RetriveTableData TObj = new RetriveTableData();
                    backgroundWorker1.RunWorkerAsync(TObj);
                }
            }
        }

        Button btnEdit;
        public void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                search_click = false;
            }
            
        }

        bool edit = true, bill = true, pay = true;
        Payment make_bill;
        transPayment payment;
        editCustomer edit_customer;
        private void btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            id = b.Name;
            name = b.Text;
            if (name.Equals("Edit"))
            {
              
                if (edit == true)
                {
                    bill = false;
                    pay = false;
                    if (edit_customer == null)
                    {
                        edit_customer = new editCustomer();
                        edit_customer.id_customer = id;
                        edit_customer.loadData(id);
                        edit_customer.Owner = this;
                        edit_customer.FormClosed += new FormClosedEventHandler(Edit_customer_FormClosed);
                        edit_customer.Show();
                    }
                    else
                    {
                        edit_customer.Activate();
                    }
                }
            }
            else if (name.Equals("Bill"))
            {
                if (bill == true)
                {
                    edit = false;
                    pay = false;
                    if (make_bill == null)
                    {
                        make_bill = new Payment();
                        make_bill.id_customer = id;
                        make_bill.loadData(id);
                        make_bill.Owner = this;
                        make_bill.FormClosed += new FormClosedEventHandler(Make_bill_FormClosed);
                        make_bill.Show();
                    }
                    else
                    {
                        make_bill.Activate();
                    }
                }
            }
            else
            {
                if (pay == true)
                {
                    edit = false;
                    bill = false;
                    if (payment == null)
                    {
                        get_statementNo(id);
                    }
                    else
                    {
                        payment.Activate();
                    }
                }
            }
        }
        public void get_statementNo(String acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "SELECT accountNo_bill, MAX(statement_no)AS current_statement_no FROM tbl_bill WHERE accountNo_bill = '" + acctID + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    statement_val = dataReader["current_statement_no"].ToString();

                }
               // MessageBox.Show("Value: "+ statement_val);
                dataReader.Close();
                dbcon.CloseConnection();
                check_statementNo(statement_val, acctID);
            }
        }
        string statement_val;
        bool statement = false;
        public void check_statementNo(string statementNo, string id)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            //MessageBox.Show("statement value: " + statementNo +"/ id: "+id);
            if ((statementNo.Equals("") || statementNo.Equals(" "))&&(id.Equals("") || id.Equals(" "))
                || (statementNo.Equals("") || statementNo.Equals(" ")) && (!id.Equals("") || !id.Equals(" ")))
            {
                MessageBox.Show("Don't have a bill yet! ");
                bill = true;
            }
            else
            {
                //SELECT StatementNo FROM tbl_payment WHERE StatementNo ="1" AND accountNo_payment = "110997"
                string query = "SELECT StatementNo FROM tbl_payment WHERE StatementNo = '" + statementNo + "'AND accountNo_payment = '" + id + "'";
                if (dbcon.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        statement = true;

                    }
                   // MessageBox.Show("statement: " + statement);
                    if (statement == true)
                    {
                        MessageBox.Show("Don't have a bill yet. ");
                        bill = true;
                        statement = false;
                    }
                    else
                    {
                        payment = new transPayment();
                        payment.id_customer = id;
                        payment.loadData(id);
                        payment.Owner = this;
                        payment.FormClosed += new FormClosedEventHandler(Payment_FormClosed);
                        payment.Show();
                    }

                    dataReader.Close();
                    dbcon.CloseConnection();
                }
            }
            
        }
        private void Payment_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateStatus_payment();
            inc = 1;
            height = 35;
            if (!backgroundWorker1.IsBusy)
            {
                this.pnl_table.Controls.Clear();
                RetriveTableData TObj = new RetriveTableData();
                backgroundWorker1.RunWorkerAsync(TObj);
            }
            txt_searchMonthly.Text = null;
            txt_searchMonthly.Focus();
            statement = false;
            search_click = false;
            payment = null;
            bill = true;
            edit = true;
        }

        private void Edit_customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateStatus_payment();
            inc = 1;
            height = 35;
            if (!backgroundWorker1.IsBusy)
            {
                this.pnl_table.Controls.Clear();
                RetriveTableData TObj = new RetriveTableData();
                backgroundWorker1.RunWorkerAsync(TObj);
            }
            txt_searchMonthly.Text = null;
            txt_searchMonthly.Focus();
            search_click = false;
            statement = false;
            edit_customer = null;
            bill = true;
            pay = true;
        }

        private void Make_bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateStatus_payment();
            inc = 1;
            height = 35;
            if (!backgroundWorker1.IsBusy)
            {
                this.pnl_table.Controls.Clear();
                RetriveTableData TObj = new RetriveTableData();
                backgroundWorker1.RunWorkerAsync(TObj);
            }
            txt_searchMonthly.Text = null;
            txt_searchMonthly.Focus();
            statement = false;
            search_click = false;
            make_bill = null;
            edit = true;
            pay = true;
        }
      
    }
}
