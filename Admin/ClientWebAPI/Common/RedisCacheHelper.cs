using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Common
{
    public class RedisCacheHelper
    {
        private readonly RedisEndpoint _redisEndpoint;
        public RedisCacheHelper()
        {
            var host = ConfigurationManager.AppSettings["redisCacheHost"];
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["redisCachePort"]);
            _redisEndpoint = new RedisEndpoint(host, port);
        }

        public bool IsKeyExists(string key)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                if (redisClient.ContainsKey(key))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void SetStrings(string key, string value)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                redisClient.SetValue(key, value);
            }
        }

        public string GetStrings(string key, string value)
        {
            using (var redisClient = new RedisClient(_redisEndpoint))
            {
                return redisClient.GetValue(key);
            }
        }

        public bool StoreList<T>(string key, T value, TimeSpan timeout)
        {
            try
            {
                using (var redisClient = new RedisClient(_redisEndpoint))
                {
                    redisClient.As<T>().SetValue(key, value, timeout);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetList<T>(string key)
        {
            T result;

            using (var client = new RedisClient(_redisEndpoint))
            {
                var wrapper = client.As<T>();

                result = wrapper.GetValue(key);
            }

            return result;
        }

        public long Increment(string key)
        {
            using (var client = new RedisClient(_redisEndpoint))
            {
                return client.Increment(key, 1);
            }
        }

        public long Decrement(string key)
        {
            using (var client = new RedisClient(_redisEndpoint))
            {
                return client.Decrement(key, 1);
            }
        }
    }
}




//Nếu đã có key trong Cache thì lấy ra luôn
//if (redisCache.IsKeyExists(LST_USER_CACHE))
//{
//    lst = redisCache.GetList<List<AccountModel>>(LST_USER_CACHE);
//}
//else //Nếu chưa tồn tại key trong Cache thì lấy từ db ra rồi lưu lại vào cache
//{
//    IAccountService accountService = new AccountService();
//    string linkApi = "/account/getlistuser";
//    lst = accountService.GetListUser(baseAddress, linkApi);
//    redisCache.StoreList<List<AccountModel>>(LST_USER_CACHE, lst, TimeSpan.FromSeconds(TIME_EXPIRE_LST_USER_CACHE));
//    log.Info("Tạo cache " + LST_USER_CACHE);
//}