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
namespace windowsBook.admin
{
    public partial class adminBorrowingrecords : UserControl
    {
        public adminBorrowingrecords()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminBorrowingrecords_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string query = "SELECT bor.UserID as 借书账号 ,b.ISBN AS ISBN, b.Title AS 书名, b.Author AS 作者, b.Publisher AS 出版社, b.Year AS 出版年份, c.CategoryName as 图书分类, bor.BorrowQuantity AS 借书数量, bor.BorrowDate AS 借书时间 ," +
                "CASE " +
                           "    WHEN bor.ReturnQuantity = bor.BorrowQuantity THEN '已还' " +
                           "    WHEN bor.ReturnQuantity = 0 THEN '未还' " +
                           "    WHEN bor.ReturnQuantity < bor.BorrowQuantity AND bor.ReturnQuantity > 0 THEN '未还清' " +
                           "    ELSE '未知状态' " +
                           "END AS 状态 " +
                "FROM borrowrecords AS bor " +
                "JOIN books AS b ON bor.ISBN = b.ISBN " +
                "JOIN categories AS c ON b.CategoryID = c.CategoryID ";
                

           

            try
            {
                using (DataTable results = MySQLHelper.Instance.ExecuteQuery(query))
                {
                    if (results != null && results.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = results;
                        dataGridView1.Columns["状态"].HeaderText = "状态";

                        // 设置列宽
                        dataGridView1.Columns["状态"].Width = 100;
                        // 设置列标题
                        dataGridView1.Columns["借书账号"].HeaderText = "借书账号";
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
