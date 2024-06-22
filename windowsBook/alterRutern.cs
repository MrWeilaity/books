using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDatabaseLibrary;

namespace windowsBook
{
    public partial class alterRutern : Form
    {
        public delegate void UpdateParentWindowData(); // 子窗口声明定义委托 refresh()
        public event UpdateParentWindowData refresh;//定义委托
        private List<string> list = new List<string>();
        public alterRutern(List<string> list)
        {
            this.list = list;
            InitializeComponent();
            showdata(list);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void showdata(List<string> list) 
        {
            textBox1.Text = list[0];
            textBox2.Text = list[1];
            textBox3.Text = list[2];
            textBox4.Text = list[3];
            textBox5.Text = list[4];
            textBox6.Text = list[5];
            textBox7.Text = list[6];
            textBox8.Text = list[7];
            textBox9.Text = list[8];
            textBox10.Text = list[9];
            textBox11.Text = list[11];
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedTime = dateTimePicker1.Value;

            // 输出时间
            Console.WriteLine(selectedTime.ToString());
            //更新语句
            if (int.Parse(textBox9.Text.ToString()) > int.Parse(list[8]) && int.Parse(textBox9.Text.ToString()) <= int.Parse(list[7])  ) 
            {
                Console.WriteLine("对");
                string query = "update borrowrecords set ReturnQuantity=@ReturnQuantity,ReturnDate=@ReturnDate where RecordID=@RecordID ";
                MySqlParameter ReturnQuantity = new MySqlParameter("@ReturnQuantity", int.Parse(textBox9.Text.ToString()));
                MySqlParameter RecordID = new MySqlParameter("@RecordID", int.Parse(list[0]));
                MySqlParameter ReturnDate = new MySqlParameter("@ReturnDate", selectedTime);
                int res = MySQLHelper.Instance.Update(query, ReturnQuantity,ReturnDate, RecordID);
                if (res == 0) 
                {
                    MessageBox.Show("还书失败，请重试","还书提示");
                    return;
                }
                MessageBox.Show("还书成功","还书提示");
                Console.WriteLine("res:" + res);
                this.refresh();
                this.Close();
                
            }
            else 
            {
                MessageBox.Show("还书数量不对，请重新输入","还书提示");
                return;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
