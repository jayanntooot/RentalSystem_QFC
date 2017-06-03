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
    public partial class addCustomer : Form
    {
        public addCustomer()
        {
            InitializeComponent();
            
        }
        int typesOfrent, convert_month,convert_year ;
        string date_rented, month, day, year,e_dueDate,temp_id;
        public void clear()
        {
            txt_companyName.Text = null;
            txt_acctNo.Text = null;
            txt_address.Text = null;
            txt_productName.Text = null;
            txt_productID.Text = null;
            txt_productPrice.Text = null;
            txt_branch.Text = null;
            cbo_typeRental.SelectedIndex = -1;
            txt_productQty.Text = null;
            //cbo_month.SelectedIndex = -1;
            //cbo_day.SelectedIndex = -1;
            //cbo_year.SelectedIndex = -1;
            txt_dueDate.Text = null;
            txt_acctNo.Focus();
        }
        public void setHeightComboBox()
        {
            cbo_day.DropDownHeight = 106;
            cbo_month.DropDownHeight = 106;
            cbo_year.DropDownHeight = 106;

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
        int temp_dueMonth, temp_dueDay, temp_dueYear;
        string temp_dueDate;
        public void addCustomersInfo()
        {
            temp_id = txt_acctNo.Text;
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();     
                  
            if (cbo_typeRental.SelectedItem.Equals("Monthly Rental")){typesOfrent = 1;}
            else if (cbo_typeRental.SelectedItem.Equals("Per Page Rental")){typesOfrent = 2;}
            else if (cbo_typeRental.SelectedItem.Equals("Per Cartridge Rental")){typesOfrent = 3;}
            if (cbo_month.SelectedItem.Equals("Jan")){month = "1";}
            else if (cbo_month.SelectedItem.Equals("Feb")){month = "2";}
            else if (cbo_month.SelectedItem.Equals("Mar")){month = "3";}
            else if (cbo_month.SelectedItem.Equals("Apr")){month = "4";}
            else if (cbo_month.SelectedItem.Equals("May")){month = "5";}
            else if (cbo_month.SelectedItem.Equals("Jun")){month = "6";}
            else if (cbo_month.SelectedItem.Equals("Jul")){month = "7";}
            else if (cbo_month.SelectedItem.Equals("Aug")){month = "8";}
            else if (cbo_month.SelectedItem.Equals("Sep")){month = "9";}
            else if (cbo_month.SelectedItem.Equals("Oct")){month = "10";}
            else if (cbo_month.SelectedItem.Equals("Nov")){month = "11";}
            else if(cbo_month.SelectedItem.Equals("Dec")){month = "12";}

            day = cbo_day.SelectedItem.ToString();
            year = cbo_year.SelectedItem.ToString();
            date_rented = year + "-" + month + "-" + day;

            if (month.Equals("12"))
            {
                convert_month = 1;
                convert_year = Convert.ToInt32(year);
                convert_year = convert_year + 1;
            }
            else
            {
                convert_month = Convert.ToInt32(month);
                convert_month = convert_month + 1;
                convert_year = Convert.ToInt32(year);
            }
            e_dueDate = convert_year + "-" + convert_month + "-" + day;
            temp_dueDay = Convert.ToInt32(day);
            if (convert_month == 12)
            {
                temp_dueMonth = 1;
                temp_dueYear = convert_year + 1;

            }
            else
            {
                temp_dueMonth = convert_month + 1;
                temp_dueYear = convert_year;
            }
            temp_dueDate = temp_dueYear + "-" + temp_dueMonth + "-"+ temp_dueDay;
           // MessageBox.Show(temp_dueDate);

            string query = "INSERT INTO tbl_customersinfo (AccountNo,CompanyName,Branch,Address,typesRental,ProductID,start_dateRented,dueDate,temp_dueDate,payment_status) "
                + "VALUES('" + txt_acctNo.Text + "','" + txt_companyName.Text + "', '" + txt_branch.Text + "', '" + txt_address.Text + "', '" + typesOfrent + "', '" + txt_productID.Text + "', '" + date_rented+ "', '" + e_dueDate + "', '" + temp_dueDate + "','2')";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                productRented();
                MessageBox.Show(txt_companyName.Text+" has been successfully created.");
                clear();
                dbcon.CloseConnection();
            }
        }
        String m,mm,d,y,set_dueDate;
        int lbl_qty_inc=1, lbl_name_inc=1,lbl_price_inc=1;
        public void clear_additem()
        {
            txt_productID.Text = null;
            txt_productID.Focus();
            txt_productName.Text = null;
            txt_productPrice.Text = null;
            txt_productQty.Text = null;
        }
        int inc = 1, height = 5,tag =1;
        Button btnDel;
        Label displayQty;
        Label displayProductName;
        Label displayPrice;
        //private void AddItem(string product_name, string price, string qty)
        //{
        //    //get a reference to the previous existent 
        // //   RowStyle temp = tbl_pnl_overview.RowStyles[tbl_pnl_overview.RowCount - 1];
        //    //increase panel rows count by one
        //    tbl_pnl_overview.RowCount++;
        //    //add a new RowStyle as a copy of the previous one
        ////    tbl_pnl_overview.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
        //    //add your three controls
        //    tbl_pnl_overview.Controls.Add(new Label() { Text = product_name }, 0, tbl_pnl_overview.RowCount - 1);
        //    tbl_pnl_overview.Controls.Add(new Label() { Text = price }, 1, tbl_pnl_overview.RowCount - 1);
        //    tbl_pnl_overview.Controls.Add(new Label() { Text = qty }, 2, tbl_pnl_overview.RowCount - 1);
        //}
        public void add_item()
        {
            RetriveAddItem Obj = new RetriveAddItem();
            Obj.ProductID = txt_productID.Text;
            Obj.product_name = txt_productName.Text;
            Obj.product_qty = txt_productQty.Text;
            Obj.product_price = txt_productPrice.Text;
        }
        public void display_item()
        {
            RetriveAddItem Obj = new RetriveAddItem();
            Obj.ProductID = txt_productID.Text;
            Obj.product_name = txt_productName.Text;
            Obj.product_qty = txt_productQty.Text;
            Obj.product_price = txt_productPrice.Text;

            displayProductName = new Label();
            this.Controls.Add(displayProductName);
            displayProductName.Font = new Font("Segoe", 12, FontStyle.Regular);
            displayProductName.AutoSize = true;
            displayProductName.Location = new Point(3, inc * height);
            displayProductName.Name = Obj.product_name.ToString();
          //  displayProductName.Name = ""+tag;
            displayProductName.Text = txt_productName.Text;
            pnl_overview.Controls.Add(displayProductName);

             displayPrice = new Label();
            this.Controls.Add(displayPrice);
            displayPrice.Font = new Font("Segoe", 12, FontStyle.Regular);
            displayPrice.AutoSize = true;
            displayPrice.Location = new Point(180, inc * height);
            displayPrice.Name = Obj.product_price.ToString();
            //displayPrice.Name = "" + tag;
            displayPrice.Text = "P "+txt_productPrice.Text;
            pnl_overview.Controls.Add(displayPrice);


             displayQty = new Label();
            this.Controls.Add(displayQty);
            displayQty.Font = new Font("Segoe", 12, FontStyle.Regular);
            displayQty.AutoSize = true;
            displayQty.Location = new Point(289, inc * height);
            displayQty.Name = Obj.product_qty.ToString();
            //displayQty.Name = "" + tag;
            displayQty.Text = txt_productQty.Text;
            pnl_overview.Controls.Add(displayQty);

            btnDel = new Button();
            this.Controls.Add(btnDel);
            btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnDel.AutoSize = true;
            btnDel.Name = Obj.ProductID.ToString();
            //btnDel.Name = txt_productID.Text + tag;
            btnDel.ForeColor = Color.Red;
            btnDel.Text = "Remove";
            btnDel.Location = new Point(355, inc * height);
            btnDel.Click += new EventHandler(this.BtnDel_Click);
            pnl_overview.Controls.Add(btnDel);
            ////inc += 6;
            tag++;
            clear_additem();
        }
        int i=1;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            RetriveAddItem Obj = (RetriveAddItem)e.Argument;
            Obj.ProductID = txt_productID.Text;
            Obj.product_name = txt_productName.Text;
            Obj.product_qty = txt_productQty.Text;
            Obj.product_price = txt_productPrice.Text;
            backgroundWorker1.ReportProgress(i, Obj);
            Thread.Sleep(300);
            i++;
            inc += 6;

            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                RetriveAddItem Obj = (RetriveAddItem)e.UserState;

                displayProductName = new Label();
                this.Controls.Add(displayProductName);
                displayProductName.Font = new Font("Segoe", 10, FontStyle.Regular);
                displayProductName.AutoSize = true;
                displayProductName.Location = new Point(3, inc * height);
                displayProductName.Name = Obj.product_name.ToString();
                //  displayProductName.Name = ""+tag;
                displayProductName.Text = txt_productName.Text;
                pnl_overview.Controls.Add(displayProductName);

                displayPrice = new Label();
                this.Controls.Add(displayPrice);
                displayPrice.Font = new Font("Segoe", 10, FontStyle.Regular);
                displayPrice.AutoSize = true;
                displayPrice.Location = new Point(180, inc * height);
                displayPrice.Name = Obj.product_price.ToString();
                //displayPrice.Name = "" + tag;
                displayPrice.Text = "P " + txt_productPrice.Text;
                pnl_overview.Controls.Add(displayPrice);


                displayQty = new Label();
                this.Controls.Add(displayQty);
                displayQty.Font = new Font("Segoe", 10, FontStyle.Regular);
                displayQty.AutoSize = true;
                displayQty.Location = new Point(289, inc * height);
                displayQty.Name = Obj.product_qty.ToString();
                //displayQty.Name = "" + tag;
                displayQty.Text = txt_productQty.Text;
                pnl_overview.Controls.Add(displayQty);

                btnDel = new Button();
                this.Controls.Add(btnDel);
                btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnDel.AutoSize = true;
                btnDel.Name = Obj.ProductID.ToString();
                //btnDel.Name = txt_productID.Text + tag;
                btnDel.ForeColor = Color.Red;
                btnDel.Text = "Remove";
                btnDel.Tag = tag;
                btnDel.Location = new Point(355, inc * height);
                btnDel.Click += new EventHandler(this.BtnDel_Click);
                pnl_overview.Controls.Add(btnDel);
                ////inc += 6;
                tag++;
              //  clear_additem();
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (!backgroundWorker1.IsBusy)
            //{
            //    backgroundWorker1.CancelAsync();
            //}
        }

        public class RetriveAddItem
        {
            public string product_name, product_price, ProductID,product_qty;
        }
        string id;
        private void BtnDel_Click(object sender, EventArgs e)
        {

            Button b = sender as Button;
            id = b.Name;
            MessageBox.Show(id);

            //if (pnl_overview.Controls.Contains(btnDel))
            //{
            //    pnl_overview.Controls.Remove(btnDel);
            //    btnDel.Dispose();
            //}
            //foreach (Control item in pnl_overview.Controls.OfType<Control>())
            //{
            //    if (item.Name == id)
            //    {
            //        pnl_overview.Controls.Remove(item);
            //    }


            //}
            //btnDel.Name = id;
            //displayPrice.Name = id;
            //displayProductName.Name = id;
            //displayQty.Name = id;
            //if (id == btnDel.Name)
            //{

            //}
            //pnl_overview.Controls.Remove(btnDel);
            //pnl_overview.Controls.Remove(displayPrice);
            //pnl_overview.Controls.Remove(displayProductName);
            //pnl_overview.Controls.Remove(displayQty);


        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            //  ++i;          
            backgroundWorker1.WorkerReportsProgress = true;
            if (!backgroundWorker1.IsBusy)
            {
                RetriveAddItem TObj = new RetriveAddItem();
                backgroundWorker1.RunWorkerAsync(TObj);
            }
            //  add_item();
            //   display_item();
            //  AddItem(txt_productName.Text,txt_productPrice.Text,txt_productQty.Text);

        }

        int con_y;
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

            if (m.Equals("12")){ mm = "Jan";}
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
            }else
            {
                con_y = Convert.ToInt32(y);
            }

            set_dueDate = mm + " " + d + ", " + con_y;
            txt_dueDate.Text = set_dueDate;
        }

        public void productRented()
        {
            AesCrypt dbcon = new AesCrypt();
            dbcon.InitializationDB();
            dbcon.OpenConnection();
            dbcon.CloseConnection();
            string query = "INSERT INTO tbl_product (product_IDno,product_name,product_qty,product_price) "
                + "VALUES('" + txt_productID.Text + "','" + txt_productName.Text + "','" + txt_productQty.Text + "', '" + txt_productPrice.Text + "')";
            if (dbcon.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
                cmd.ExecuteNonQuery();
                dbcon.CloseConnection();
            }
        }
        string display_curdate;
        private void addCustomer_Load(object sender, EventArgs e)
        {
            display_curdate = DateTime.Now.ToString("MMM dd, yyyy");
            lbl_date.Text = display_curdate;
            txt_acctNo.Focus();
            setHeightComboBox();
           // generate31Days();
           // generateYear();

        }
        Payment make_bill;
        private void btn_addCustomer_Click(object sender, EventArgs e)
        {
            if (txt_acctNo.Text == "" || txt_acctNo.Text ==" ") { MessageBox.Show("Please fill up all the data fields.");txt_acctNo.Focus(); }
            else if(txt_companyName.Text == "" || txt_companyName.Text == " ") { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (txt_branch.Text == "" || txt_branch.Text == " ") { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (txt_address.Text == "" || txt_address.Text == " ") { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (cbo_typeRental.SelectedItem.Equals("")|| cbo_typeRental.SelectedItem.Equals(" ")) { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (txt_productID.Text == "" || txt_productID.Text == " ") { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (txt_productName.Text == "" || txt_productName.Text == " ") { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (txt_productQty.Text == "" || txt_productQty.Text == " ") { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (txt_productPrice.Text == "" || txt_productPrice.Text == " ") { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (cbo_month.SelectedIndex == -1 || cbo_month.SelectedIndex == -1) { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (cbo_day.SelectedIndex == -1 || cbo_day.SelectedIndex == -1) { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else if (cbo_year.SelectedIndex == -1 || cbo_year.SelectedIndex == -1) { MessageBox.Show("Please fill up all the data fields."); txt_acctNo.Focus(); }
            else
            {
                addCustomersInfo();
                //if (make_bill == null)
                //{
                //    make_bill = new Payment();
                //    make_bill.id_customer = temp_id;
                //    make_bill.loadData(temp_id);
                //    make_bill.Owner = this;
                //    make_bill.FormClosed += new FormClosedEventHandler(Make_bill_FormClosed);
                //    make_bill.Show();
                //    btn_addCustomer.Enabled = false;
                //}
                //else
                //{
                //    make_bill.Activate();
                //}

            }


        }

        //private void Make_bill_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    make_bill = null;
        //    btn_addCustomer.Enabled = true;
        //}
        public void remove_item()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this item ?", "Alert Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
               // MessageBox.Show(id);
                //do something
              
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {   
            clear();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //bool chk = false;
        private void txt_productID_TextChanged(object sender, EventArgs e)
        {
            //AesCrypt dbcon = new AesCrypt();
            //dbcon.InitializationDB();
            //dbcon.OpenConnection();
            //dbcon.CloseConnection();
            //string query = "SELECT * from tbl_customersinfo WHERE ProductID = '"+txt_productID.Text+"' ";

            //if (dbcon.OpenConnection() == true)
            //{
            //    MySqlCommand cmd = new MySqlCommand(query, dbcon.connection);
            //    MySqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        chk = true;
            //    }
            //    else
            //    {
            //        chk = false;
            //    }

            //    if (chk == true)
            //    {
            //        MessageBox.Show("Product ID already used.");
            //        //lbl_alert.Visible = true;
            //        //lbl_alert.ForeColor = Color.Red;
            //        //lbl_alert.Text = "Product ID already used.";
            //        //txt_productID.Focus();
            //    }else
            //    {
            //       // lbl_alert.Visible = false;
            //    }
            //}
        }
    }
}
