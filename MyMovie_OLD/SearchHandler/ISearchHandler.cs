namespace MyMovie.SearchHandler
{
    public interface ISearchHandler
    {
        /**
         * Returns result of a default search
         * 
         * /search -   Text based search is the most common way. You provide a query string and we provide the closest match. 
         *             Searching by text takes into account all original, translated, alternative names and titles.
         *             Documentation: https://www.themoviedb.org/documentation/api
         *             
         * @returns SearchModel
         */
        SearchModel Search(string searchString);

        /**
         * Returns result of a search of type "discover"
         * 
         * /discover - Sometimes it useful to search for movies and TV shows based on filters or definable values like ratings, certifications or release dates. 
         *             The discover method make this easy. For some example queries, and to get an idea about the things you can do with discover, take a look here.
         *             Documentation: https://www.themoviedb.org/documentation/api
         *             
         * @returns SearchModel
         */
        SearchModel Discover(string searchString);

        /**
         * Returns result of a search of type "find" 
         * 
         * OBS: Use it to searh/get info from saved lists
         * 
         * /find -     The last but still very useful way to find data is with existing external IDs. 
         *             For example, if you know the IMDB ID of a movie, TV show or person, you can plug that value into this method and we'll return anything that matches. 
         *             This can be very useful when you have an existing tool and are adding our service to the mix.
         *             Documentation: https://www.themoviedb.org/documentation/api
         *
         * @returns SearchModel
         */
        SearchModel Find(string searchString);

    }
}
