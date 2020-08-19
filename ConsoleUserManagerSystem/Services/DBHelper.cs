using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleUserManagerSystem.Services
{
    public class DBHelper
    {
        private const string ConnectionString = "server=.;database=UserManageSystem;uid=sa;pwd=sa";
        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <value></value>
        public static SqlConnection Con
        {
            get
            {
                var con = new SqlConnection(ConnectionString);
                con.Open();
                return con;
            }
        }
        /// <summary>
        /// 获取指令对象
        /// </summary>
        /// <returns></returns>
        private static SqlCommand Cmd { get { return Con.CreateCommand(); } }
        // 上面的1句话相当于下面2句话
        // var cmd = new SqlCommand(){Connection =Con};
        // return cmd;

        /// <summary>
        /// 增、删、改操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>受影响的行是否成功</returns>
        public static bool Update(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// 查询首行首列操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回第一行第一列的结果</returns>
        public static object SelectForScalar(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// 返回DataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回DataReader结果</returns>
        public static SqlDataReader SelectForReader(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Exception)
            {
                cmd.Connection.Close();
                return null;
            }
        }
    }
}