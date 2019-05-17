using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CX4.Infrastructure.Service.Utility
{
    /// <summary>
    /// 通用枚举帮助类
    /// </summary>
    public static class UtilityEnum
    {
        /// <summary>
        /// 获取字典集合的枚举集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDictionary<int, string> GetOptionList(Type type)
        {
            IDictionary<int, string> dic = new Dictionary<int, string>();
            if (type.IsEnum)
            {
                FieldInfo[] fieldInfoList = type.GetFields();
                var query = fieldInfoList.Where(k => GetDescription(k).Length > 0);
                foreach (var item in query)
                {
                    dic.Add((int)item.GetValue(null), GetDescription(item)[0].Description);
                }
            }
            return dic;
        }

        /// <summary>
        /// 获取指定枚举类型获取值
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetValue(Enum e)
        {
            Type t = e.GetType();
            FieldInfo fieldInfo = t.GetField(e.ToString());
            int retVlaue = (int)fieldInfo.GetValue(null);
            return retVlaue;
        }

        /// <summary>
        /// 获取指定枚举类型获取描叙信息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(Enum e)
        {
            Type t = e.GetType();
            FieldInfo fieldInfo = t.GetField(e.ToString());
            DescriptionAttribute[] desc = GetDescription(fieldInfo);
            return desc.Length > 0 ? desc[0].Description : null;
        }

        /// <summary>
        /// 根据字段获取枚举描叙信息
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        public static DescriptionAttribute[] GetDescription(FieldInfo fieldInfo)
        {
            DescriptionAttribute[] desc = null;
            if (fieldInfo != null)
            {
                desc = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return desc;
        }

        /// <summary>
        /// 将字符串转换为枚举
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static T GetEnum<T>(int Value)
        {
            T t = default(T);
            if (t is Enum)
            {
                t = (T)Enum.Parse(typeof(T), Value.ToString());
            }
            return t;
        }
    }
}
