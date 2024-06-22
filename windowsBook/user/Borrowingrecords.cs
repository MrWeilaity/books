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
using MySqlX.XDevAPI.Common;
using windowsBook;
namespace windowsBook.user
{
    public partial class Borrowingrecords : UserControl
    {
        public Borrowingrecords()
        {
            InitializeComponent();
        }

        private void Borrowingrecords_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=null;
            string query = "SELECT b.ISBN AS ISBN, b.Title AS 书名, b.Author AS 作者, b.Publisher AS 出版社, b.Year AS 出版年份, c.CategoryName as 图书分类, bor.BorrowQuantity AS 借书数量, bor.BorrowDate AS 借书时间 " +
                "FROM borrowrecords AS bor " +
                "JOIN books AS b ON bor.ISBN = b.ISBN " +
                "JOIN categories AS c ON b.CategoryID = c.CategoryID " +
                "WHERE bor.UserID = @UserID";

            MySqlParameter parameterUserID = new MySqlParameter("@UserID", UserSession.UserID);

            try
            {
                using (DataTable results = MySQLHelper.Instance.ExecuteQuery(query, parameterUserID))
                {
                    if (results != null && results.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = results;

                        // 设置列标题
                        dataGridView1.Columns["ISBN"].HeaderText = "ISBN";
                        dataGridView1.Columns["书名"].HeaderText = "书名";
                        dataGridView1.Columns["作者"].HeaderText = "作者";
                        dataGridView1.Columns["出版社"].HeaderText = "出版社";
                        dataGridView1.Columns["出版年份"].HeaderText = "出版年份";
                        dataGridView1.Columns["图书分类"].HeaderText = "图书分类";
                        dataGridView1.Columns["借书数量"].HeaderText = "借书数量";
                        dataGridView1.Columns["借书时间"].HeaderText = "借书时间";

                        // 设置列宽
                        dataGridView1.Columns["ISBN"].Width = 100;
                        dataGridView1.Columns["书名"].Width = 150;
                        dataGridView1.Columns["借书数量"].Width = 50;
                        // ... 继续设置其他列宽

                        // 设置日期列格式
                        dataGridView1.Columns["借书时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        // 设置其他列格式（如果需要）

                        // 确保列标题和内容不会重叠
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                        MessageBox.Show("没有借阅记录可供显示。");
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                MessageBox.Show("加载借阅记录时发生错误: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
