using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsBook.admin
{
    public partial class AdminUser : UserControl
    {
        public AdminUser()
        {
            InitializeComponent();
        }

        private void AdminUser_Load(object sender, EventArgs e)
        {
            UpdateParentWindowData();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       
        public void UpdateParentWindowData()// 父窗口 定义 委托具体逻辑
        {
            //显示用户信息
            userid.Text = UserSession.UserID;
            username.Text = UserSession.UserName;
            userpawd.Text = UserSession.Password;

        }

        private void change_Click_1(object sender, EventArgs e)
        {
            alterchangeuser_user altr = new alterchangeuser_user();
            altr.refresh += UpdateParentWindowData;//添加委托给子窗口
            altr.ShowDialog();
        }
    }
}
