using System;
using ConsoleUserManagerSystem.Models;

namespace ConsoleUserManagerSystem.Services
{
    public class UserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userId">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Login(long userId, string pwd)
        {
            var sql = $"SELECT COUNT(0) FROM [User] WHERE UserID={userId} AND UserPwd={pwd}";
            // 判断返回结果是否为1，如果为1则表示存在数据，结果为true
            return (int)DBHelper.SelectForScalar(sql) == 1;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="pwd"></param>
        public User CreateUser(string pwd)
        {
            // 判断密码是否有误
            if (pwd.Trim().Length < 6) throw new AggregateException("提示：您输入的密码不能少于6位！");
            // 如果上面抛异常了，以下语句都不执行
            var userId = RandomUserID();
            var onlineStatusID = 0;
            var userLevel = 0;
            var onlineTime = 0;
            var lastLoginTime = DBNull.Value;
            DateTime regTime = DateTime.Now;
            var sql = $"INSERT INTO [User] VALUES({userId},'{pwd.Trim()}',{onlineStatusID},{userLevel},{onlineTime},{lastLoginTime},{regTime.GetFormatDateTimeString()})";
            DBHelper.Update(sql);
            // 返回用户对象
            return new User()
            {
                UserID = userId,
                UserPwd = pwd.Trim(),
                OnlineStatusID = onlineStatusID,
                UserLevel = userLevel,
                OnlineTime = onlineTime,
                //LastloginTime = lastLoginTime,
                RegTime = regTime
            };
        }

        // 用户ID为随机生成，生成后需要判断在库中是否存在改值
        /// <summary>
        /// 获取随机的未被占用的ID
        /// </summary>
        /// <returns>生成的ID</returns>
        public long RandomUserID()
        {
            Random rdm = new Random();
            // 循环判断生成的ID是否在库中被占用
            while (true)
            {
                long id = rdm.Next(10000000, 99999999);
                var sql = $"SELECT COUNT(0) FROM [User] WHERE UserID={id}";
                if ((int)DBHelper.SelectForScalar(sql) == 0)
                {
                    // 如果没有被占用则返回当前ID
                    return id;
                }
            }
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="oldPwd">原密码</param>
        /// <param name="newPwd">新密码</param>
        public void UpdateUserPwd(long userId, string oldPwd, string newPwd)
        {
            newPwd = newPwd.Trim();
            if (!Login(userId, oldPwd)) throw new AggregateException("提示：用户ID不存在！");
            if (newPwd.Length < 6) throw new AggregateException("提示：新密码不能少于6位！");
            var sql = $"UPDATE [User] SET UserPwd={newPwd} WHERE UserID={userId}";
            DBHelper.Update(sql);
        }

        /// <summary>
        /// 通过用户ID查找用户简单信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>返回用户相关信息</returns>
        public User GetUserByUserID(long userId)
        {
            //UserID OnlineStatusID UserLevel OnlineTime LastloginTime RegTime
            var sql = $"SELECT UserID,OnlineStatusID,UserLevel,OnlineTime,LastloginTime,RegTime FROM [User] WHERE UserID={userId}";
            var dr = DBHelper.SelectForReader(sql);
            User user = null;
            if (dr.Read())
            {
                user = new User()
                {
                    UserID = userId,
                    OnlineStatusID = dr.GetInt32(1),
                    UserLevel = dr.GetInt32(2),
                    OnlineTime = dr.GetInt32(3),
                    LastloginTime = dr.GetDateTime(4),
                    RegTime = dr.GetDateTime(5)
                };
            }
            dr.Close();
            return user;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        public void RemoveUserByUserID(long userId)
        {
            var sql = $"SELECT COUNT(0) FROM [User] WHERE UserID={userId}";
            if ((int)DBHelper.SelectForScalar(sql) != 1) throw new AggregateException("提示：用户ID不存在！");
            sql = $"DELETE FROM [User] WHERE UserID={userId}";
            DBHelper.Update(sql);
        }
    }
}