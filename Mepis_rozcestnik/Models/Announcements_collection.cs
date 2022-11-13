using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Mepis_rozcestnik.Models
{
    public class announcements_collection
    {
        public static List<announcements> get_announ_by_env(string env)
        {
            string path = "";
            if (env == "production")
                path = "./Announcements_prod.json";
            else if (env == "test")
                path = "./Annoucements_test.json";
            else
                throw new Exception();

            try
            {
                var json_content = File.ReadAllText(path);
                var res = JsonSerializer.Deserialize<List<announcements>>(json_content);
                return res;

                //var an1 = new announcements(false, "test", DateTime.Now, "content");
                //var an2 = new announcements(true, "test2", DateTime.Now, "content2");
                //var rs = new List<announcements>();
                //rs.Add(an1);
                //rs.Add(an2);

                //var temp = JsonSerializer.Serialize(rs);
                //File.WriteAllText(path, temp);
                //Console.WriteLine(temp);
                //return rs;
            }
            catch (Exception e)
            {
                announcements ann = new announcements(true, "Chyba načtení oznámení", DateTime.Now, e.ToString());
                var res = new List<announcements>();
                res.Add(ann);
                return res;
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
            this.date = date;
            this.content = content;
        }
    }
}
