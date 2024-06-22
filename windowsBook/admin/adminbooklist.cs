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
namespace windowsBook.admin
{
    public partial class adminbooklist : UserControl
    {
        public adminbooklist()
        {
            InitializeComponent();
        }
        public void UpdateParentWindowData()
        {
            try
            {
                string query = "select b.BookID as ID, b.Title as 书名, b.Author as 作者, " +
               "b.ISBN as ISBN, b.Publisher as 出版社, b.Year as 出版年份, " +
               "c.CategoryName as 分类, b.Stock as 库存, b.Available as 可借数量 " +
               "from books as b " +
               "join categories as c on b.CategoryID = c.CategoryID;";


                using (DataTable res = MySQLHelper.Instance.ExecuteQuery(query))
                {
                    if (res.Rows.Count > 0 && res != null)
                    {
                        dataGridView1.DataSource = res;

                        // 检查并添加编辑按钮列
                        if (dataGridView1.Columns["Edit"] == null)
                        {
                            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                            editButtonColumn.Name = "Edit";
                            editButtonColumn.HeaderText = "编辑";
                            editButtonColumn.Text = "编辑";
                            editButtonColumn.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(editButtonColumn);
                        }

                        // 检查并添加删除按钮列
                        if (dataGridView1.Columns["Delete"] == null)
                        {
                            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                            deleteButtonColumn.Name = "Delete";
                            deleteButtonColumn.HeaderText = "删除";
                            deleteButtonColumn.Text = "删除";
                            deleteButtonColumn.UseColumnTextForButtonValue = true;
                            dataGridView1.Columns.Add(deleteButtonColumn);
                        }

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                        MessageBox.Show("没有用户可供显示。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载用户列表时发生错误: " + ex.Message);
            }
        }
        private void adminbooklist_Load(object sender, EventArgs e)
        {
            UpdateParentWindowData();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                //获取行值
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

                }
                if (columnName == "Edit")
                {
                    // 编辑操作
                    // 获取当前行的数据，并进行编辑操作
                    // ...

                    admineditbook admineditbook = new admineditbook(list);
                    admineditbook.refresh += UpdateParentWindowData;
                    admineditbook.ShowDialog();
                    Console.WriteLine("编辑");
                }
                else if (columnName == "Delete")
                {
                    // 删除操作
                    if (MessageBox.Show("确定要删除这条记录吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // 执行删除操作，例如从数据库中删除记录
                        // ...
                        MySqlParameter parameterBookID = new MySqlParameter("@BookID", list[2]);
                        string query = "delete from books where BookID=@BookID";
                        int res = MySQLHelper.Instance.Delete(query, parameterBookID);
                        if (res == 1)
                        {
                            MessageBox.Show("删除成功", "删除提示");

                        }
                        else
                        {
                            MessageBox.Show("删除失败", "删除提示");
                            return;
                        }
                        // 删除DataGridView中的行
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();
            seacher(text, "ISBN");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text.Trim();
            seacher(text, "书名");
        }
        private void seacher(string text, string column)
        {


            DataTable originalDataTable = dataGridView1.DataSource as DataTable;

            if (originalDataTable != null)
            {
                // 对原始数据表进行查询
                var query = from row in originalDataTable.AsEnumerable()
                            where row.Field<string>(column).Contains(text)
                            select row;

                // 将查询结果转换为新的 DataTable
                try
                {
                    DataTable filteredTable = query.CopyToDataTable();

                    // 更新 dataGridView1 的数据源
                    dataGridView1.DataSource = filteredTable;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("没有对应的查询图书","查询提示");
                    Console.WriteLine("没有对应的查询图书"+ex.Message);
                }
                
            }
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
    }
}
