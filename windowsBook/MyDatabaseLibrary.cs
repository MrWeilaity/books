using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
namespace MyDatabaseLibrary
{
    public class MySQLHelper
    {
        private static readonly MySQLHelper _instance = new MySQLHelper();
        private readonly MySqlConnection _connection;

        private MySQLHelper()
        {
            string connectionString = "server=localhost;database=book;user=root;password=;";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        public static MySQLHelper Instance
        {
            get { return _instance; }
        }

        public DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)//普通查询，返回DataTable
        {
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (MySqlException ex)
                {
                    // 处理MySqlException
                    Console.WriteLine("MySQL Exception: " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    // 处理其他异常
                    Console.WriteLine("An exception occurred: " + ex.Message);
                    throw;
                }
            }
        }
        //ExecuteReader返回一个MySqlDataReader对象
        /*  MySqlDataReader reader = dbHelper.ExecuteReader(query, parameter);

  // 遍历结果集
  while (reader.Read())
  {
      // 读取每行数据
      string column1 = reader["column1"].ToString();
          string column2 = reader["column2"].ToString();

          // 处理数据
          Console.WriteLine($"column1: {column1}, column2: {column2}");
  }

      // 关闭数据读取器
      reader.Close();*/
        public MySqlDataReader ExecuteReader(string query, params MySqlParameter[] parameters)
        {
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                try
                {
                    return command.ExecuteReader();
                }
                catch (MySqlException ex)
                {
                    // 处理MySqlException
                    Console.WriteLine("MySQL Exception: " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    // 处理其他异常
                    Console.WriteLine("An exception occurred: " + ex.Message);
                    throw;
                }
            }
        }
        //ExecuteScalar返回查询结果集中的第一个值 例如如COUNT、MAX、MIN等。
        /* string query = "SELECT COUNT(*) FROM users WHERE Username='test' and Password = '123456'";
         object count = MySQLHelper.Instance.ExecuteScalar(query);
         Console.WriteLine(count.ToString());*/
        public int ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                try
                {
                    object result = command.ExecuteScalar();

                    // 检查结果是否可以转换为整数
                    if (result is long)
                    {
                        // 结果是一个整数，但我们需要确保它不会超出 int 范围
                        long longValue = (long)result;
                        if (longValue <= int.MaxValue && longValue >= int.MinValue)
                        {
                            return (int)longValue;
                        }
                        else
                        {
                            throw new OverflowException("返回的值超出 int 范围。");
                        }
                    }
                    else
                    {
                        throw new InvalidCastException("返回的值不是整数类型。");
                    }
                }
                catch (MySqlException ex)
                {
                    // 处理MySqlException
                    Console.WriteLine("MySQL Exception: " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    // 处理其他异常
                    Console.WriteLine("An exception occurred: " + ex.Message);
                    throw;
                }
            }
        }



        public int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                foreach (MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    // 处理MySqlException
                    Console.WriteLine("MySQL Exception: " + ex.Message);
                    return -1;
                    throw;
                }
                catch (Exception ex)
                {
                    // 处理其他异常
                    Console.WriteLine("An exception occurred: " + ex.Message);
                    throw;
                }
            }
        }

        //对于INSERT语句，返回新插入行的ID。
        //对于UPDATE语句，返回受影响的行数。
        //对于DELETE语句，返回被删除的行数。
        // 插入数据
        public int Insert(string query, params MySqlParameter[] parameters)
        {
            try
            {
                return ExecuteNonQuery(query, parameters);
            }
            catch (MySqlException ex)
            {
                // 处理MySqlException
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine("An exception occurred: " + ex.Message);
                throw;
            }
        }

        // 删除数据
        public int Delete(string query, params MySqlParameter[] parameters)
        {
            try
            {
                return ExecuteNonQuery(query, parameters);
            }
            catch (MySqlException ex)
            {
                // 处理MySqlException
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine("An exception occurred: " + ex.Message);
                throw;
            }
        }

        // 更新数据
        public int Update(string query, params MySqlParameter[] parameters)
        {
            try
            {
                return ExecuteNonQuery(query, parameters);
            }
            catch (MySqlException ex)
            {
                // 处理MySqlException
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine("An exception occurred: " + ex.Message);
                throw;
            }
        }
    }
}