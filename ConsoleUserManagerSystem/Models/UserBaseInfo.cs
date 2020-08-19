using System;

namespace ConsoleUserManagerSystem.Models
{
    public class UserBaseInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BornDate { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 子表引用主表的对象
        /// </summary>
        /// <value></value>
        public User User { get; set; }
    }
}