namespace Tacomizer.Model
{
    public class Shell
    {
        public string recipe { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Mixin
    {
        public string recipe { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Seasoning
    {
        public string recipe { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Condiment
    {
        public string recipe { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class BaseLayer
    {
        public string recipe { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Response
    {
        public Shell shell { get; set; }
        public Mixin mixin { get; set; }
        public Seasoning seasoning { get; set; }
        public Condiment condiment { get; set; }
        public BaseLayer base_layer { get; set; }
    }
}