using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DDL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "server=(local);database=;integrated security=true";
            con1.Open();
            SqlCommand c1 = new SqlCommand();
            c1.Connection = con1;
            c1.CommandText = "create database " + textBox1.Text;
            try {
                c1.ExecuteNonQuery();
                MessageBox.Show("انجام شد.");
                }
            catch
            {
                MessageBox.Show("اشکال دارد");
            }


            con1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "server=(local);database="+textBox1.Text+";integrated security=true";
            //    con1.Open();
            string query = "create table " + textBox3.Text + "(";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                query = query + listBox1.Items[i].ToString() + " " + listBox2.Items[i].ToString() + " " + listBox3.Items[i].ToString();
              //  if (checkBox1.Checked == true)
               //     query = query + "primarykey=true";
                if (i != listBox1.Items.Count - 1)
                    query = query + ",";
                else
                    query = query + ")";
            }


            SqlCommand cmd = new SqlCommand(query, con1);
            try
            {
                con1.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                con1.Close();
             //   Console.ReadKey();
            }
        








/*

        Button b1 = new Button();
            b1.Text = "فیلد جدید";
            b1.Location = new Point(textBox2.Left + 30, textBox2.Top + 50);
            b1.Size = new Size(80, 30);
            groupBox2.Controls.Add(b1);
            //this.Controls.Add(b1);
            b1.Click += B1_Click;
            */
        }

        private void B1_Click(object sender, EventArgs e)
        {
            Button bb = (Button)sender;
            TextBox t1 = new TextBox();
            t1.Location = new Point(bb.Left, bb.Top + 30);
            groupBox2.Controls.Add(t1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
            listBox2.Items.Add(comboBox1.Text);
            listBox3.Items.Add(comboBox2.Text);
        }

        
    }
}
