using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Mepis_rozcestnik.Models
{
    public class announcements_collection
    {
        public List<announcements> collection;

        public announcements_collection(List<announcements> lst)
        {
            collection = lst;
        }

        public static announcements_collection get_announ_by_env(string env)
        {
            string path = "";
            if (env == "production")
                path = "~/Annoucements_prod.json";
            else if (env == "test")
                path = "~/Annoucements_test.json";
            else
                throw new Exception();

            try
            {
                var json_content = File.ReadAllText(path);
                var res = JsonSerializer.Deserialize<List<announcements>>(json_content);
                return new announcements_collection(res);
            }
            catch (Exception e)
            {
                announcements ann = new announcements(true, "Chyba načtení oznámení", DateTime.Now, e.ToString());
                var res = new List<announcements>();
                res.Add(ann);
                return new announcements_collection(res);
            }
        }
    }

    public class announcements
    {
        public bool is_warning { get; set; }
        public string header { get; set; }
        public DateTime date { get; set; }
        public string content { get; set; }

        public announcements(bool is_warning, string header, DateTime date, string content)
        {
            this.is_warning = is_warning;
            this.header = header;
            date = date;
            this.content = content;
        }
    }
}
