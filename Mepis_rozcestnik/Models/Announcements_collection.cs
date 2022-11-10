using System.Text.Json;

namespace Mepis_rozcestnik.Models
{
    public class announcements_collection
    {
        public env env { get; set; }
        public List<announcements> collection;

        public announcements_collection(string name, env env)
        {
            this.env = env;
            collection = new List<announcements>();
        }

        public static List<announcements> get_announ_by_env(string env)
        {
            return new List<announcements>();
        }
    }

    public class announcements
    {
        public bool is_warning { get; set; }
        public string header { get; set; }
        public DateTime Date { get; set; }
        public string content { get; set; }

        public announcements(bool is_warning, string header, DateTime date, string content)
        {
            this.is_warning = is_warning;
            this.header = header;
            Date = date;
            this.content = content;
        }
    }
    
    public enum env
    {
        dev,
        prod,
        test
    }
}
