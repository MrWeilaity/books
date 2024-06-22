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
namespace windowsBook.admin
{
    public partial class Increasethenumberofusers : UserControl
    {
        public Increasethenumberofusers()
        {
            InitializeComponent();
        }

        private void Increasethenumberofusers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == radioButton2.Checked)
            {
                MessageBox.Show("权限不能为空","添加提示");
                return;
            }
            MySqlParameter UserID = new MySqlParameter("@UserID", textBox1.Text.Trim());
            MySqlParameter Username = new MySqlParameter("@Username", textBox2.Text.Trim());
            MySqlParameter Password = new MySqlParameter("@Password", textBox3.Text.Trim());
            MySqlParameter Role;
            if (radioButton1.Checked == true)
            {
                Role = new MySqlParameter("@Role", "user");
            }
            else
            {
                Role = new MySqlParameter("@Role", "admin");
            }
            string query = "insert into users values(@UserID,@Username,@Password,@Role)";
            int res = MySQLHelper.Instance.Insert(query,UserID,Username,Password,Role);
            Console.WriteLine(res);
            if (res == 0 ||res==-1)
            {
                MessageBox.Show("添加失败,账户不能重复", "添加提示");
                return;
            }
            else if (res == 1) 
            {
                MessageBox.Show("添加成功", "添加提示");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                return;
            }
        }
    }
}
