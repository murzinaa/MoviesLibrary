﻿using APIProviders.MovResultById;
using MoviesLibrary.Models;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIProviders
{
    public class MovieProvider : IAPIMovieProvider
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public MovieProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public MovieProvider()
        {
        }

        //public MovieProvider()
        //{
        //}

        public async Task<MovieResultById> GetMoviesListById(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<MovieResultById>(content);
            //List<string> ResultsArray = new List<string> { };
              //MovieResultById rslt = new MovieResultById();


                //rslt.Id = filmInfo.Id;
                //rslt.Title = filmInfo.Title;
                //ResultsArray.Add(rslt.Title);
                //ResultsArray.Add(rslt.Id);
            //}
            return model;
        }

        public async Task<MovieResult> GetMovieList(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<MovieResult>(content);
            //List<string> ResultsArray = new List<string> { };
            //using (WebClient client = new WebClient())
            //{

            //    string json = client.DownloadString(url);

            //    MovieResult filmInfo = JsonConvert.DeserializeObject<MovieResult>(json);
            //    MovieModel rslt = new MovieModel();

            //    for (int i = 0; i < filmInfo.results.Count; i++)
            //    {
            //        rslt.id = Convert.ToString(filmInfo.results[i].id);
            //        rslt.title = filmInfo.results[i].title;


            //        ResultsArray.Add(rslt.title);
            //        ResultsArray.Add(rslt.id);
            //    }

            //}
            return model;
           

        }

        //public List<string> GetMovieListById(string url)
        //{
        //    List<string> ResultsArray = new List<string> { };
        //    using (WebClient client = new WebClient())
        //    {

        //        string json = client.DownloadString(url);

        //        MovieResultById filmInfo = JsonConvert.DeserializeObject<MovieResultById>(json);
        //        MovieResultById rslt = new MovieResultById();


        //        rslt.Id = filmInfo.Id;
        //        rslt.Original_Language = filmInfo.Original_Language;
        //        rslt.Overview = filmInfo.Overview;
        //        rslt.Popularity = filmInfo.Popularity;
        //        rslt.Release_Date = filmInfo.Release_Date;
        //        rslt.Title = filmInfo.Title;
        //        rslt.Vote_Average = filmInfo.Vote_Average;
        //        rslt.Vote_Count = filmInfo.Vote_Count;
        //        rslt.Poster_Path = filmInfo.Poster_Path ?? "No picture";
        //        rslt.Id = Convert.ToString(filmInfo.Id);
        //        ResultsArray.Add(rslt.Title);
        //        if (rslt.Poster_Path == "No picture")
        //        {
        //            ResultsArray.Add("https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png");
        //        }
        //        else
        //        {
        //            ResultsArray.Add("https://image.tmdb.org/t/p/original" + rslt.Poster_Path);
        //        }

        //        ResultsArray.Add(rslt.Original_Language);
        //        ResultsArray.Add(rslt.Overview);
        //        ResultsArray.Add(rslt.Popularity);
        //        ResultsArray.Add(rslt.Release_Date);
        //        ResultsArray.Add(rslt.Vote_Average);
        //        ResultsArray.Add(rslt.Vote_Count);
        //        ResultsArray.Add(rslt.Id);




        //    }
        //    return ResultsArray;
        //}
    }
}
