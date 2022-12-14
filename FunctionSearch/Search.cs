using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace FunctionSearch
{
    public class Search
    {
        HttpRequest req;

        /**
         * Function to handle a search to via an external api, returns a JSON file as a string
         * Parsing is handled by reciving method
         * 
         * @return string
         */
        public string Run(string searchType, string searchString)
        {

            /**
             * Set Search method, using TMDB. - Documentation: https://www.themoviedb.org/documentation/api
             *
             * /search -   Text based search is the most common way. You provide a query string and we provide the closest match. 
             *             Searching by text takes into account all original, translated, alternative names and titles.
             * /discover - Sometimes it useful to search for movies and TV shows based on filters or definable values like ratings, certifications or release dates. 
             *             The discover method make this easy. For some example queries, and to get an idea about the things you can do with discover, take a look here.
             * /find -     The last but still very useful way to find data is with existing external IDs. 
             *             For example, if you know the IMDB ID of a movie, TV show or person, you can plug that value into this method and we'll return anything that matches. 
             *             This can be very useful when you have an existing tool and are adding our service to the mix.
             */
            if (searchType == "d" || searchType == "discover")
                searchType = "discover";
            else if (searchType == "f" || searchType == "find")
                searchType = "find";
            else
                searchType = "search";

            /**
             * Build search string
             */
            string apiKey = "TMDB_KEY"; // TMDB API KEY, ignore error it is updated by GitHub Actions on deploy, from stored secret
            string searchQuery = $"https://api.themoviedb.org/3/{searchType}/{searchString}?api_key={apiKey}&language=en-US&external_source=imdb_id";

            /**
             * Send search query to external movie database api
             */
            string result = req.Query[searchQuery];

            /**
             * Return search result
             */
            return result;

        }

    }
}
