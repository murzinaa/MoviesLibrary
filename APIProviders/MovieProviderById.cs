using MoviesLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIProviders
{
    public class MovieProviderById : IAPIMovieProvider
    {
        public List<string> GetMovieList(string url)
        {
            List<string> ResultsArray = new List<string> { };
            using (WebClient client = new WebClient())
            {

                string json = client.DownloadString(url);

                MovieResultById filmInfo = JsonConvert.DeserializeObject<MovieResultById>(json);
                MovieResultById rslt = new MovieResultById();

                
                    rslt.id = filmInfo.id;
                    rslt.original_language = filmInfo.original_language;
                    rslt.overview = filmInfo.overview;
                    rslt.popularity = filmInfo.popularity;
                    rslt.release_date = filmInfo.release_date;
                    rslt.title = filmInfo.title;
                    rslt.vote_average = filmInfo.vote_average;
                    rslt.vote_count = filmInfo.vote_count;
                    rslt.backdrop_path = filmInfo.poster_path ?? "No picture";
                    ResultsArray.Add(rslt.title);
                    if (rslt.backdrop_path == "No picture")
                    {
                        ResultsArray.Add("https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png");
                    }
                    else
                    {
                        ResultsArray.Add("https://image.tmdb.org/t/p/original" + rslt.backdrop_path);
                    }

                    ResultsArray.Add(rslt.original_language);
                    ResultsArray.Add(rslt.overview);
                    ResultsArray.Add(rslt.popularity);
                    ResultsArray.Add(rslt.release_date);
                    ResultsArray.Add(rslt.vote_average);
                    ResultsArray.Add(rslt.vote_count);




            }
            return ResultsArray;

        }

    }
}