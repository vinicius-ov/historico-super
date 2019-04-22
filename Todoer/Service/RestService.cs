﻿//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;
//using System.Threading.Tasks;
//using Todoer.Model;
//using Newtonsoft.Json;
//using System.Net.Http;
//using System.Net.Http.Headers;

//namespace Todoer
//{
//    public class RestService : IRestService
//    {
//        private readonly HttpClient client;

//        public List<Product> Items { get; private set; }

//        public RestService()
//        {
//            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
//            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

//            client = new HttpClient
//            {
//                MaxResponseContentBufferSize = 256000
//            };
//            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
//        }

//        public async Task<List<Product>> RefreshDataAsync()
//        {
//            Items = new List<Product>();

//            // RestUrl = http://developer.xamarin.com:8081/api/todoitems
//            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

//            try
//            {
//                var response = await client.GetAsync(uri);
//                if (response.IsSuccessStatusCode)
//                {
//                    var content = await response.Content.ReadAsStringAsync();
//                    Items = JsonConvert.DeserializeObject<List<Product>>(content);
//                }
//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine(@"             ERROR {0}", ex.Message);
//            }

//            return Items;
//        }

//        public async Task SaveTodoItemAsync(Product item, bool isNewItem = false)
//        {
//            // RestUrl = http://developer.xamarin.com:8081/api/todoitems
//            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

//            try
//            {
//                var json = JsonConvert.SerializeObject(item);
//                var content = new StringContent(json, Encoding.UTF8, "application/json");

//                HttpResponseMessage response = null;
//                if (isNewItem)
//                {
//                    response = await client.PostAsync(uri, content);
//                }
//                else
//                {
//                    response = await client.PutAsync(uri, content);
//                }

//                if (response.IsSuccessStatusCode)
//                {
//                    Debug.WriteLine(@"             TodoItem successfully saved.");
//                }

//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine(@"             ERROR {0}", ex.Message);
//            }
//        }

//        public async Task DeleteTodoItemAsync(string id)
//        {
//            // RestUrl = http://developer.xamarin.com:8081/api/todoitems/{0}
//            var uri = new Uri(string.Format(Constants.RestUrl, id));

//            try
//            {
//                var response = await client.DeleteAsync(uri);

//                if (response.IsSuccessStatusCode)
//                {
//                    Debug.WriteLine(@"             TodoItem successfully deleted.");
//                }

//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine(@"             ERROR {0}", ex.Message);
//            }
//        }

//    }
//}
