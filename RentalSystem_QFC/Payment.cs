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


namespace RentalSystem_QFC
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        public string id_customer;
        String day_rented, month_rented, year_rented, due_d, due_m, due_yr;
        private void label12_Click(object sender, EventArgs e)
        {

        }
        //monthly update_bool;
        //MainForm main;
        //SELECT acctID_bal, SUM(amount_bal) AS previous_bal FROM tbl_balance WHERE acctID_bal = "110996"
        //select accountNo,ProductID,product_name, (product_price * product_qty) as current_bal
        //from qry_monthly where accountNo = "110996"
        int stament_no;
        double current_bal, previous_bal, total_amountDue;
        string statement_val,cur_date,diplay_curdate,get_prevBalance, get_currentBalance,invoice_no, dba_month,dba_year;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void dba_date_bal(string id)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "SELECT acctID_bal, MONTH(date_bal_added) AS dba_month, YEAR(date_bal_added) AS dba_year FROM tbl_balance WHERE acctID_bal= '" + id + "' AND status_bal = 2 AND date_bal_added = CURDATE()";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    dba_month = dataReader["dba_month"].ToString();
                    dba_year = dataReader["dba_year"].ToString();
                }
                // MessageBox.Show(dba_day);
                //    dba_day_int = Convert.ToInt32(dba_day);
                //    dba_month_int = Convert.ToInt32(dba_month);

                /////tiwasa!
                //if (dba_month_int <= 9) { dba_month = "0" + dba_month; }
                //if (dba_day_int <= 9) { dba_day = "0" + dba_day; }

                //dba_date = dba_year + "-" + dba_month + "-"+ dba_day;
                // MessageBox.Show(cur_date +"=="+ dba_date);
              
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        string year,month;
        public void get_curBal(String acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            year = DateTime.Now.ToString("yyyy");
            month = DateTime.Now.ToString("MM");          
            string query = "SELECT acctID_bal, amount_bal FROM qry_balance WHERE acctID_bal= '"+acctID+"' AND status_bal = 2 AND dba_month = '"+month+"' AND dba_year = '"+year+"'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    get_currentBalance = dataReader["amount_bal"].ToString();;

                }
                if (get_currentBalance == "" || get_currentBalance == " ")
                {
                    lbl_currentBal.Text = "0.00";
                }
                else
                {
                    current_bal = Convert.ToDouble(get_currentBalance);
                    lbl_currentBal.Text = "" + current_bal.ToString("0.00");    
                }
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        public void get_prevBal(string acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "SELECT acctID_bal, SUM(amount_bal) AS previous_bal  FROM qry_balance WHERE acctID_bal= '" + acctID + "' AND status_bal = 2 AND dba_month < '" + month + "' AND dba_year <= '" + year + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    get_prevBalance = dataReader["previous_bal"].ToString();   
                }
                if (get_prevBalance == "" || get_prevBalance == " ")
                {
                    lbl_prevBal.Text = "0.00";
                }
                else
                {
                    previous_bal = Convert.ToDouble(get_prevBalance);
                    lbl_prevBal.Text = "" + previous_bal;
                }
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        public void update_statementNo(String acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "SELECT accountNo_bill, statement_no FROM tbl_bill WHERE accountNo_bill ='" + acctID + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    statement_val = dataReader["statement_no"].ToString();
                  
                }
                if (statement_val == "")
                {
                    stament_no = 1;
                }
                else
                {
                    stament_no = Convert.ToInt32(statement_val);
                    stament_no = stament_no + 1;
                }

                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        
        public void make_billing()
        {
            cur_date = DateTime.Now.ToString("yyyy-MM-dd");
            update_statementNo(lbl_accno.Text);
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            string query = "INSERT INTO tbl_bill (statement_no,accountNo_bill,invoiceNo,DateOfmake_bill) "
                + "VALUES('" + stament_no + "','" + lbl_accno.Text + "','" + txt_invoiceNo.Text + "', '" + cur_date + "')";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Make a bill successful.");
                this.Close();
                dbcon.CloseConnection();
            }
        }
        public void getInvoice_no(String acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "SELECT accountNo_bill,invoiceNo FROM tbl_bill WHERE accountNo_bill ='" + acctID + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    invoice_no = dataReader["invoiceNo"].ToString();
                    if (invoice_no == "")
                    {
                        txt_invoiceNo.Focus();
                    }
                    else
                    {
                        txt_invoiceNo.Text = "" + invoice_no;
                        txt_invoiceNo.Enabled = false;
                    }

                }

                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        string from_dueDate_month, from_dueDate_year, from_dueDate_day;
        bool chk_payment = false;
        public void check_payment(string accID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "SELECT accountNo_payment FROM tbl_payment WHERE accountNo_payment ='" + accID + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    chk_payment = true;
                }
             
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
      //  string date_rented;
        public void last_dueDate(string accID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            //from_last_dueDate_month,from_last_dueDate_year,from_last_dueDate_day
            //string query = "select acctID_bal,from_dueDate_month,from_dueDate_year,from_dueDate_day from qry_from_to_bill WHERE acctID_bal = '" + accID+"' AND status_bal = 1";
            string query = "select acctID_bal,from_last_dueDate_month,from_last_dueDate_year,from_last_dueDate_day from qry_from_to_bill WHERE acctID_bal = '" + accID + "' AND status_bal = 1";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    //from_dueDate_month = dataReader["from_dueDate_month"].ToString();
                    //from_dueDate_year = dataReader["from_dueDate_year"].ToString();
                    //from_dueDate_day = dataReader["from_dueDate_day"].ToString();
                    from_dueDate_month = dataReader["from_last_dueDate_month"].ToString();
                    from_dueDate_year = dataReader["from_last_dueDate_year"].ToString();
                    from_dueDate_day = dataReader["from_last_dueDate_day"].ToString();

                }

                if (from_dueDate_month.Equals("1")) { from_dueDate_month = "January"; }
                else if (from_dueDate_month.Equals("2")) { from_dueDate_month = "February"; }
                else if (from_dueDate_month.Equals("3")) { from_dueDate_month = "March"; }
                else if (from_dueDate_month.Equals("4")) { from_dueDate_month = "April"; }
                else if (from_dueDate_month.Equals("5")) { from_dueDate_month = "May"; }
                else if (from_dueDate_month.Equals("6")) { from_dueDate_month = "June"; }
                else if (from_dueDate_month.Equals("7")) { from_dueDate_month = "July"; }
                else if (from_dueDate_month.Equals("8")) { from_dueDate_month = "August"; }
                else if (from_dueDate_month.Equals("9")) { from_dueDate_month = "September"; }
                else if (from_dueDate_month.Equals("10")) { from_dueDate_month = "October"; }
                else if (from_dueDate_month.Equals("11")) { from_dueDate_month = "November"; }
                else { from_dueDate_month = "December"; }
           //     MessageBox.Show(from_dueDate_month + " " + from_dueDate_day + ", " + from_dueDate_year);
                lbl_from.Text = from_dueDate_month + " " + from_dueDate_day + ", " + from_dueDate_year;
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        string current_date, temp_day, temp_month, temp_year, t_month,dueDate;
        DateTime dt = DateTime.Now;
       
        public void loadData(String acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            check_payment(acctID);
            get_curBal(acctID);
            get_prevBal(acctID);
            getInvoice_no(acctID);
            string query = "SELECT *,YEAR(dueDate) AS duedate_year,MONTH(dueDate) as duedate_month, DAY(dueDate) as duedate_day, YEAR(dateRented) AS r_year,MONTH(dateRented) as r_month, DAY(dateRented) as r_day FROM qry_monthly WHERE AccountNo='" + acctID + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    lbl_accno.Text = dataReader["AccountNo"].ToString();
                    lbl_companyName.Text = dataReader["CompanyName"].ToString();
                    lbl_branch.Text = dataReader["Branch"].ToString();
                    lbl_address.Text = dataReader["Address"].ToString();
                    lbl_typeRental.Text = dataReader["type_rentalDescription"].ToString();
                    lbl_productID.Text = dataReader["ProductID"].ToString();
                    lbl_productName.Text = dataReader["product_name"].ToString();
                    lbl_productPrice.Text = dataReader["product_price"].ToString();
                    lbl_productQty.Text = dataReader["product_qty"].ToString();
                    day_rented = dataReader["r_day"].ToString();
                    month_rented = dataReader["r_month"].ToString();
                    year_rented = dataReader["r_year"].ToString();
                    due_d = dataReader["duedate_day"].ToString();
                    due_m = dataReader["duedate_month"].ToString();
                    due_yr = dataReader["duedate_year"].ToString();

                    //date rented
                    if (month_rented.Equals("1")) { month_rented = "January"; }
                    else if (month_rented.Equals("2")) { month_rented = "February"; }
                    else if (month_rented.Equals("3")) { month_rented = "March"; }
                    else if (month_rented.Equals("4")) { month_rented = "April"; }
                    else if (month_rented.Equals("5")) { month_rented = "May"; }
                    else if (month_rented.Equals("6")) { month_rented = "June"; }
                    else if (month_rented.Equals("7")) { month_rented = "July"; }
                    else if (month_rented.Equals("8")) { month_rented = "August"; }
                    else if (month_rented.Equals("9")) { month_rented = "September"; }
                    else if (month_rented.Equals("10")) { month_rented = "October"; }
                    else if (month_rented.Equals("11")) { month_rented = "November"; }
                    else { month_rented = "December"; }
                  //  due date
                    if (due_m.Equals("1")) { due_m = "January"; }
                    else if (due_m.Equals("2")) { due_m = "February"; }
                    else if (due_m.Equals("3")) { due_m = "March"; }
                    else if (due_m.Equals("4")) { due_m = "April"; }
                    else if (due_m.Equals("5")) { due_m = "May"; }
                    else if (due_m.Equals("6")) { due_m = "June"; }
                    else if (due_m.Equals("7")) { due_m = "July"; }
                    else if (due_m.Equals("8")) { due_m = "August"; }
                    else if (due_m.Equals("9")) { due_m = "September"; }
                    else if (due_m.Equals("10")) { due_m = "October"; }
                    else if (due_m.Equals("11")) { due_m = "November"; }
                    else { due_m = "December"; }
                    // MessageBox.Show(month_rented);
                    //cbo_month.SelectedItem = month_rented;
                    //cbo_day.SelectedItem = day_rented;
                    //cbo_year.SelectedItem = year_rented;
                    dueDate = due_yr  + "-" + due_m  + "-" + due_d;
                    //Tiwasa ni !
                    //   lbl_from.Text = month_rented + " " + day_rented + ", " + year_rented;
                    if (chk_payment == true)
                    {
                        last_dueDate(acctID);
                        lbl_dueDate.Text = due_m + " " + due_d + ", " + due_yr;
                    }
                    else
                    {

                        lbl_from.Text = month_rented + " " + day_rented + ", " + year_rented;
                        set_TOpayment(acctID);
                    }
                    //  set_TOpayment(acctID);
                    /*
                            if()



                    */
                   
                }
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel ?", "Alert Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //main = new MainForm();
                //update_bool = new monthly();
                //main.pnl_body.Controls.Clear();
                //update_bool.TopLevel = false;
                //update_bool.AutoScroll = false;
                //main.pnl_body.Controls.Add(update_bool);
                //update_bool.Show();
                this.Close();             
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            diplay_curdate = DateTime.Now.ToString("MMM dd, yyyy");
            lbl_date.Text = diplay_curdate;
            //get_curBal(id_customer);
            //get_prevBal(id_customer);
            total_amountDue = previous_bal + current_bal;
            lbl_total.Text = ""+total_amountDue.ToString("0.00");
            loadData(id_customer);
        }

        private void btn_makeBill_Click(object sender, EventArgs e)
        {
            make_billing();
        }
        void set_TOpayment(string id)
        {
            current_date = dt.Date.ToString("yyyy-MM-dd");
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            //MessageBox.Show(current_date);
            string query = "SELECT DAY(dueDate) AS day_dateDue,MONTH(dueDate) AS month_dateDue,YEAR(dueDate) AS year_dateDue,temp_dueDate,DAY(temp_dueDate)AS temp_day,MONTH(temp_dueDate)AS temp_month,YEAR(temp_dueDate)AS temp_year, payment_status  FROM tbl_customersinfo where accountNo ='" + id + "' ";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_day = reader["temp_day"].ToString();
                    temp_month = reader["temp_month"].ToString();
                    temp_year = reader["temp_year"].ToString();
                }
                int temp_day_int = Convert.ToInt32(temp_day);
                int temp_month_int = Convert.ToInt32(temp_month);
                int temp_year_int = Convert.ToInt32(temp_year);


                if (temp_month.Equals("1"))
                {
                    temp_month_int = 12;

                    temp_year_int = temp_year_int - 1;
                }
                else
                {
                    temp_month_int = temp_month_int - 1;
                }

                if (temp_month_int == 1) { t_month = "January"; }
                else if (temp_month_int == 2) { t_month = "February"; }
                else if (temp_month_int == 3) { t_month = "March"; }
                else if (temp_month_int == 4) { t_month = "April"; }
                else if (temp_month_int == 5) { t_month = "May"; }
                else if (temp_month_int == 6) { t_month = "June"; }
                else if (temp_month_int == 7) { t_month = "July"; }
                else if (temp_month_int == 8) { t_month = "August"; }
                else if (temp_month_int == 9) { t_month = "September"; }
                else if (temp_month_int == 10) { t_month = "October"; }
                else if (temp_month_int == 11) { t_month = "November"; }
                else { t_month = "December"; }

                lbl_dueDate.Text = t_month + " " + temp_day_int + ", " + temp_year_int;
                reader.Close();
                dbcon.CloseConnection();
            }
        }
    }
}
