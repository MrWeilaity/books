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
using windowsBook;
using static windowsBook.alterchangeuser_user;
namespace windowsBook
{
    
    public partial class Login : Form
    {
        private bool islogin = true;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
            GenerateCaptcha();//初始化调用验证码
            /*string query = "SELECT * FROM users";
            DataTable results = MySQLHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in results.Rows)
            {
                string rowText = string.Join(",", row.ItemArray);
                Console.WriteLine(rowText);
            }*/
        }
        private string captcha = "";//验证码变量
        private void GenerateCaptcha()//生成验证码
        {
            Bitmap bmp = new Bitmap(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            captcha = "";
            Random r = new Random();
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            // 添加干扰线
            for (int i = 0; i < 10; i++)
            {
                int x1 = r.Next(bmp.Width);
                int y1 = r.Next(bmp.Height);
                int x2 = r.Next(bmp.Width);
                int y2 = r.Next(bmp.Height);

                Pen pen = new Pen(Color.Gray, 2);
                g.DrawLine(pen, x1, y1, x2, y2);
            }
            // 生成4位验证码
            for (int i = 0; i < 4; i++)
            {
                int index = r.Next(allowedChars.Length);
                char c = allowedChars[index];
                captcha += c;
                // 调整字体大小以适应PictureBox控件的大小
                float fontSize = Math.Min(pictureBoxCaptcha.Width / 5, pictureBoxCaptcha.Height);
                g.DrawString(c.ToString(), new Font("Arial", fontSize, FontStyle.Bold), Brushes.Black, new PointF(10 + i * fontSize, 10));
            }

            

            pictureBoxCaptcha.Image = bmp;
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            // 首先判断验证码是否正确
            if (yanzhenma.Text != captcha)
            {
                GenerateCaptcha();
                MessageBox.Show("验证码不正确，请检查后再登录", "登录提示");
                return;
            }

            // 执行验证账号密码
            string UserID = userid.Text.Trim();
            string Password = password.Text.Trim();

            if (UserID == "" || Password == "")
            {
                MessageBox.Show("请填写完整账号密码", "登录提示");
                return;
            }
            
            // 查询数据库，检查用户名和密码
            string query = "SELECT COUNT(*), Role,Username FROM users WHERE UserID = @UserID AND Password = @Password GROUP BY Role";
            MySqlParameter parameterUsername = new MySqlParameter("@UserID", UserID);
            MySqlParameter parameterPassword = new MySqlParameter("@Password", Password);

            // 使用ExecuteReader来获取查询结果
            using (MySqlDataReader reader = MySQLHelper.Instance.ExecuteReader(query, parameterUsername, parameterPassword))
            {
                if (reader.HasRows)
                {
                    reader.Read(); // 读取第一行数据
                    int count = reader.GetInt32(0); // 获取 COUNT(*) 结果
                    string role = reader.GetString(1); // 获取 Role 字段
                    string Username = reader.GetString(2);
                    if (count == 0)
                    {
                        MessageBox.Show("账号或密码不对", "登录提示");
                        return;
                    }

                    // 根据Role字段判断是管理员还是普通用户
                    if (role == "admin")
                    {
                        islogin = false;
                        UserSession.Isadmin = true;
                        UserSession.isexit = false;
                        // 如果是管理员，则跳转到管理员页面
                        MessageBox.Show("管理员登录成功", "登录提示");
                        // TODO: 打开管理员页面
                        UserSession.UserID = UserID;
                        UserSession.Password = Password;
                        UserSession.UserName = Username;
                        UserSession.Role=role;
                        this.Close();
                        //打开管理员页面
                        AdminA admin = new AdminA();
                        admin.Show();
                    }
                    else if (role == "user")
                    {
                        islogin = false;
                        
                        // 如果是普通用户，则跳转到用户页面
                        MessageBox.Show("用户登录成功", "登录提示");
                        UserSession.UserID = UserID;
                        UserSession.Password = Password;
                        UserSession.UserName = Username;
                        UserSession.Role = role;
                        // TODO: 打开用户页面
                        this.Close();
                        Formuser formuser = new Formuser();
                        formuser.Show();
                    }
                    else
                    {
                        // 未知角色
                        MessageBox.Show("未知角色，登录失败", "登录提示");
                    }
                }
                else
                {
                    // 如果没有读取到数据，则用户名或密码错误
                    MessageBox.Show("账号或密码不对", "登录提示");
                }
            }
        }


        private void btn_enroll_Click(object sender, EventArgs e)//关闭当前页面，跳转登注册页面
        {
            this.Hide();
            enrollcs enrollcs = new enrollcs();
            enrollcs.refresh += showlogin;//添加委托给子窗口
            enrollcs.Show();

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (islogin) 
            {
                UserSession.isexit = false;
            }
          
        }
        public void showlogin() 
        {
            Console.WriteLine("show");
            this.Show();
        }
    }
}
