using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ClientWebAPI.Common
{
    public static class APIHelper
    {
        //Ứng dụng linh hoạt của Generic

        /// <summary>
        /// Trả vể list obj từ api
        /// thường sử dụng trong việc Lấy danh sách dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiBaseAddress"></param>
        /// <param name="linkApi"></param>
        /// <returns></returns>
        public static List<T> GetListFromAPI<T>(string apiBaseAddress, string linkApi)
        {
            try
            {
                List<T> lst = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync(linkApi);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<T>>();
                        readTask.Wait();

                        lst = readTask.Result;
                        return lst;
                    }
                    else
                    {
                        throw new Exception("Không thể kết nối đến API");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Không thể kết nối đến API");
            }
        }

        /// <summary>
        /// Lấy giá trị đơn lẻ từ API
        /// Có thể trả về các kiểu như int , string, ... hoặc là Object
        /// </summary>
        /// <param name="apiBaseAddress"></param>
        /// <param name="linkApi"></param>
        /// <returns></returns>
        public static dynamic GetDynamicFromAPI(string apiBaseAddress, string linkApi)
        {
            try
            {
                dynamic dnm = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync(linkApi);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<dynamic>();
                        readTask.Wait();

                        dnm = readTask.Result;
                        return dnm;
                    }
                    else
                    {
                        throw new Exception("Không thể kết nối đến API");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể kết nối đến API");
            }
        }

        /// <summary>
        /// Hàm này  thì thích trả về kiểu gì cũng được hết
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiBaseAddress"></param>
        /// <param name="linkApi"></param>
        /// <returns></returns>
        public static T GetDataFromAPI<T>(string apiBaseAddress, string linkApi)
        {
            try
            {
                T res;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync(linkApi);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<T>();
                        readTask.Wait();

                        res = readTask.Result;
                        return res;
                    }
                    else
                    {
                        throw new Exception("Không thể kết nối đến API");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể kết nối đến API");
            }
        }


        /// <summary>
        /// Post lên một dữ liệu kiểu T và trả về một bản ghi kiểu T  -> Ít khi dùng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiBaseAddress"></param>
        /// <param name="linkApi"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T PostDataToAPI<T>(string apiBaseAddress, string linkApi, T data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<T>(linkApi, data);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<T>();
                        readTask.Wait();
                        var acc = readTask.Result;
                        return acc;
                    }
                    else
                    {
                        throw new Exception("Không thể kết nối đến API");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể kết nối đến API");
            }
        }

        /// <summary>
        /// Post lên một đối tượng kiểu T và trả về một giá trị dymanic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiBaseAddress"></param>
        /// <param name="linkApi"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static dynamic PostDataToAPIReturnDynamic<T>(string apiBaseAddress, string linkApi, T data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<T>(linkApi, data);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<dynamic>();
                        readTask.Wait();
                        var res = readTask.Result;
                        return res;
                    }
                    else
                    {
                        throw new Exception("Không thể kết nối đến API");
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}