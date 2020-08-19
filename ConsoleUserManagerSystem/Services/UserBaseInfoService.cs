using System;
using ConsoleUserManagerSystem.Models;

namespace ConsoleUserManagerSystem.Services
{
    public class UserBaseInfoService
    {
        // 需要用到User相关信息,readonly只能本身或构造函数时赋值，其他地方不能修改
        private readonly UserService _userService = new UserService();

        /// <summary>
        /// 创建用户详细信息
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <param name="nickName">昵称</param>
        /// <param name="gender">性别</param>
        /// <param name="bornDate">出生日期</param>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <param name="address">地址</param>
        /// <param name="phone">电话号码</param>
        public void CreateUserInfo(string pwd, string nickName, string gender, DateTime bornDate, string province, string city, string address, string phone)
        {
            // 需要校验参数，此处略。
            //
            var user = _userService.CreateUser(pwd);
            var sql = $"INSERT INTO [UserBaseInfo] VALUES ({user.UserID},'{nickName}','{gender}','{bornDate.GetFormatDateString()}','{province}','{city}','{address}','{phone}')";
            DBHelper.Update(sql);
        }

        /// <summary>
        /// 通过用户ID查找用户详细信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>返回用户详细信息</returns>
        public UserBaseInfo GetUserBaseInfoByUserID(long userId)
        {
            //UserID OnlineStatusID UserLevel OnlineTime LastloginTime RegTime
            var sql = $"SELECT UserID,NickName,Gender,BornDate,Province,City,Address,Phone FROM [UserBaseInfo] WHERE UserID={userId}";
            var dr = DBHelper.SelectForReader(sql);
            UserBaseInfo userBaseInfo = null;
            if (dr.Read())
            {
                userBaseInfo = new UserBaseInfo()
                {
                    UserID = userId,
                    NickName = dr.GetString(1),
                    Gender = dr.GetString(2),
                    BornDate = dr.GetDateTime(3),
                    Province = dr.GetString(4),
                    City = dr.GetString(5),
                    Address = dr.GetString(6),
                    Phone = dr.GetString(7),
                    User = _userService.GetUserByUserID(userId)
                };
            }
            dr.Close();
            return userBaseInfo;
        }

        /// <summary>
        /// 删除用户详细和简单信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        public void RemoveUserBaseInfoByUserID(long userId)
        {
            var sql = $"SELECT COUNT(0) FROM [UserBaseInfo] WHERE UserID={userId}";
            if ((int)DBHelper.SelectForScalar(sql) != 1) throw new AggregateException("提示：用户ID不存在！");

            // 数据表联动，先删子表，再删主表
            sql = $"DELETE FROM [UserBaseInfo] WHERE UserID={userId}";
            if (DBHelper.Update(sql))
            {
                _userService.RemoveUserByUserID(userId);
            }
        }
    }
}