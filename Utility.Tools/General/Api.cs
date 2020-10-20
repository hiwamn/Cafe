using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Tools.General
{
    public class Api
    {

        public static string PostRequest(string JSON, string Func, byte[] File, string Token)
        {
            string result = "";
            Task myTask = Task.Run(() => result = PostAsync(JSON, Func, File, Token).Result);
            myTask.Wait();
            return result;
        }
        private static async Task<string> PostAsync(string JSON, string function, byte[] File, string Token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 10);
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var uri = new Uri(function);

                    using (var formData = new MultipartFormDataContent())
                    {
                        formData.Add(new StringContent(JSON, Encoding.UTF8, "application/json"));
                        if (File != null)
                            formData.Add(new StringContent(Convert.ToBase64String(File)), "File");
                        HttpResponseMessage response = await client.PostAsync(uri, new StringContent(JSON, Encoding.UTF8, "application/json"));

                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        else
                            return response.StatusCode.ToString();
                    }
                }

            }
            catch (Exception e2)
            {

                return Agent.ToJson(new { NikoErrorText = e2.ToString() });
            }

        }
        public static string GetRequest(string Func)
        {
            string result = "";
            Task myTask = Task.Run(() => result = GetAsync(Func).Result);
            myTask.Wait(); 
            Task myTask1 = Task.Run(() => result = GetAsync(Func).Result);
            myTask1.Wait();
            return result;
        }
        private static async Task<string> GetAsync(string function)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 10);
                    httpClient.DefaultRequestHeaders.ExpectContinue = false;

                    var uri = new Uri(function);


                    HttpResponseMessage response = await httpClient.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                        return response.StatusCode.ToString();

                }

            }
            catch (Exception e2)
            {

                return Agent.ToJson(new { NikoErrorText = e2.ToString() });
            }

        }

    }


}


