using System;

namespace ConsoleUserManagerSystem.Services
{
    public static class DateTimeExtention
    {
        public static string GetFormatDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static string GetFormatDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}