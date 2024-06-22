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
using MyDatabaseLibrary;
using MySql.Data.MySqlClient;
namespace windowsBook.user
{
    public partial class UserPersonal : UserControl
    {
        public UserPersonal()
        {
            InitializeComponent();

        }

        private void UserPersonal_Load(object sender, EventArgs e)
        {

            UpdateParentWindowData();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void change_Click(object sender, EventArgs e)//修改按钮
        {
            //弹出修改
            alterchangeuser_user altr = new alterchangeuser_user();
            altr.refresh += UpdateParentWindowData;//添加委托给子窗口
            altr.ShowDialog();
        }
        public void UpdateParentWindowData()// 父窗口 定义 委托具体逻辑
        {
            //显示用户信息
            userid.Text = UserSession.UserID;
            username.Text = UserSession.UserName;
            userpawd.Text = UserSession.Password;

        }

    }
}
