using MyDatabaseLibrary;
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
using windowsBook;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace windowsBook
{
    public partial class EditUser : Form
    {
        public delegate void UpdateParentWindowData(); // 子窗口声明定义委托 refresh()
        public event UpdateParentWindowData refresh;//定义委托
        private List<string> users = new List<string>();
        public EditUser(List<string> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            textBox1.Text= users[2];
            textBox2.Text= users[3];
            textBox3.Text= users[4];
            if (users[5] == "user")
            {
                radioButton1.Checked = true;
            }
            else 
            {
                radioButton2.Checked = true;
            }
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.SelectionLength = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //更新数据
            string Username = textBox2.Text.Trim();
            string Password = textBox3.Text.Trim();
            string Role;
            if (radioButton1.Checked == true)
            {
                Role = "user";
            }
            else 
            {
                Role= "admin";
            }
            string query = "update users set Username=@Username,Password=@Password,Role=@Role where UserID=@UserID";
            MySqlParameter ParameterUsername = new MySqlParameter("@Username", Username);
            MySqlParameter ParameterPassword = new MySqlParameter("@Password", Password);
            MySqlParameter ParameterRole = new MySqlParameter("@Role", Role);
            MySqlParameter ParameterUserID = new MySqlParameter("@UserID", users[2]);
            int res = MySQLHelper.Instance.Update(query, ParameterUsername, ParameterPassword, ParameterRole, ParameterUserID);
            if (res == 0) 
            {
                MessageBox.Show("修改失败","修改提示");
                return;
            }
            MessageBox.Show("修改成功", "修改提示");
            this.refresh();
            this.Close();
        }
    }
}
