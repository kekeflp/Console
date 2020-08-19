using System;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace IocDemo
{
    public abstract class SendToolFactory
    {
        public static ISendable GetInstance()
        {
            try
            {
                // 引入反射机制
                // 加载程序集
                Assembly assembly = Assembly.LoadFile(GetAssembly());
                // 创建类的实例
                object obj = assembly.CreateInstance(GetObjectType());
                return obj as ISendable;
            }
            catch
            {
                return null;
            }
        }

        private static string GetAssembly()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["AssemblyString"]);
        }

        private static string GetObjectType()
        {
            return ConfigurationManager.AppSettings["TypeString"];
        }
    }
}