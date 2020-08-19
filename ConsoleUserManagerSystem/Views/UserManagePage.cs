using System;
using ConsoleUserManagerSystem.Models;
using ConsoleUserManagerSystem.Services;

namespace ConsoleUserManagerSystem.Views
{
    public class UserManagePage
    {
        readonly UserService _UserService = new UserService();
        readonly UserBaseInfoService _UserBaseInfoService = new UserBaseInfoService();
        bool LoginPage()
        {
            Console.WriteLine("请输入账号：");
            var userId = long.Parse(Console.ReadLine());
            Console.WriteLine("请输入密码：");
            var pwd = Console.ReadLine();
            try
            {
                return _UserService.Login(userId, pwd);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        void ShowUserInfoPage()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("请输入账号：");
            var userId = long.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------");            
            try
            {
                var userBaseInfo = _UserBaseInfoService.GetUserBaseInfoByUserID(userId);
                Console.WriteLine($"用户ID：{userBaseInfo.UserID}\n昵称：{userBaseInfo.NickName}\n性别：{userBaseInfo.Gender}\n省份：{userBaseInfo.Province}\n城市：{userBaseInfo.City}\n地址：{userBaseInfo.Address}\n电话：{userBaseInfo.Phone}\n");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void UpdatePasswordPage()
        {
            Console.WriteLine("请输入账号：");
            var userId = long.Parse(Console.ReadLine());
            Console.WriteLine("请输入原密码：");
            var oldPwd = Console.ReadLine();
            Console.WriteLine("请输入新密码：");
            var newPwd = Console.ReadLine();
            try
            {
                _UserService.UpdateUserPwd(userId, oldPwd, newPwd);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // 添加用户，略

        void RemoveUserPage()
        {
            Console.WriteLine("请输入账号：");
            var userId = long.Parse(Console.ReadLine());
            try
            {
                // 使用子表删除，同时会删除主表
                _UserBaseInfoService.RemoveUserBaseInfoByUserID(userId);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 启动页面
        /// </summary>
        public void StartPage()
        {
            while (true)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("欢迎使用用户管理系统！");
                Console.WriteLine("1.登录");
                Console.WriteLine("2.退出");
                Console.WriteLine("-------------------------------------------------");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        if (LoginPage())
                        {
                            Console.WriteLine("进入主页面");
                            Console.WriteLine("-------------------------------------------------");
                            MainPage();
                        }
                        break;
                    case 2:
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("谢谢使用");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("您输入的信息有误，请重新输入！");
                        break;
                }
            }
        }

        /// <summary>
        /// 主页面
        /// </summary>
        void MainPage()
        {
            while (true)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1.添加用户（略）");
                Console.WriteLine("2.查看指定用户信息");
                Console.WriteLine("3.修改密码");
                Console.WriteLine("4.修改时长（略）");
                Console.WriteLine("5.删除用户");
                Console.WriteLine("6.注销");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("界面施工中");
                        break;
                    case 2:
                        ShowUserInfoPage();
                        break;
                    case 3:
                        UpdatePasswordPage();
                        break;
                    case 4:
                        Console.WriteLine("界面施工中");
                        break;
                    case 5:
                        RemoveUserPage();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("您输入的信息有误，请重新输入！");
                        break;
                }
            }
        }
    }
}