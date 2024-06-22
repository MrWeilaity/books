using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Google.Protobuf;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using MyDatabaseLibrary;
namespace windowsBook.admin
{
    
    public partial class addadminbook : UserControl
    {
        public addadminbook()
        {
            InitializeComponent();
        }

        private void addadminbook_Load(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox2.Text.Trim();
            string author = textBox3.Text.Trim();
            string isbn = textBox4.Text.Trim();
            string publisher = textBox5.Text.Trim();
            string year = textBox6.Text.Trim();
            string categoryName = textBox7.Text.Trim();
            string stockText = textBox8.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn) ||
                string.IsNullOrWhiteSpace(publisher) || string.IsNullOrWhiteSpace(year) || string.IsNullOrWhiteSpace(categoryName) ||
                string.IsNullOrWhiteSpace(stockText))
            {
                MessageBox.Show("请检查字段是否全部已填", "添加提示");
                return;
            }

            int stock;
            if (!int.TryParse(stockText, out stock) || stock <= 0)
            {
                MessageBox.Show("请检查库存是否填写正确", "添加提示");
                return;
            }

            // 检查是否有相同的ISBN
            string checkIsbnQuery = "SELECT COUNT(*) FROM books WHERE ISBN = @ISBN";
            MySqlParameter isbnParameter = new MySqlParameter("@ISBN", isbn);
            int isbnCount = MySQLHelper.Instance.ExecuteScalar(checkIsbnQuery, isbnParameter);
            if (isbnCount > 0)
            {
                MessageBox.Show("该图书已有，不能添加，需要增加库存请前往图书列表", "增加图书");
                ClearForm();
                return;
            }

            // 获取分类ID
            string getCategoryIdQuery = "SELECT CategoryID FROM categories WHERE CategoryName = @CategoryName";
            MySqlParameter categoryNameParameter = new MySqlParameter("@CategoryName", categoryName);
            int categoryId = -1;
            using (MySqlDataReader reader = MySQLHelper.Instance.ExecuteReader(getCategoryIdQuery, categoryNameParameter))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    categoryId = reader.GetInt32("CategoryID");
                }
                else
                {
                    reader.Close();
                    // 如果没有找到分类，添加新分类
                    string maxCategoryIdQuery = "SELECT MAX(CategoryID) FROM categories";
                    using (MySqlDataReader maxReader = MySQLHelper.Instance.ExecuteReader(maxCategoryIdQuery))
                    {
                        if (maxReader.HasRows)
                        {
                            maxReader.Read();
                            try 
                            {
                                categoryId = maxReader.GetInt32(0) + 1;
                            }
                            catch 
                            {
                                categoryId = 1;
                            }
                            
                        }
                        else
                        {
                            categoryId = 1; // 如果没有分类，从1开始
                        }
                    }

                    // 插入新分类
                    string insertCategoryQuery = "INSERT INTO categories (CategoryID, CategoryName) VALUES (@CategoryID, @CategoryName)";
                    MySqlParameter aaa = new MySqlParameter("@CategoryID", categoryId);
                    int categoryInsertResult = MySQLHelper.Instance.Insert(insertCategoryQuery, aaa, categoryNameParameter);
                    if (categoryInsertResult != 1)
                    {
                        MessageBox.Show("添加分类失败", "添加图书");
                        return;
                    }
                }
            }

            // 插入新图书
            string insertBookQuery = "INSERT INTO books (Title, Author, ISBN, Publisher, Year, CategoryID, Stock, Available) " +
                "VALUES (@Title, @Author, @ISBN, @Publisher, @Year, @CategoryID, @Stock, @Stock)";
            MySqlParameter titleParameter = new MySqlParameter("@Title", title);
            MySqlParameter authorParameter = new MySqlParameter("@Author", author);
            MySqlParameter publisherParameter = new MySqlParameter("@Publisher", publisher);
            MySqlParameter yearParameter = new MySqlParameter("@Year", year);
            MySqlParameter stockParameter = new MySqlParameter("@Stock", stock);
            MySqlParameter availableParameter = new MySqlParameter("@Available", stock);
            MySqlParameter categoryIdParameter = new MySqlParameter("@CategoryID", categoryId);

            int bookInsertResult = MySQLHelper.Instance.Insert(insertBookQuery, titleParameter, authorParameter, isbnParameter, publisherParameter, yearParameter, categoryIdParameter, stockParameter, availableParameter);
            if (bookInsertResult == 1)
            {
                MessageBox.Show("增加图书成功", "添加图书");
                ClearForm();
            }
            else
            {
                MessageBox.Show("增加图书失败", "添加图书");
            }
        }


        private void ClearForm()
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox4.Focus();
        }


        private async Task showbookget(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 设置请求的URL
                    

                    // 发送GET请求
                    HttpResponseMessage response = await client.GetAsync(url);

                    // 确保请求成功
                    response.EnsureSuccessStatusCode();

                    // 读取响应内容
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // 反序列化JSON字符串
                    BookInfo bookInfo = JsonConvert.DeserializeObject<BookInfo>(responseBody);

                    // 访问数据
                    if (bookInfo.success)
                    {
                        Data bookData = bookInfo.data;
                        textBox3.Text=bookData.author;
                        textBox2.Text = bookData.bookName;
                        textBox5.Text = bookData.press;
                        try
                        {
                            textBox6.Text = bookData.pressDate.Substring(0, 4);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            textBox6.Text = bookData.pressDate;
                            Console.WriteLine(e.Message); 
                        }
                        
                      
                        textBox7.Text = bookData.clcName;
                        Console.WriteLine($"书名：{bookData.bookName}");
                        Console.WriteLine($"作者：{bookData.author}");
                        // ... 访问其他属性
                    }
                    else
                    {
                        MessageBox.Show("请求失败", "添加图书");
                        textBox4.Text = string.Empty;
                        textBox4.Focus();
                        Console.WriteLine("请求失败");
                        return;
                    }
                    // 输出响应内容
                   
                    
                }
                catch (HttpRequestException e)
                {
                    // 输出请求失败的错误信息
                    MessageBox.Show("请求失败","添加图书");
                    textBox4.Text = string.Empty;
                    textBox4.Focus();
                    Console.WriteLine($"请求失败: {e.Message}");
                    return;
                }
                catch (Exception e)
                {
                    // 输出其他可能的错误信息
                    MessageBox.Show("发生异常", "添加图书");
                    textBox4.Text = string.Empty;
                    textBox4.Focus();
                    Console.WriteLine($"发生异常: {e.Message}");
                    return;
                }
            }
        }

        private async void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            //捕获回车键
            if (e.KeyCode == Keys.Enter)
            {


                //获取条码资料

                string isbn = textBox4.Text.Trim();
                if (isbn.Length == 0) 
                {
                    MessageBox.Show("ISBN长度为空，请重新输入", "增加图书");
                    return;
                }
                if (!String.IsNullOrEmpty(isbn))
                {
                    Console.WriteLine(isbn);
                    //条码处理程序
                    //发起请求
                    string url = "http://data.isbn.work/openApi/getInfoByIsbn?isbn=" + isbn + "&appKey=ae1718d4587744b0b79f940fbef69e77";
                    await showbookget(url);
                }
            }
        }

        
    }
    public class BookInfo
    {
        public int code { get; set; }
        public Data data { get; set; }
        public bool success { get; set; }
    }

    public class Data
    {
        // 根据JSON结构定义属性
        public string bookName { get; set; }//书名
        public string author { get; set; }//作者
        public string press { get; set; }//出版社
        public string pressDate { get; set; }//出版年份
        public string clcName { get; set; }//分类



    }
}
