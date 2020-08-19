using System;

namespace ConsoleUserManagerSystem.Models
{
    public class User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        /// <value></value>
        public int OnlineStatusID { get; set; }

        /// <summary>
        /// 用户等级
        /// </summary>
        public int UserLevel { get; set; } = 1;

        public string LevelString
        {
            get
            {
                if (UserLevel < 5) return "⭐";
                if (UserLevel < 32) return "⭐⭐";
                if (UserLevel < 320) return "🌙";
                return "🌞";
            }
        }

        /// <summary>
        /// 在线时长
        /// </summary>
        public int? OnlineTime { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime? LastloginTime { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime { get; set; }
    }
}