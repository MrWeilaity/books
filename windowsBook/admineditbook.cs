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
using MySql.Data.MySqlClient;

namespace windowsBook
{
    public partial class admineditbook : Form
    {   private List<string> books = new List<string>();
        public delegate void UpdateParentWindowData(); // 子窗口声明定义委托 refresh()
        public event UpdateParentWindowData refresh;//定义委托

        public admineditbook(List<string> list)
        {
            InitializeComponent();
            books = list;
        }

        private void admineditbook_Load(object sender, EventArgs e)
        {
            textBox1.Text = books[2];
            textBox2.Text = books[3];
            textBox3.Text = books[4];
            textBox4.Text = books[5];
            textBox5.Text = books[6];
            textBox6.Text = books[7];
            textBox7.Text = books[8];
            textBox8.Text = books[9];
            textBox9.Text = books[10];
            textBox8.SelectionStart = textBox8.Text.Length;
            textBox8.SelectionLength = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox8.Text.Trim()) <= 0)
            {
                MessageBox.Show("输入的库存量不合法","修改提示");
                return;
            }
            string query = "update books set Stock=@Stock where BookID=@BookID";
            MySqlParameter Stock = new MySqlParameter("@Stock",textBox8.Text.Trim());
            MySqlParameter BookID = new MySqlParameter("@BookID", books[2]);
            int res = MySQLHelper.Instance.Update(query, Stock,BookID);
            if (res >= 1) 
            {
                MessageBox.Show("修改成功","修改提示");
                this.refresh();
                this.Close();
                return;
            }
            MessageBox.Show("修改失败", "修改提示");
            return ;
        }
    }
}
