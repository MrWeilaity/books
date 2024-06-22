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
    public partial class adminuserlist : UserControl
    {
        public adminuserlist()
        {
            InitializeComponent();
        }
        public void UpdateParentWindowData()
        {
            try
            {
                string query = "select * from users";
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

        private void adminuserlist_Load(object sender, EventArgs e)
        {
            UpdateParentWindowData();
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                    
                    EditUser editUser = new EditUser(list);
                    editUser.refresh+=UpdateParentWindowData;
                    editUser.ShowDialog();
                    Console.WriteLine("编辑");
                }
                else if (columnName == "Delete")
                {
                    // 删除操作
                    if (MessageBox.Show("确定要删除这条记录吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // 执行删除操作，例如从数据库中删除记录
                        // ...
                        MySqlParameter parameterUserID = new MySqlParameter("@UserID", list[2]);
                        string query = "delete from users where UserID=@UserID";
                        int res = MySQLHelper.Instance.Delete(query, parameterUserID);
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
    }
}
