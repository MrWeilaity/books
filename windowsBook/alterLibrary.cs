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
namespace windowsBook
{
    public partial class alterLibrary : Form
    {
        public delegate void UpdateParentWindowData(); // 子窗口声明定义委托 refresh()
        public event UpdateParentWindowData refresh;//定义委托
        private List<string> list;
        public alterLibrary(List<string> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void alterLibrary_Load(object sender, EventArgs e)
        {
            MessageBox.Show("还书期限为借书日期的后五天","借书提示");
            textBox1.Text= list[0];
            textBox2.Text= list[1];
            textBox3.Text= list[2];
            textBox4.Text= list[3];
            textBox5.Text= list[4];
            textBox6.Text= list[5];
            textBox7.Text= list[6];
            textBox8.Text= list[7];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //借书
            //判断有没有本条书的借书记录，有则也插入吧，无则插入
           
            //判断数量对不对
            if (int.Parse(textBox9.Text.ToString())<=0 || int.Parse(textBox9.Text.ToString()) > int.Parse(list[7])) 
            {
                MessageBox.Show("借书数量不对，请重新输入","借书提示");
                return;
            }
            
            DateTime currentTime = DateTime.Now.AddDays(5);
            DateTime dateTime = DateTime.Now;
            
          
            
            //进行插入
            string query = "insert into borrowrecords(UserID,ISBN,BorrowQuantity,BorrowDate,DueDate) values(@UserID,@ISBN,@BorrowQuantity,@BorrowDate,@DueDate)";
            MySqlParameter ParameterUserID = new MySqlParameter("@UserID", UserSession.UserID);
            MySqlParameter ParameterISBN = new MySqlParameter("@ISBN", list[3]);
            MySqlParameter ParameterBorrowQuantity = new MySqlParameter("@BorrowQuantity", textBox9.Text.ToString());//借书数量
            MySqlParameter ParameterBorrowDate = new MySqlParameter("@BorrowDate", dateTime);
            MySqlParameter ParameterDueDate = new MySqlParameter("@DueDate", currentTime);
            int insert = MySQLHelper.Instance.Insert(query, ParameterUserID, ParameterISBN, ParameterBorrowQuantity, ParameterBorrowDate, ParameterDueDate);
            if (insert == 1)
            { 
                MessageBox.Show("借书成功", "借书提示");
                this.refresh();
                this.Close();
                return;
            }
            else
            { 
                MessageBox.Show("借书失败", "借书提示"); return; 
            }
           
        }
           
                
            

        
    }
}
