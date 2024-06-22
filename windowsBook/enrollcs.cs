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

namespace windowsBook
{
    public partial class enrollcs : Form
    {
        public delegate void showlogin(); // 子窗口声明定义委托 refresh()
        public event showlogin refresh;//定义委托
        
        public enrollcs()
        {
            InitializeComponent();
        }

        private void btn_enroll_Click(object sender, EventArgs e)
        {
            
            string UserID =userid.Text.Trim() ;//用户Id
            string Username = username.Text.Trim() ;
            string Password = password.Text.Trim();
            string Role = "user"; // 假设这是预定义的角色值，不应该直接从用户输入获取
            if (UserID == "" || Username == "" || Password == "")
            {
                MessageBox.Show("请完整填写所有字段", "注册提示");
                return;

            }
            string query = "INSERT INTO users(UserID,Username,Password,Role) VALUES(@UserID,@Username,@Password,@Role)";
            MySqlParameter parameterUserID = new MySqlParameter("@UserID", UserID);
            MySqlParameter parameterUsername = new MySqlParameter("@Username", Username);
            MySqlParameter parameterPassword = new MySqlParameter("@Password", Password);
            MySqlParameter parameterRole = new MySqlParameter("@Role", Role); // 这里添加了Role列的参数
            int res = MySQLHelper.Instance.Insert(query, parameterUserID, parameterUsername, parameterPassword, parameterRole);     
            if (res == -1) 
            {
                MessageBox.Show("已有账号，请直接登录","注册提示");
                return;
            }
            
            MessageBox.Show("注册成功","注册提示");
            // 关闭当前窗体
            this.Close();
            this.refresh();
        }

        

        private void enrollcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.refresh(); 
        }
    }
}
