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
    public partial class transPayment : Form
    {
        public transPayment()
        {
            InitializeComponent();
        }
        public string id_customer;
        String day_rented, month_rented, year_rented, due_d, due_m, due_yr;
        double current_bal, previous_bal, total_amountDue,cash_receive,cash_change;
        string statement_val, cur_date, diplay_curdate, get_prevBalance, get_currentBalance, invoice_no,cash,reference;

        private void txt_refNo_TextChanged(object sender, EventArgs e)
        {
            reference = txt_refNo.Text;
            if (reference =="" || reference == " ")
            {
                btn_payment.Enabled = false;
            }
            else
            {
                btn_payment.Enabled = true;
            }
        }

        private void txt_comments_TextChanged(object sender, EventArgs e)
        {
            if (txt_comments.Text == "" || txt_comments.Text == " ")
            {
                btn_payment.Enabled = false;
            }
            else
            {
                btn_payment.Enabled = true;
            }
        }

        private void txt_payment_TextChanged(object sender, EventArgs e)
        {
             cash = txt_payment.Text;
           
            int i;
           
            if ((cash == "" || cash == " "))
            {
                lbl_change.Text = "0.00";
                btn_payment.Enabled = false;

            }
            else
            {
                if (check_payment == true)
                {
                    btn_payment.Enabled = true;
                }
                else
                {
                    if (!int.TryParse(cash, out i))
                    {
                        lbl_change.Text = "0.00";
                        btn_payment.Enabled = false;
                        return;
                    }
                    else
                    {
                        cash_receive = Convert.ToDouble(cash);
                        cash_change = cash_receive - total_amountDue;
                        if (cash_receive >= total_amountDue)
                        {
                            lbl_change.Text = cash_change.ToString("0.00");
                            btn_payment.Enabled = true;
                        }
                        else
                        {
                            lbl_change.Text = "0.00";
                        }
                    }
                }
                
              
            }
          
        }
      
      

        private void btn_payment_Click(object sender, EventArgs e)
        {
            if (txt_ORnumber.Text == "" || txt_ORnumber.Text == " ")
            {
                MessageBox.Show("Please input the OR number.");
                txt_ORnumber.Focus();
            }
            else
            {
               
                make_payment();
                this.Close();
            }
        }
        string month, year;
        public void get_curBal(String acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            year = DateTime.Now.ToString("yyyy");
            month = DateTime.Now.ToString("MM");     
            string query = "SELECT acctID_bal, amount_bal FROM qry_balance WHERE acctID_bal= '" + acctID + "' AND status_bal = 2 AND dba_month = '" + month + "' AND dba_year = '" + year + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    get_currentBalance = dataReader["amount_bal"].ToString(); ;

                }
                if (get_currentBalance == "" || get_currentBalance == " ")
                {
                    lbl_currentPayment.Text = "0.00";
                }
                else
                {
                    current_bal = Convert.ToDouble(get_currentBalance);
                    lbl_currentPayment.Text = "" + current_bal.ToString("0.00");
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

                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
      
        int typesOfpayment;
        string get_month, get_year, get_day,updated_dueDate;
        int update_month,update_year;
        int temp_dueMonth, temp_dueDay, temp_dueYear;
        string updated_temp_dueDate, temp_duedate_day, temp_duedate_month, temp_duedate_year;
        public void update_deuDate(string id)
        {

            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            string query = " SELECT YEAR(temp_dueDate) AS temp_duedate_year,MONTH(temp_dueDate) as temp_duedate_month, DAY(temp_dueDate) as temp_duedate_day,YEAR(dueDate) AS duedate_year,MONTH(dueDate) as duedate_month, DAY(dueDate) as duedate_day FROM tbl_customersinfo WHERE AccountNo='" + id + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    get_month = dataReader["duedate_month"].ToString();
                    get_day = dataReader["duedate_day"].ToString();
                    get_year = dataReader["duedate_year"].ToString();
                    temp_duedate_month = dataReader["temp_duedate_month"].ToString();
                    temp_duedate_day = dataReader["temp_duedate_day"].ToString();
                    temp_duedate_year = dataReader["temp_duedate_year"].ToString();
                }
               
                //if (get_month == "12") { update_month = 1; update_year = update_year + 1;}
                //else { update_month = update_month + 1; update_year = Convert.ToInt32(get_year);}

                //Tiwasa ni !
                updated_dueDate = temp_duedate_year + "-" + temp_duedate_month + "-" + temp_duedate_day;
                //updated_dueDate = update_year + "-" + update_month + "-" + get_day;
                //update_month = Convert.ToInt32(get_month);
                //update_year = Convert.ToInt32(get_year);
                //temp_dueDay = Convert.ToInt32(get_day);
                update_month = Convert.ToInt32(temp_duedate_month);
                update_year = Convert.ToInt32(temp_duedate_year);
                temp_dueDay = Convert.ToInt32(temp_duedate_day);
                if (update_month == 12)
                {
                    temp_dueMonth = 1;
                    temp_dueYear = update_year + 1;

                }
                else
                {
                    temp_dueMonth = update_month + 1;
                    temp_dueYear = update_year;
                }
                updated_temp_dueDate = temp_dueYear + "-" + temp_dueMonth + "-" + temp_dueDay;
               // MessageBox.Show(updated_temp_dueDate);
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        public void  update_PaymentStatus(string id)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            update_deuDate(id);
            string query = "UPDATE tbl_customersinfo SET dueDate='"+ updated_dueDate + "', temp_dueDate='" + updated_temp_dueDate + "', payment_status='1' WHERE AccountNo='" + id + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                update_Balance_PaymentStatus(lbl_accno.Text);
                dbcon.CloseConnection();
            }
        }
        string dueDate;
        public void update_Balance_PaymentStatus(string id)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            string query = "UPDATE tbl_balance SET status_bal = 1 WHERE acctID_bal = '"+id+"' AND due_date = '"+dueDate+"'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }
        }
        string amount_paid;
        public void make_payment()
        {
            cur_date = DateTime.Now.ToString("yyyy-MM-dd");
            get_statementNo(lbl_accno.Text);
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            
            if (cbo_typesPayment.SelectedItem.Equals("Cash")) { typesOfpayment = 1; amount_paid = lbl_totalAmount.Text; }
            else if (cbo_typesPayment.SelectedItem.Equals("Check")) { typesOfpayment = 2; amount_paid = lbl_totalAmount.Text; }
            else if (cbo_typesPayment.SelectedItem.Equals("Bank")) { typesOfpayment = 3; amount_paid = lbl_totalAmount.Text; }
            string query = "INSERT INTO tbl_payment (accountNo_payment,StatementNo,OR_number,PaymentType,paymentReceived,ref_number,DateOfPayment_payment,comments) "
                + "VALUES('" + lbl_accno.Text + "','" + statement_val + "','" + txt_ORnumber.Text + "','" + typesOfpayment + "','" + amount_paid + "','" + txt_refNo.Text + "', '" + cur_date + "', '" + txt_comments.Text + "')";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                update_PaymentStatus(lbl_accno.Text);
                MessageBox.Show("Make a payment successful.");
                this.Close();
                dbcon.CloseConnection();
            }
        }
        string dd_month, dd_day, dd_year;
        public void loadData(String acctID)
        {
            
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            
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
                    dd_day = dataReader["duedate_day"].ToString();
                    dd_month = dataReader["duedate_month"].ToString();
                    dd_year = dataReader["duedate_year"].ToString();

                    due_d = dataReader["duedate_day"].ToString();
                    due_m = dataReader["duedate_month"].ToString();
                    due_yr = dataReader["duedate_year"].ToString();

                

                    //date rented
                    if (month_rented.Equals("1")) { month_rented = "Jan"; }
                    else if (month_rented.Equals("2")) { month_rented = "Feb"; }
                    else if (month_rented.Equals("3")) { month_rented = "Mar"; }
                    else if (month_rented.Equals("4")) { month_rented = "Apr"; }
                    else if (month_rented.Equals("5")) { month_rented = "May"; }
                    else if (month_rented.Equals("6")) { month_rented = "Jun"; }
                    else if (month_rented.Equals("7")) { month_rented = "Jul"; }
                    else if (month_rented.Equals("8")) { month_rented = "Aug"; }
                    else if (month_rented.Equals("9")) { month_rented = "Sep"; }
                    else if (month_rented.Equals("10")) { month_rented = "Oct"; }
                    else if (month_rented.Equals("11")) { month_rented = "Nov"; }
                    else { month_rented = "Dec"; }
                    //due date
                    if (due_m.Equals("1")) { due_m = "Jan"; }
                    else if (due_m.Equals("2")) { due_m = "Feb"; }
                    else if (due_m.Equals("3")) { due_m = "Mar"; }
                    else if (due_m.Equals("4")) { due_m = "Apr"; }
                    else if (due_m.Equals("5")) { due_m = "May"; }
                    else if (due_m.Equals("6")) { due_m = "Jun"; }
                    else if (due_m.Equals("7")) { due_m = "Jul"; }
                    else if (due_m.Equals("8")) { due_m = "Aug"; }
                    else if (due_m.Equals("9")) { due_m = "Sep"; }
                    else if (due_m.Equals("10")) { due_m = "Oct"; }
                    else if (due_m.Equals("11")) { due_m = "Nov"; }
                    else { due_m = "Dec"; }
                    // MessageBox.Show(month_rented);
                    //cbo_month.SelectedItem = month_rented;
                    //cbo_day.SelectedItem = day_rented;
                    //cbo_year.SelectedItem = year_rented;
                    //txt_dueDate.Text = due_m + " " + due_d + ", " + due_yr;
                }

                // due date format
                int month_dateDue_int = Convert.ToInt32(dd_month);
                int day_dateDue_int = Convert.ToInt32(dd_day);

                if (month_dateDue_int <= 9) { dd_month = "0" + dd_month; }
                if (day_dateDue_int <= 9) { dd_day = "0" + dd_day; }
                dueDate = dd_year + "-" + dd_month + "-" + dd_day;
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }

        //Debugging not yet solve.
        public void getInvoice_no(String acctID)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "SELECT DISTINCT accountNo_bill,invoiceNo FROM tbl_bill WHERE accountNo_bill ='" + acctID + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    invoice_no = dataReader["invoiceNo"].ToString();
                    if (!invoice_no.Equals("") || !invoice_no.Equals(" "))
                    {
                        lbl_invoiceNo.ForeColor = Color.Black;
                        lbl_invoiceNo.Text = "" + invoice_no;
                    }
                }
                dataReader.Close();
                dbcon.CloseConnection();
               
            }
            get_curBal(acctID);
            get_prevBal(acctID);
            total_amountDue = previous_bal + current_bal;
            lbl_totalAmount.Text = "" + total_amountDue.ToString("0.00");
            loadData(acctID);
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel ?", "Alert Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            { 
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void transPayment_Load(object sender, EventArgs e)
        {         
                txt_ORnumber.Focus();
               // check_statementNo(id_customer);
                getInvoice_no(id_customer);
                diplay_curdate = DateTime.Now.ToString("MMM dd, yyyy");
                lbl_date.Text = diplay_curdate;
                //get_curBal(id_customer);
                //get_prevBal(id_customer);
                //total_amountDue = previous_bal + current_bal;
                //lbl_totalAmount.Text = "" + total_amountDue.ToString("0.00");
                //loadData(id_customer);
            
           
        }
        bool check_payment = false;
        private void cbo_typesPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_typesPayment.SelectedItem.Equals("Check"))
            {
                lbl_change.Visible = false;
                lbl_lblchange.Visible = false;
                lbl_P.Visible = false;
                check_payment = true;
                lbl_reference.Visible = true;
                txt_payment.Visible = true;
                lbl_reference.Text = "Reference No.";
                txt_payment.Text = null;
                txt_payment.Visible = false;
                txt_refNo.Visible = true;
                txt_refNo.Location = new Point(208, 512);
                txt_refNo.Focus();
            }else if  (cbo_typesPayment.SelectedItem.Equals("Bank"))
            {
                check_payment = false;
                lbl_change.Visible = false;
                lbl_lblchange.Visible = false;
                lbl_P.Visible = false;
                txt_payment.Text = null;
                txt_refNo.Text = null;
                lbl_reference.Visible = false;
                txt_payment.Visible = false;
                txt_refNo.Visible = false;
                btn_payment.Enabled = false;
                txt_comments.Focus();
            }
            else
            {
                lbl_change.Visible = true;
                lbl_lblchange.Visible = true;
                lbl_P.Visible = true;
                check_payment = false;
                lbl_reference.Visible = true;
                txt_payment.Visible = true;
                lbl_reference.Text = "Cash Recieved";
                txt_payment.Visible = true;
                txt_refNo.Visible = false;
                txt_payment.Focus();
            }
        }
    }
}
