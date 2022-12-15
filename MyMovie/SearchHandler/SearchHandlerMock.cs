using System.Net.Http;
using System.Threading.Tasks;

namespace MyMovie.SearchHandler
{
    internal class SearchHandlerMock : ISearchHandler
    {
        public SearchModel Discover(string searchString)
        {
            Parser parser = new Parser();
            string url = $"https://mymoviesearch.azurewebsites.net/?searchType=d&searchString={searchString}";

            return parser.Parse(Request(url).Result);
        }

        public SearchModel Find(string searchString)
        {
            Parser parser = new Parser();
            string url = $"https://mymoviesearch.azurewebsites.net/?searchType=f&searchString={searchString}";

            return parser.Parse(Request(url).Result);
        }

        public SearchModel Search(string searchString)
        {
            Parser parser = new Parser();
            string url = $"https://mymoviesearch.azurewebsites.net/?searchType=s&searchString={searchString}";

            return parser.Parse(Request(url).Result);
        }

        private async Task<string> Request(string url)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);

            return json;
        }
    }
}
