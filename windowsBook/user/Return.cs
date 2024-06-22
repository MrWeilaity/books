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
using System.Xml.Linq;
using windowsBook;
namespace windowsBook.user
{
    public partial class Return : UserControl
    {
        public Return()
        {
            InitializeComponent();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            UpdateParentWindowData();
        }
        public void UpdateParentWindowData()// 父窗口 定义 委托具体逻辑
        {
            string query = "SELECT bor.RecordID as id, b.ISBN AS ISBN, b.Title AS 书名, b.Author AS 作者, b.Publisher AS 出版社, b.Year AS 出版年份, c.CategoryName as 图书分类, bor.BorrowQuantity AS 借书数量,bor.ReturnQuantity AS 还书数量, bor.BorrowDate AS 借书时间, bor.ReturnDate as 还书日期, bor.DueDate as 到期时间, " +
                           "CASE " +
                           "    WHEN bor.ReturnQuantity = bor.BorrowQuantity THEN '已还' " +
                           "    WHEN bor.ReturnQuantity = 0 THEN '未还' " +
                           "    WHEN bor.ReturnQuantity < bor.BorrowQuantity AND bor.ReturnQuantity > 0 THEN '未还清' " +
                           "    ELSE '未知状态' " +
                           "END AS 状态 " +
                           "FROM borrowrecords AS bor " +
                           "JOIN books AS b ON bor.ISBN = b.ISBN " +
                           "JOIN categories AS c ON b.CategoryID = c.CategoryID " +
                           "WHERE bor.UserID = @UserID";
            if (UserSession.Role == "admin")
            {
                query = "SELECT bor.RecordID as id,bor.UserID as 用户账号, b.ISBN AS ISBN, b.Title AS 书名, b.Author AS 作者, b.Publisher AS 出版社, b.Year AS 出版年份, c.CategoryName as 图书分类, bor.BorrowQuantity AS 借书数量,bor.ReturnQuantity AS 还书数量, bor.BorrowDate AS 借书时间, bor.ReturnDate as 还书日期, bor.DueDate as 到期时间, " +
                           "CASE " +
                           "    WHEN bor.ReturnQuantity = bor.BorrowQuantity THEN '已还' " +
                           "    WHEN bor.ReturnQuantity = 0 THEN '未还' " +
                           "    WHEN bor.ReturnQuantity < bor.BorrowQuantity AND bor.ReturnQuantity > 0 THEN '未还清' " +
                           "    ELSE '未知状态' " +
                           "END AS 状态 " +
                           "FROM borrowrecords AS bor " +
                           "JOIN books AS b ON bor.ISBN = b.ISBN " +
                           "JOIN categories AS c ON b.CategoryID = c.CategoryID ";
                           
            }

            MySqlParameter parameterUserID = new MySqlParameter("@UserID", UserSession.UserID);

            try
            {
                using (DataTable results = MySQLHelper.Instance.ExecuteQuery(query, parameterUserID))
                {
                    if (results != null && results.Rows.Count > 0)
                    {
                        dataGridView1.Visible = true; // 确保dataGridView1在显示结果时可见
                        dataGridView1.DataSource = results;

                        // 设置列标题
                        dataGridView1.Columns["状态"].HeaderText = "状态";

                        // 设置列宽
                        dataGridView1.Columns["状态"].Width = 100;

                        // 设置日期列格式
                        dataGridView1.Columns["借书时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dataGridView1.Columns["还书日期"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dataGridView1.Columns["到期时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        // 确保列标题和内容不会重叠
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                        MessageBox.Show("没有归还图书记录可供显示。");
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                MessageBox.Show("加载借阅记录时发生错误: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            List<string> list = new List<string>();
            // 检查是否有选中的行
            if (currentRow != null)
            {
                // 遍历当前选中行的所有单元格
                for (int i = 0; i < currentRow.Cells.Count; i++)
                {
                    // 获取单元格的数据
                    string cellValue = currentRow.Cells[i].Value?.ToString();
                    list.Add(cellValue);
                    // 输出单元格的数据
                    Console.WriteLine("单元格 " + i + " 的数据是: " + cellValue);
                }
                if (list[12] == "已还") 
                {
                    MessageBox.Show("已还清，不需要还书了","还书提示");
                    return;
                }
            }
            else 
            {
                MessageBox.Show("没有数据，不可进行操作","还书提示");
                return;
            }
            //判断当前时间是否大于到期时间
            DateTime currentTime = DateTime.Now; // 获取当前时间
           
            DateTime specificTime;
            if (!DateTime.TryParse(list[11], out specificTime))
            {
                Console.WriteLine("到期时间字符串格式不正确，无法进行比较。");
                return;
            }

            // 判断当前时间与特定时间的大小关系
            if (UserSession.Role != "admin") 
            {
                if (currentTime > specificTime)
                {
                    MessageBox.Show("还书时间已过，请联系管理员", "还书提示");
                    return;
                }
            }
            
           
            alterRutern alterRutern = new alterRutern(list);
            alterRutern.refresh += UpdateParentWindowData;
            alterRutern.Show();
        }
    }
}
