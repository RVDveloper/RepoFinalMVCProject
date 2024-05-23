namespace ProgramaRafaAnass.Models
{
    namespace APIDownload{
        public class Audios
            {
                public bool status { get; set; }
                public string errorId { get; set; }
                public int expiration { get; set; }
                public List<Item> items { get; set; }
            }

            public class Avatar
            {
                public string url { get; set; }
                public int width { get; set; }
                public int height { get; set; }
            }

            public class Channel
            {
                public string type { get; set; }
                public string id { get; set; }
                public string name { get; set; }
                public bool isVerified { get; set; }
                public bool isVerifiedArtist { get; set; }
                public List<Avatar> avatar { get; set; }
            }

            public class Item
            {
                public string url { get; set; }
                public int lengthMs { get; set; }
                public string mimeType { get; set; }
                public string extension { get; set; }
                public object lastModified { get; set; }
                public int size { get; set; }
                public string sizeText { get; set; }
                public bool hasAudio { get; set; }
                public string quality { get; set; }
                public int width { get; set; }
                public int height { get; set; }
                public string type { get; set; }
                public string id { get; set; }
                public string title { get; set; }
                public Channel channel { get; set; }
                public bool isLiveNow { get; set; }
                public string lengthText { get; set; }
                public string viewCountText { get; set; }
                public string publishedTimeText { get; set; }
                public List<Thumbnail> thumbnails { get; set; }
            }

            public class Related
            {
                public string nextToken { get; set; }
                public List<Item> items { get; set; }
            }

            public class Root
            {
                public bool status { get; set; }
                public string errorId { get; set; }
                public string type { get; set; }
                public string id { get; set; }
                public string title { get; set; }
                public string description { get; set; }
                public Channel channel { get; set; }
                public int lengthSeconds { get; set; }
                public int viewCount { get; set; }
                public int likeCount { get; set; }
                public string publishedTimeText { get; set; }
                public bool isLiveStream { get; set; }
                public bool isLiveNow { get; set; }
                public bool isRegionRestricted { get; set; }
                public string commentCountText { get; set; }
                public List<Thumbnail> thumbnails { get; set; }
                public Videos videos { get; set; }
                public Audios audios { get; set; }
                public Subtitles subtitles { get; set; }
                public Related related { get; set; }
            }

            public class Subtitles
            {
                public bool status { get; set; }
                public string errorId { get; set; }
                public List<object> items { get; set; }
            }

            public class Thumbnail
            {
                public string url { get; set; }
                public int width { get; set; }
                public int height { get; set; }
                public bool moving { get; set; }
            }

            public class Videos
            {
                public bool status { get; set; }
                public string errorId { get; set; }
                public int expiration { get; set; }
                public List<Item> items { get; set; }
            }

    }

    namespace APISearch{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            public class Root
            {
                public int number_of_videos { get; set; }
                public string query { get; set; }
                public string country { get; set; }
                public string lang { get; set; }
                public string timezone { get; set; }
                public string continuation_token { get; set; }
                public List<Video> videos { get; set; }
            }

            public class Thumbnail
            {
                public string url { get; set; }
                public int width { get; set; }
                public int height { get; set; }
            }

            public class Video
            {
                public string video_id { get; set; }
                public string title { get; set; }
                public string author { get; set; }
                public int number_of_views { get; set; }
                public string video_length { get; set; }
                public string description { get; set; }
                public object is_live_content { get; set; }
                public string published_time { get; set; }
                public string channel_id { get; set; }
                public object category { get; set; }
                public string type { get; set; }
                public List<object> keywords { get; set; }
                public List<Thumbnail> thumbnails { get; set; }
            }

    }


   




    

        // Clases para APIArtists
        namespace APIArtists
        {
            public class ChartItem
            {
                public string _type { get; set; }
                public string type { get; set; }
                public Item item { get; set; }
            }

            public class Item
            {
                public string _type { get; set; }
                public string api_path { get; set; }
                public string header_image_url { get; set; }
                public int id { get; set; }
                public string image_url { get; set; }
                public string index_character { get; set; }
                public bool is_meme_verified { get; set; }
                public bool is_verified { get; set; }
                public string name { get; set; }
                public string slug { get; set; }
                public string url { get; set; }
                public int iq { get; set; }
            }

            public class Root
            {
                public List<ChartItem> chart_items { get; set; }
            }
        }


 namespace APISongs{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ChartItem3
    {
        public string _type { get; set; }
        public string type { get; set; }
        public Item3 item { get; set; }
    }

    public class FeaturedArtist
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string index_character { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public int iq { get; set; }
    }

    public class Item3
    {
        public string _type { get; set; }
        public int annotation_count { get; set; }
        public string api_path { get; set; }
        public string artist_names { get; set; }
        public string full_title { get; set; }
        public string header_image_thumbnail_url { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public bool instrumental { get; set; }
        public int lyrics_owner_id { get; set; }
        public string lyrics_state { get; set; }
        public int lyrics_updated_at { get; set; }
        public string path { get; set; }
        public int? pyongs_count { get; set; }
        public string relationships_index_url { get; set; }
        public ReleaseDateComponents release_date_components { get; set; }
        public string release_date_for_display { get; set; }
        public string release_date_with_abbreviated_month_for_display { get; set; }
        public string song_art_image_thumbnail_url { get; set; }
        public string song_art_image_url { get; set; }
        public Stats stats { get; set; }
        public string title { get; set; }
        public string title_with_featured { get; set; }
        public int updated_by_human_at { get; set; }
        public string url { get; set; }
        public List<FeaturedArtist> featured_artists { get; set; }
        public PrimaryArtist primary_artist { get; set; }
    }

    public class PrimaryArtist
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string index_character { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public int iq { get; set; }
    }

    public class ReleaseDateComponents
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }

    public class Root
    {
        public List<ChartItem3> chart_items { get; set; }
        public int next_page { get; set; }
    }

    public class Stats
    {
        public int unreviewed_annotations { get; set; }
        public int concurrents { get; set; }
        public bool hot { get; set; }
        public int pageviews { get; set; }
    }

  }
    namespace APILyrics{
        public class Root
        {
            public string lyrics { get; set; }
        }


    }
        // Clase Trend que combina los datos de ambas APIs
        public class Trend
        {
            public APIArtists.Root ClassDos { get; set; }

            public APIDownload.Root ClassYTSearch{ get; set;}

            public APISearch.Root ClassYTDownload{get; set;}

            public APISongs.Root ClassTres{get; set;}

            public APILyrics.Root ClassLyrics { get; set; }
        }
    }
