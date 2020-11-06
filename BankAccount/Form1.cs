using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace BankAccount
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\2nd semester\OOPs\LABS\Csharp1.accdb;
Persist Security Info=False;"; 
        }
        int counter = 0;
        string c = "Yes";
        string a = "current";
        string b = "saving";

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from Bank", con);
            DataSet d = new DataSet("Bank");

            con.Open();
            OleDbCommand cm = new OleDbCommand("select BranchCode from Bank", con);
            OleDbDataReader read = cm.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["BranchCode"]).ToString();
            }
            read.Close();
            adap.Fill(d, "Bank");
            textBox1.Text = d.Tables["Bank"].Rows[0]["AccountNo"].ToString();
            textBox2.Text = d.Tables["Bank"].Rows[0]["Name"].ToString();
            comboBox1.Text = d.Tables["Bank"].Rows[0]["BranchCode"].ToString();
            textBox3.Text = d.Tables["Bank"].Rows[0]["Balance"].ToString();
            string s = d.Tables["Bank"].Rows[0]["AccountType"].ToString();
            string t = d.Tables["Bank"].Rows[0]["ATMReq"].ToString();
            if (s == "current")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            if (t == "Yes")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from Bank", con);
            DataSet d = new DataSet("Bank");
            adap.Fill(d, "Bank");

            if (counter < d.Tables["Bank"].Rows.Count-1)
            {
                counter = counter + 1;
                textBox1.Text = d.Tables["Bank"].Rows[counter]["AccountNo"].ToString();
                textBox2.Text = d.Tables["Bank"].Rows[counter]["Name"].ToString();
                comboBox1.Text = d.Tables["Bank"].Rows[counter]["BranchCode"].ToString();
                textBox3.Text = d.Tables["Bank"].Rows[counter]["Balance"].ToString();
                string s = d.Tables["Bank"].Rows[counter]["AccountType"].ToString();
                string t = d.Tables["Bank"].Rows[counter]["ATMReq"].ToString();
                if (s == "current")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                if (t == "Yes")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else
                MessageBox.Show("you are already in Last record");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from Bank", con);
            DataSet d = new DataSet("Bank");
            adap.Fill(d, "Bank");
            if (counter > 0)
            {
                counter = counter - 1;
                textBox1.Text = d.Tables["Bank"].Rows[counter]["AccountNo"].ToString();
                textBox2.Text = d.Tables["Bank"].Rows[counter]["Name"].ToString();
                comboBox1.Text = d.Tables["Bank"].Rows[counter]["BranchCode"].ToString();
                textBox3.Text = d.Tables["Bank"].Rows[counter]["Balance"].ToString();
                string s = d.Tables["Bank"].Rows[counter]["AccountType"].ToString();
                string t = d.Tables["Bank"].Rows[counter]["ATMReq"].ToString();
                if (s == "current")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                if (t == "Yes")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else
                MessageBox.Show("you are already in first record");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                OleDbCommand com1 = new OleDbCommand(@"Insert into Bank(AccountNo,Name,BranchCode,Balance,AccountType) 
values(' " + textBox1.Text + " ',' " + textBox2.Text + " ',' " + comboBox1.Text + " ',' " + textBox3.Text + " ','" + a + "')", con);
                com1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("One record has been Added");
            }
            else if (radioButton2.Checked)
            {
                con.Open();
                OleDbCommand com1 = new OleDbCommand(@"Insert into Bank(AccountNo,Name,BranchCode,Balance,AccountType,ATMReq) 
values(' " + textBox1.Text + " ',' " + textBox2.Text + " ',' " + comboBox1.Text + " ',' " + textBox3.Text + " ','" + b + "','" + c + "')", con);
                com1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("One record has been Added");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                OleDbCommand com3 = new OleDbCommand("Update Bank set Name='" + textBox2.Text + "',AccountType='" + a + "',ATMReq='" + c + "' where AccountNo=@AccountNo", con);
                com3.Parameters.Add("AccountNo", OleDbType.Integer).Value = textBox1.Text;
                com3.ExecuteNonQuery();
                MessageBox.Show("1 record has been Updated");
                con.Close();

            }
            else
            {
                con.Open();
                OleDbCommand com3 = new OleDbCommand("Update Bank set Name='" + textBox2.Text + "',AccountType='" + b + "',ATMReq='" + c + "' where AccountNo=@AccountNo", con);
                com3.Parameters.Add("AccountNo", OleDbType.Integer).Value = textBox1.Text;
                com3.ExecuteNonQuery();
                MessageBox.Show("1 record has been Updated");
                con.Close();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Text = a;
        }
        private void radiobutton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Text = b;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
