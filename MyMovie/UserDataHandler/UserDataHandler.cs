using Microsoft.AspNetCore.Mvc;
using MyMovie.SearchHandler;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyMovie.UserDataHandler
{
    public class UserDataHandler : IUserDataHandler
    {

        public List<ItemModel> topList = new List<ItemModel>();

        public void ClearData(string userName)
        {
            HttpClient client = new HttpClient();
            string url = $"https://mymoviecleardata.azurewebsites.net/?searchString={userName}";
            client.BaseAddress = new System.Uri(url);
        }

        public void DropDataEntry(string userName, int itemId, string timeStamp)
        {
            HttpClient client = new HttpClient();
            string url = $"https://mymoviedropdataentry.azurewebsites.net/?user={userName}&item={itemId}&time={timeStamp}";
            client.BaseAddress = new System.Uri(url);
        }

        public void DropDataFromList(string userName, string listName, int itemId)
        {
            HttpClient client = new HttpClient();
            string url = $"https://mymoviedropdatafromlist.azurewebsites.net/?user={userName}&item={itemId}&list={listName}";
            client.BaseAddress = new System.Uri(url);
        }

        public int GetItemCountScore(string userName)
        {
            return Convert.ToInt16(_GetItemCountScore(userName).Result);
        }

        private static async Task<int> _GetItemCountScore(string userName)
        {
            HttpClient client = new HttpClient();
            string url = $"https://mymoviegeticountscore.azurewebsites.net/?user={userName}";
 
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            dynamic response = await client.GetAsync(url).ConfigureAwait(false);
 
            if (response.IsSuccessStatusCode)
            {  
                string result = response.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject(result);
            }
            
            return response;
        }

        public ItemModel GetItemData(int itemId)
        {
            return _GetItemData(itemId).Result;
        }

        private static async Task<ItemModel> _GetItemData(int itemId)
        {
            HttpClient client = new HttpClient();
            string url = $"https://mymoviegetitemdata.azurewebsites.net/?id={itemId}";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            dynamic response = await client.GetAsync(url).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<ItemModel>(result);
            }

            return response;

        }

        public TopModel GetItemRating(string category, int n)
        {
            return _GetItemRating(category, n).Result;
        }

        private static async Task<TopModel> _GetItemRating(string category, int n)
        {
            HttpClient client = new HttpClient();
            string url = $"https://mymoviegetitemrating.azurewebsites.net/?category={category}&range={n}";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            dynamic response = await client.GetAsync(url).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<TopModel>(result);
            }

            return response;
        }

        public ArrayList GetListData(string userName)
        {
            return _GetListData(userName).Result;
        }

        private static async Task<ArrayList> _GetListData(string userName)
        {
            ArrayList list = new ArrayList();
            HttpClient client = new HttpClient();
            string url = $"https://mymoviesearch.azurewebsites.net/?user={userName}";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            dynamic response = await client.GetAsync(url).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<TopModel>(result);
            }

            foreach (dynamic listName in response) { list.Add(listName); }

            return list;
        }

        public void PutData(string userName, string listName, int itemId, string comment)
        {
            HttpClient client = new HttpClient();
            string url = $"https://mymoviesearch.azurewebsites.net/?user={userName}&list={listName}&id={itemId}&comment={comment}";
            client.BaseAddress = new System.Uri(url);
        }

    }

}
