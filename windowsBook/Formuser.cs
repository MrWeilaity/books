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
using windowsBook.user;
using windowsBook;
namespace windowsBook
{
    public partial class Formuser : Form
    {
        public Formuser()
        {
            InitializeComponent();
        }


        
        Control originalControl;//原本context的控件，进行保存，方便切换回来
        
        private void Formuser_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + UserSession.UserName + "登录图书系统";
            panel1.Visible = false;
            originalControl = context.Controls[0];//保存原本控件 用于切换
            
           
        }
        private void SwitchControl(Control newControl)//加载控件方法
        {
            // 清除Panel中的所有控件
            context.Controls.Clear();
            // 添加新的控件
            context.Controls.Add(newControl);
           
            newControl.Dock = DockStyle.Fill; // 如果需要，可以设置Dock样式 
           
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            SwitchControl(originalControl);//加载原本控件



        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwitchControl(new UserPersonal());//加载控件UserPersonal 个人信息
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchControl(new Borrowingrecords());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwitchControl(new Return());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchControl(new adminLibrary());
        }
    }
}
