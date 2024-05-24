using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProgramaRafaAnass.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;

namespace ProgramaRafaAnass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;
        private readonly List<string> _apiKeys;
        private int _currentApiKeyIndex;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _apiKeys = new List<string>
            {
                "9ce3e0d0cemshe5b623685000db5p106ad0jsn78d14e93951f",
                "755213d2a9msh15d63b61b852333p1d9b45jsna1578db8f43d",
                "23bcf06223msh3f4a1150d932ad5p140ca9jsn13e76faeba7e",
                "eac4b11431msh26e2911a0d3f2e0p197eacjsn1db62c7aca2a",
                "12c6f161d2mshf0a4c0f032cedccp1eba3ajsn9e9699c4aa07",
                "6d4487a0a3msh95737a1d82a84f3p1643dcjsn44d14c382acf",
                "ebc89c49a6msh887cbbd6a0c6fa0p10bd7fjsn9bf91c21f390"
            };
            _currentApiKeyIndex = 0;
            SetApiKeyHeader();
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "genius-song-lyrics1.p.rapidapi.com");
        }

        private void SetApiKeyHeader()
        {
            _client.DefaultRequestHeaders.Remove("X-RapidAPI-Key");
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKeys[_currentApiKeyIndex]);
        }

        private void MoveToNextApiKey()
        {
            _currentApiKeyIndex = (_currentApiKeyIndex + 1) % _apiKeys.Count;
            SetApiKeyHeader();
        }

        public async Task<IActionResult> Index()
        {
            ProgramaRafaAnass.Models.APISongs.Root  chartData = null!;


            Random random = new Random();

        
            string[] periods = { "day", "week", "month" };

        
            string period = periods[random.Next(periods.Length)];

            var requestUri = new Uri($"https://genius-song-lyrics1.p.rapidapi.com/chart/songs/?time_period={period}&per_page=20&page=1");

            HttpResponseMessage response = null!;
            while (response == null || !response.IsSuccessStatusCode)
            {
                try
                {
                    response = await _client.GetAsync(requestUri);
                    if (!response.IsSuccessStatusCode)
                    {
                        MoveToNextApiKey();
                    }
                }
                catch (HttpRequestException)
                {
                    MoveToNextApiKey();
                }
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            chartData = JsonConvert.DeserializeObject<ProgramaRafaAnass.Models.APISongs.Root >(responseBody)!;

            return View(chartData);
        }

        [HttpGet]
        public async Task<IActionResult> FetchSongUrl(string nameWithArtist)
        {
            string urlSong = string.Empty;
            var encodedNameWithArtist = Uri.EscapeDataString($"{nameWithArtist}official lyrics");

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "e8868d5af6msh9c028f705d0bb2fp18150bjsn16101430214b");
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "youtube-v2.p.rapidapi.com");

            var youtubeSearchUri = new Uri($"https://youtube-v2.p.rapidapi.com/search/?query={encodedNameWithArtist}&lang=en&order_by=this_month&country=us");

            HttpResponseMessage youtubeSearchResponse = null!;
            while (youtubeSearchResponse == null || !youtubeSearchResponse.IsSuccessStatusCode)
            {
                try
                {
                    youtubeSearchResponse = await _client.GetAsync(youtubeSearchUri);
                    if (!youtubeSearchResponse.IsSuccessStatusCode)
                    {
                        MoveToNextApiKey();
                    }
                }
                catch (HttpRequestException)
                {
                    MoveToNextApiKey();
                }
            }

            var youtubeSearchBody = await youtubeSearchResponse.Content.ReadAsStringAsync();
            var ytSearchObject = JsonConvert.DeserializeObject<ProgramaRafaAnass.Models.APISearch.Root>(youtubeSearchBody);

            if (ytSearchObject?.videos != null && ytSearchObject.videos.Count > 0)
            {
                string videoId = ytSearchObject.videos[0].video_id;
                await Task.Delay(1100);

                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "e8868d5af6msh9c028f705d0bb2fp18150bjsn16101430214b");
                _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "youtube-media-downloader.p.rapidapi.com");

                var youtubeDownloadUri = new Uri($"https://youtube-media-downloader.p.rapidapi.com/v2/video/details?videoId={videoId}");
                
                HttpResponseMessage youtubeDownloadResponse = null!;
                while (youtubeDownloadResponse == null || !youtubeDownloadResponse.IsSuccessStatusCode)
                {
                    try
                    {
                        youtubeDownloadResponse = await _client.GetAsync(youtubeDownloadUri);
                        if (!youtubeDownloadResponse.IsSuccessStatusCode)
                        {
                            MoveToNextApiKey();
                        }
                    }
                    catch (HttpRequestException)
                    {
                        MoveToNextApiKey();
                    }
                }

                var youtubeDownloadBody = await youtubeDownloadResponse.Content.ReadAsStringAsync();
                var ytDownloadObject = JsonConvert.DeserializeObject<ProgramaRafaAnass.Models.APIDownload.Root>(youtubeDownloadBody);

                if (ytDownloadObject != null && ytDownloadObject.audios != null && ytDownloadObject.audios.items.Count > 0)
                {
                    urlSong = ytDownloadObject.audios.items[0].url;
                }
            }

            return Json(new { success = true, url = urlSong });
        }

        public async Task<IActionResult> Privacy()
        {
            ProgramaRafaAnass.Models.APIArtists.Root chartData1 = null!;
            var requestUri = new Uri("https://genius-song-lyrics1.p.rapidapi.com/chart/artists/?per_page=30&page=1");

            HttpResponseMessage response = null!;
            while (response == null || !response.IsSuccessStatusCode)
            {
                try
                {
                    response = await _client.GetAsync(requestUri);
                    if (!response.IsSuccessStatusCode)
                    {
                        MoveToNextApiKey();
                    }
                }
                catch (HttpRequestException)
                {
                    MoveToNextApiKey();
                }
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            chartData1 = JsonConvert.DeserializeObject<ProgramaRafaAnass.Models.APIArtists.Root>(responseBody)!;

            return View(chartData1);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetLyrics()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetLyrics(string artist, string songTitle)
        {
            if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(songTitle))
            {
                ModelState.AddModelError("", "Please provide both artist and song title.");
                return View();
            }

            ProgramaRafaAnass.Models.APILyrics.Root lyricsResult = null!;

            try
            {
                var requestUri = new Uri($"https://api.lyrics.ovh/v1/{artist}/{songTitle}");
                var response = await _client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                lyricsResult = JsonConvert.DeserializeObject<ProgramaRafaAnass.Models.APILyrics.Root>(responseBody)!;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "An error occurred while fetching data from the API.");
            }
            catch (JsonSerializationException e)
            {
                _logger.LogError(e, "An error occurred while deserializing the JSON response.");
            }

            return View("ResultadoLyrics", lyricsResult);
        }
    }
}
