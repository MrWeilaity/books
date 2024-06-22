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
namespace windowsBook.user
{
    public partial class adminLibrary : UserControl
    {
        public adminLibrary()
        {
            InitializeComponent();
        }

        private void Library_Load(object sender, EventArgs e)
        {

            UpdateParentWindowData();
        }

        public void UpdateParentWindowData()
        {
            string query = "select b.BookID as BookID ,b.Title as 书名, b.Author as 作者,b.ISBN,b.Publisher as 出版社,b.Year as 出版年份, c.CategoryName as 分类 ,b.Available as  可借数量  "
                + "from books as b"
                + " JOIN categories AS c ON b.CategoryID = c.CategoryID ";
            MySqlParameter books = new MySqlParameter("@books", "books");
            try
            {

                using (DataTable results = MySQLHelper.Instance.ExecuteQuery(query))
                {
                    if (results != null && results.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = results;

                        // 确保在数据绑定和列创建完成后设置列宽


                        // 设置列自动调整模式，这将在设置列宽之后执行
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.Columns["书名"].Width = 200;
                        dataGridView1.Columns["BookID"].Width = 50;
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                        MessageBox.Show("没有图书可供显示。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载图书发生错误: " + ex.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text =textBox1.Text.Trim();
            seacher(text, "ISBN");
        }
        private void button2_Click(object sender, EventArgs e)//书名查询,
        {
            string text = textBox2.Text.Trim();
            seacher(text, "书名");
        }
        private void seacher(string text,string column)
        {
           

            DataTable originalDataTable = dataGridView1.DataSource as DataTable;

            if (originalDataTable != null)
            {
                // 对原始数据表进行查询
                var query = from row in originalDataTable.AsEnumerable()
                            where row.Field<string>(column).Contains(text)
                            select row;

                try
                {
                    // 将查询结果转换为新的 DataTable
                    DataTable filteredTable = query.CopyToDataTable();

                    // 更新 dataGridView1 的数据源
                    dataGridView1.DataSource = filteredTable;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"搜索失败请重试：{ex.Message}");
                    return;
                }
               
            }
        }
        private void button3_Click(object sender, EventArgs e)
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
                if (int.Parse(list[7]) <= 0)
                {
                    MessageBox.Show("可借数量为0，不可借书","借书提示");
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("没有数据，不可进行操作", "借书提示");
                return;
            }
            alterLibrary alterLibrary = new alterLibrary(list);
            alterLibrary.refresh += UpdateParentWindowData;
            alterLibrary.ShowDialog();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int len = textBox1.Text.Length;
            if (len == 0) 
            {
                UpdateParentWindowData();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int len = textBox2.Text.Length;
            if (len == 0)
            {
                UpdateParentWindowData();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
