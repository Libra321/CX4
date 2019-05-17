using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CX4.Infrastructure.Service.Utility
{
    /// <summary>
    /// HTTP请求帮助类
    /// </summary>
    public static class UtilityHttp
    {
        /// <summary>
        /// http get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpResponseMessage Get(string url)
        {
            HttpResponseMessage result = default(HttpResponseMessage);
            using (HttpClient client = new HttpClient())
            {
                result = client.GetAsync(url).Result;
            }
            return result;
        }

        /// <summary>
        /// http get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T Get<T>(string url)
        {
            HttpResponseMessage result = Get(url);
            return result.Content.ReadAsStringAsync().Result.ToJson().ToString().ToObject<T>();
        }

        /// <summary>
        /// http get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var p = await client.GetAsync(url);
                return p;
            }
        }

        /// <summary>
        /// http get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            return result.ToJson().ToString().ToObject<T>();
        }

        /// <summary>
        /// http post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpResponseMessage Post(string url, object data)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(data))
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client.PostAsync(url, content).Result;
            }
        }

        /// <summary>
        /// http post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Post<T>(string url, object data)
        {
            HttpResponseMessage result = Post(url, data);
            return result.Content.ReadAsStringAsync().Result.ToJson().ToString().ToObject<T>();
        }

        /// <summary>
        /// http post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostAsync(string url, object data)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(data))
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await client.PostAsync(url, content);
            }
        }

        /// <summary>
        /// http post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string url, object data)
        {
            HttpResponseMessage response = await PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            return result.ToJson().ToString().ToObject<T>();
        }
    }
}
