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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using windowsBook.user;
namespace windowsBook
{
    public partial class alterchangeuser_user : Form
    {
        public delegate void UpdateParentWindowData(); // 子窗口声明定义委托 refresh()
        public event UpdateParentWindowData refresh;//定义委托
        public alterchangeuser_user()
        {
            InitializeComponent();
        }

        private void alterchangeuser_user_Load(object sender, EventArgs e)
        {
            //显示信息
            userid.Text = UserSession.UserID;
            username.Text = UserSession.UserName;
            userpawd.Text = UserSession.Password;
            username.SelectionStart = username.Text.Length;
            username.SelectionLength = 0;
        }

        private void change_Click(object sender, EventArgs e)
        {
            //更新数据到数据库
            string UserID=userid.Text.Trim();
            string Username = username.Text.Trim();
            string Password = userpawd.Text.Trim();
            if (Username == "" || UserID == "" || Password == "") 
            {
                MessageBox.Show("字段不能为空","修改提示");
                return;
            }
            //修改之后要更新UserSession的对应值
            string query = "update users set Username=@Username,Password=@Password where UserID=@UserID";
            MySqlParameter parameterUserID = new MySqlParameter("@UserID", UserID);
            MySqlParameter parameterUsername = new MySqlParameter("@Username", Username);
            MySqlParameter parameterPassword = new MySqlParameter("@Password", Password);
            int count = MySQLHelper.Instance.Update(query,parameterUsername,parameterPassword,parameterUserID);
            if (count > 0) 
            {
                UserSession.Password = Password;
                UserSession.UserName = Username;
                MessageBox.Show("更新成功", "修改提示");
                this.refresh(); // 调用委托//跟新数据
                this.Close();
                return;
            }
            MessageBox.Show("更新失败", "修改提示");
        }
    }
}
