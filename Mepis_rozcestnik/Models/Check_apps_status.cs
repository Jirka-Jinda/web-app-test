using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http;

namespace Mepis_rozcestnik.Models
{
    public class Check_apps_status
    {
        public static async Task<bool> check_status(string url)
        {
            HttpClient client = new HttpClient();
            var res = client.GetAsync(url);
            var httpResponseMessage = await res;
            var status = (int)httpResponseMessage.StatusCode;
            if (status >= 200 && status < 300) // 200-299 - SUCCES
            {
                return true;
            }
            else if (status >= 300 && status < 400) // 300-399 - REDIRECT
            {
                return true;
            }
            else if (status >= 400 && status < 500) // 400-499 - CLIENT ERROR
            {
                return false;
            }
            else if (status >= 300 && status < 600) // 500-599 - SERVER ERROR
            {
                return false;
            }
            else
                return true;
        }
    }
}
