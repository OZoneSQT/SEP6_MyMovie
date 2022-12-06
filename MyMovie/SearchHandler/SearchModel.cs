using System.Collections;

namespace MyMovie.SearchHandler
{
    public class SearchModel
    {
        /**
         * OBS!!! Check for null values
         */
        public ArrayList movieList { get; private set; }
        public ArrayList personList { get; private set; }
        public ArrayList tvList { get; private set; }
        public ArrayList tvEpisodeList { get; private set; }
        public ArrayList tvSeasonList { get; private set; }

        /**
         * Add movie to list
         */
        public void AddMovie(string movie)
        {
            if (movieList == null) movieList = new ArrayList();
            movieList.Add(movie);
        }

        /**
         * Is movie list empty
         * @returns true false if movieList is empty
         */
        public bool HasMovie()
        {
            return movieList != null;
        }

        /**
         * Add person to list
         */
        public void AddPerson(string person)
        {
            if (personList == null) personList = new ArrayList();
            personList.Add(person);
        }

        /**
         * Is person list empty
         * @returns true false if personList is empty
         */
        public bool HasPerson()
        {
            return personList != null;
        }

        /**
         * Add tv info to list
         */
        public void AddTv(string tv)
        {
            if (tvList == null) tvList = new ArrayList();
            tvList.Add(tv);
        }

        /**
         * Is tv info list empty
         * @returns true false if tvList is empty
         */
        public bool HasTv()
        {
            return tvList != null;
        }

        /**
         * Add Tv Episode to list
         */
        public void AddTvEpisode(string tvEpisode)
        {
            if (tvEpisodeList == null) tvEpisodeList = new ArrayList();
            tvEpisodeList.Add(tvEpisode);
        }

        /**
         * Is Tv Episode list empty
         * @returns true false if tvEpisodeList is empty
         */
        public bool HasTvEpisode()
        {
            return tvEpisodeList != null;
        }

        /**
         * Add Tv Season to list
         */
        public void AddTvSeason(string tvSeason)
        {
            if (tvSeasonList == null) tvSeasonList = new ArrayList();
            tvSeasonList.Add(tvSeason);
        }

        /**
         * Is Season list empty
         * @returns true false if tvSeasonList is empty
         */
        public bool HasTvSeason()
        {
            return tvSeasonList != null;
        }

    }
}
