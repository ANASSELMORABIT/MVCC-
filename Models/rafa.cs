namespace ProgramaRafaAnass.Models
{
    // Clases para API1
    namespace API1
    {
        public class Artist
        {
            public string _type { get; set; }
            public string api_path { get; set; }
            public string header_image_url { get; set; }
            public int? id { get; set; }
            public string image_url { get; set; }
            public string index_character { get; set; }
            public bool? is_meme_verified { get; set; }
            public bool? is_verified { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public string url { get; set; }
            public int? iq { get; set; }
        }

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
            public string cover_art_thumbnail_url { get; set; }
            public string cover_art_url { get; set; }
            public string full_title { get; set; }
            public int? id { get; set; }
            public string name { get; set; }
            public string name_with_artist { get; set; }
            public ReleaseDateComponents release_date_components { get; set; }
            public string release_date_for_display { get; set; }
            public string url { get; set; }
            public Artist artist { get; set; }
        }

        public class ReleaseDateComponents
        {
            public int? year { get; set; }
            public int? month { get; set; }
            public int? day { get; set; }
        }

        public class Root
        {
            public List<ChartItem> chart_items { get; set; }
        }
    }

    // Clases para API2
    namespace API2
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

    // Clase Trend que combina los datos de ambas APIs
    public class Trend
    {
        public API1.Root ClassUno { get; set; }
        public API2.Root ClassDos { get; set; }
    }
}
