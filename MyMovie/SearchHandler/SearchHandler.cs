namespace MyMovie.SearchHandler
{
    public class SearchHandler : ISearchHandler
    {
        /*
         * Target:
         * https://github.com/OZoneSQT/SEP6_MyMovie_Func/blob/search_main/MyMovieSearch/SearchMovieAPI.cs
         */

        /**
         * Discover method generates an search url of type "discover", and send it with the method Request()
         * @returns SearchModel
         */
        public SearchModel Discover(string searchString)
        {
            Parser parser= new Parser();
            string url = $"https://mymoviesearch.azurewebsites.net/?searchType=d&searchString={searchString}";
            return parser.Parse(Request(url).Result);
        }

        /**
         * Find method generates an search url of type "find", and send it with the method Request()
         * @returns Parsed result in a SearchModel
         */
        public SearchModel Find(string searchString)
        {
            Parser parser = new Parser();
            string url = $"https://mymoviesearch.azurewebsites.net/?searchType=f&searchString={searchString}";
            return parser.Parse(Request(url).Result);
        }

        /**
         * Search method generates an search url, and send it with the method Request()
         * @returns Parsed result in a SearchModel
         */
        public SearchModel Search(string searchString)
        {
            Parser parser = new Parser();
            string url = $"https://mymoviesearch.azurewebsites.net/?searchType=s&searchString={searchString}";
            return parser.Parse(Request(url).Result);
        }

        /**
         * Request method sends a request to client function
         * @returns Task contaning a json object with result
         */
        private async Task<string> Request(string url)
        {
            HttpClient client = new();
            var json = await client.GetStringAsync(url);

            return json;
        }

    }
}
