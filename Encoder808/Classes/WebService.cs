using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Encoder808.Classes
{
    public class WebService
    {
        private static string baseUrl = "https://civil808.com/desktop";
        private static string contentType = "application/json";
        public static UserLogin login(string username_email, string password)
        {
            try
            {
                var url = baseUrl + "/user/login2";
                var request = (HttpWebRequest)WebRequest.Create(url);

                var model = new
                {
                    hash = "50e185c2e0c2bc30215338db776022c92ecbc441fd933688c6bf4f274c863c60",
                    username_email,
                    password,
                    source = "desktop",
                    version = "1"
                };

                var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(model));

                request.Method = "POST";
                request.ContentType = contentType;
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    if (responseString.Contains("username or password"))
                        throw new Exception("نام کاربری یا رمز عبور اشتباه است");
                    throw new Exception(responseString);
                }
                else
                {
                    return JsonConvert.DeserializeObject<UserLogin>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ورود به برنامه", ex);
            }
        }

        public static bool encrypted_film(EncryptedFilm encryptedFilm, string cookie, string token)
        {
            try
            {
                var url = baseUrl + "/encrypted_film";
                url = "http://localhost:3900" + "/ManageSession/encrypted_film";
                var request = (HttpWebRequest)WebRequest.Create(url);

                var model = new
                {
                    hash = "50ae6fb9675dd999fa93af9d23ac619bf2ccb23af3047824cef6a84d5b41faa1",
                    source = "desktop",
                    version = "1",
                    encryptedFilm.nid,
                    encryptedFilm.password,
                    encryptedFilm.title,
                    encryptedFilm.new_name,
                    encryptedFilm.new_extension,
                    encryptedFilm.name,
                    encryptedFilm.extension,
                };

                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

                request.Method = "POST";
                request.ContentType = contentType;
                request.ContentLength = data.Length;
                request.Headers.Add("Cookie:" + cookie);
                request.Headers.Add("X-CSRF-Token:" + token);

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(responseString);
                else
                    return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("400")) //HttpStatusCode.BadRequest
                    ex = new Exception("اطلاعات ارسالی به سرور ناقص/اشتباه می باشد");
                else if(ex.Message.Contains("409")) //HttpStatusCode.Conflict
                    ex = new Exception(HttpStatusCode.Conflict.ToString());

                throw new Exception("خطا در ارسال اطلاعات به سرور", ex);
            }
        }

        public static void logout(string cookie, string token)
        {
            try
            {
                var url = baseUrl + "/user/logout";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = contentType;
                request.Headers.Add("Cookie:" + cookie);
                request.Headers.Add("X-CSRF-Token:" + token);
                request.Method = "POST";
                request.ContentLength = 0;

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(responseString);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خروج از برنامه", ex);
            }
        }

    }
}


