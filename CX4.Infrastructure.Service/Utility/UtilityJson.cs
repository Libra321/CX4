using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;

namespace CX4.Infrastructure.Service.Utility
{
    /// <summary>
    /// JSON工具类
    /// </summary>
    public static class UtilityJson
    {
        /// <summary>
        /// 将字符串序列化为JSON格式
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }

        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="datetimeformats">自定义时间格式</param>
        /// <returns></returns>
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = datetimeformats
            };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        /// <summary>
        /// 将JSON格式字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">目标对象</typeparam>
        /// <param name="Json">json格式字符串</param>
        /// <returns></returns>
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }

        /// <summary>
        /// 将JSON格式字符串反序列化为对象集合
        /// </summary>
        /// <typeparam name="T">目标对象</typeparam>
        /// <param name="Json">json格式字符串</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }

        /// <summary>
        /// 将JSON格式字符串反序列化为datable
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }

        /// <summary>
        /// 将JSON格式字符串反序列化为匿名对象
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }
    }
}
