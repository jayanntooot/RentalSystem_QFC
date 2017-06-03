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
    public partial class editCustomer : Form
    {
        public editCustomer()
        {
            InitializeComponent();
        }
        public string id_customer;
        int convert_year,convert_month;
        string e_month, e_day, e_year, e_date,due_month,due_day,due_year,e_dueDate;
        public void edit_product(string id)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();

            string query = "UPDATE tbl_product SET product_name='" + txt_productName.Text + "',product_qty='" + txt_productQty.Text + "',product_price='" + txt_productPrice.Text + "' WHERE Product_IDno='" + id + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }
        }
        public void edit(String id)
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            e_month = cbo_month.SelectedItem.ToString();
            e_day = cbo_day.SelectedItem.ToString();
            e_year = cbo_year.SelectedItem.ToString();
           
            //month
            if (cbo_month.SelectedItem.Equals("Jan")) { due_month = "1"; }
            else if (cbo_month.SelectedItem.Equals("Feb")) { due_month = "2"; }
            else if (cbo_month.SelectedItem.Equals("Mar")) { due_month = "3"; }
            else if (cbo_month.SelectedItem.Equals("Apr")) { due_month = "4"; }
            else if (cbo_month.SelectedItem.Equals("May")) { due_month = "5"; }
            else if (cbo_month.SelectedItem.Equals("Jun")) { due_month = "6"; }
            else if (cbo_month.SelectedItem.Equals("Jul")) { due_month = "7"; }
            else if (cbo_month.SelectedItem.Equals("Aug")) { due_month = "8"; }
            else if (cbo_month.SelectedItem.Equals("Sep")) { due_month = "9"; }
            else if (cbo_month.SelectedItem.Equals("Oct")) { due_month = "10"; }
            else if (cbo_month.SelectedItem.Equals("Nov")) { due_month = "11"; }
            else { due_month = "12"; }
            //day

            e_date = e_year + "-" + due_month + "-" + e_day;
            due_day = e_day;
            due_year = e_year;
            if (due_month.Equals("12")) {
                convert_month = 1;
                convert_year = Convert.ToInt32(due_year);
                convert_year = convert_year + 1;
            }
            else {
                convert_month = Convert.ToInt32(due_month);
                convert_month = convert_month + 1;
                convert_year = Convert.ToInt32(due_year);
            }
            
            
            e_dueDate = convert_year + "-" + convert_month + "-" + due_day;


            string query = "UPDATE tbl_customersinfo SET CompanyName='" + txt_companyName.Text + "',Branch='" + txt_branch.Text + "',Address='" + txt_address.Text + "',start_dateRented='" + e_date + "',dueDate='" + e_dueDate + "' WHERE AccountNo='" + id + "'";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                edit_product(lbl_productID.Text);
                MessageBox.Show(txt_companyName.Text + " has been successfully updated.");
                this.Close();
                dbcon.CloseConnection();
            }
        }
        String day_rented, month_rented, year_rented,due_d,due_m,due_yr;
        String m, mm, d, y, set_dueDate;
        int con_y;

        private void cbo_day_SelectedIndexChanged(object sender, EventArgs e)
        {
            d = cbo_day.SelectedItem.ToString();
        }

        private void cbo_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            y = cbo_year.SelectedItem.ToString();

            if (m.Equals("12"))
            {
                con_y = Convert.ToInt32(y);
                con_y = con_y + 1;
            }
            else
            {
                con_y = Convert.ToInt32(y);
            }

            set_dueDate = mm + " " + d + ", " + con_y;
            txt_dueDate.Text = set_dueDate;
        }

        private void cbo_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_month.SelectedItem.Equals("Jan")) { m = "1"; mm = "Jan"; }
            else if (cbo_month.SelectedItem.Equals("Feb")) { m = "2"; mm = "Feb"; }
            else if (cbo_month.SelectedItem.Equals("Mar")) { m = "3"; mm = "Mar"; }
            else if (cbo_month.SelectedItem.Equals("Apr")) { m = "4"; mm = "Apr"; }
            else if (cbo_month.SelectedItem.Equals("May")) { m = "5"; mm = "May"; }
            else if (cbo_month.SelectedItem.Equals("Jun")) { m = "6"; mm = "Jun"; }
            else if (cbo_month.SelectedItem.Equals("Jul")) { m = "7"; mm = "Jul"; }
            else if (cbo_month.SelectedItem.Equals("Aug")) { m = "8"; mm = "Aug"; }
            else if (cbo_month.SelectedItem.Equals("Sep")) { m = "9"; mm = "Sep"; }
            else if (cbo_month.SelectedItem.Equals("Oct")) { m = "10"; mm = "Oct"; }
            else if (cbo_month.SelectedItem.Equals("Nov")) { m = "11"; mm = "Nov"; }
            else { m = "12"; mm = "Dec"; }

            if (m.Equals("12")) { mm = "Jan"; }
            else if (cbo_month.SelectedItem.Equals("Jan")) { mm = "Feb"; }
            else if (cbo_month.SelectedItem.Equals("Feb")) { mm = "Mar"; }
            else if (cbo_month.SelectedItem.Equals("Mar")) { mm = "Apr"; }
            else if (cbo_month.SelectedItem.Equals("Apr")) { mm = "May"; }
            else if (cbo_month.SelectedItem.Equals("May")) { mm = "Jun"; }
            else if (cbo_month.SelectedItem.Equals("Jun")) { mm = "Jul"; }
            else if (cbo_month.SelectedItem.Equals("Jul")) { mm = "Aug"; }
            else if (cbo_month.SelectedItem.Equals("Aug")) { mm = "Sep"; }
            else if (cbo_month.SelectedItem.Equals("Sep")) { mm = "Oct"; }
            else if (cbo_month.SelectedItem.Equals("Oct")) { mm = "Nov"; }
            else if (cbo_month.SelectedItem.Equals("Nov")) { mm = "Dec"; }
        }

        private void editCustomer_Paint(object sender, PaintEventArgs e)
        {
            //Graphics gs = e.Graphics;
            //Rectangle rec = new Rectangle(0, 0, 858, 557);
            //gs.FillRectangle(Brushes.Gray,rec);
            
        }

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
                    lbl_acctNo.Text = dataReader["AccountNo"].ToString();
                    txt_companyName.Text = dataReader["CompanyName"].ToString();
                    txt_branch.Text = dataReader["Branch"].ToString();
                    txt_address.Text = dataReader["Address"].ToString();
                    lbl_typeRental.Text = dataReader["type_rentalDescription"].ToString(); 
                    lbl_productID.Text = dataReader["ProductID"].ToString();
                    txt_productName.Text = dataReader["product_name"].ToString();
                    txt_productPrice.Text = dataReader["product_price"].ToString();
                    txt_productQty.Text = dataReader["product_qty"].ToString();
                    day_rented = dataReader["r_day"].ToString();
                    month_rented = dataReader["r_month"].ToString();
                    year_rented = dataReader["r_year"].ToString();
                    due_d = dataReader["duedate_day"].ToString();
                    due_m = dataReader["duedate_month"].ToString();
                    due_yr = dataReader["duedate_year"].ToString();

                    //date rented
                    if (month_rented.Equals("1")){month_rented = "Jan";}
                    else if (month_rented.Equals("2")){month_rented = "Feb";}
                    else if (month_rented.Equals("3")){month_rented = "Mar";}
                    else if (month_rented.Equals("4")){month_rented = "Apr";}
                    else if (month_rented.Equals("5")){month_rented = "May";}
                    else if (month_rented.Equals("6")){month_rented = "Jun";}
                    else if (month_rented.Equals("7")){month_rented = "Jul";}
                    else if (month_rented.Equals("8")){month_rented = "Aug";}
                    else if (month_rented.Equals("9")){month_rented = "Sep";}
                    else if (month_rented.Equals("10")){month_rented = "Oct";}
                    else if (month_rented.Equals("11")){month_rented = "Nov";}
                    else{month_rented = "Dec";}
                    //due date
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
                   // MessageBox.Show(month_rented);
                    cbo_month.SelectedItem = month_rented;
                    cbo_day.SelectedItem = day_rented;
                    cbo_year.SelectedItem = year_rented;
                    txt_dueDate.Text = due_m + " " + due_d + ", " + due_yr;
                }
                dataReader.Close();
                dbcon.CloseConnection();
            }
        }
        public void setHeightComboBox()
        {
            cbo_day.DropDownHeight = 106;
            cbo_month.DropDownHeight = 106;
            cbo_year.DropDownHeight = 106;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_addCustomer_Click_1(object sender, EventArgs e)
        {
            edit(lbl_acctNo.Text);

        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
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

        private void pnl_body_Paint(object sender, PaintEventArgs e)
        {

        }

        public void generateYear()
        {

            for (int i = 2000; i <= 2050; i++)
            {
                cbo_year.Items.Add(i);
            }
        }
        public void generate31Days()
        {
            for (int i = 1; i <= 31; i++)
            {
                cbo_day.Items.Add(i);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            
        }
        string display_curdate;
        private void editCustomer_Load(object sender, EventArgs e)
        {
            display_curdate = DateTime.Now.ToString("MMM dd, yyyy");
            lbl_date.Text = display_curdate;
            loadData(id_customer);
            setHeightComboBox();
          //  generate31Days();
           // generateYear();
           

        }

        private void btn_addCustomer_Click(object sender, EventArgs e)
        {
        }
    }
}
