using Newtonsoft.Json;

namespace MyMovie.SearchHandler
{
    // Source format:
    // {"movie_results":[],"person_results":[],"tv_results":[],"tv_episode_results":[],"tv_season_results":[]}
    public class Parser
    {
        /**
         * Generated SearchModel from serchString
         * @ Returns a SearcModel object contaning parsed search result
         */
        public SearchModel Parse(string jsonString) 
        { 
            SearchModel searchModel = new SearchModel();

            dynamic result = JsonConvert.DeserializeObject(jsonString);

            foreach (dynamic movie_results in result) {searchModel.AddMovie(movie_results);}
            foreach (dynamic person_results in result) {searchModel.AddPerson(person_results);}
            foreach (dynamic tv_results in result) {searchModel.AddTv(tv_results);}
            foreach (dynamic tv_episode_results in result) {searchModel.AddTvEpisode(tv_episode_results);}
            foreach (dynamic tv_season_results in result) {searchModel.AddTvSeason(tv_season_results);}

            return searchModel;
        }

    }
}
