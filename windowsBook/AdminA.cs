using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using windowsBook;
using windowsBook.admin;
using windowsBook.user;
namespace windowsBook
{
    public partial class AdminA : Form
    {
        Control originalControl;//原本context的控件，进行保存，方便切换回来
        public AdminA()
        {
            InitializeComponent();
        }
        private void admin_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            originalControl = context.Controls[0];//保存原本控件 用于切换
            this.Text = "欢迎管理员" + UserSession.UserName + "登录图书管理系统";
        }
        private void SwitchControl(Control newControl)//加载控件方法
        {
            // 清除Panel中的所有控件
            context.Controls.Clear();
            // 添加新的控件
            context.Controls.Add(newControl);

            newControl.Dock = DockStyle.Fill; // 如果需要，可以设置Dock样式 

        }
        //父菜单
        private void button1_Click(object sender, EventArgs e)
        {
           
            panel1.Visible = !panel1.Visible;
            SwitchControl(originalControl);
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
            SwitchControl(originalControl);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
            SwitchControl(originalControl);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SwitchControl(new AdminUser());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SwitchControl(new adminuserlist());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SwitchControl(new Increasethenumberofusers());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwitchControl(new adminBorrowingrecords());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SwitchControl(new adminLibrary());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SwitchControl(new Return());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchControl(new adminbooklist());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchControl(new addadminbook());
        }
        //具体页面菜单



    }
}
