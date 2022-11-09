namespace Mepis_rozcestnik.Models
{
    public class determine_url
    {
        public static string determine(string env, string usr, string platf)
        {
            var env_url = "";
            var user_url = "";
            var platform_url = "";
            var res = "";

            // prostředí
            if (env == "production") {
                env_url = "https://emepis.cz";
            }
            else if (env == "test") {
                env_url = "https://dev.emepis.cz";
            }

            // uživatel
            if (usr == "tescosw")
            {
                user_url = "authConfigName=ADFS";
            }
            else if (usr == "uzsvm")
            {
                if (platf == "integ")
                {
                    user_url = "authConfigName=MEPIS_IP_DEV";
                }
                else
                {
                    user_url = "authConfigName=ADFS_MEPIS";
                }
            }

            // platforma
            if (platf == "MEPIS portál")
            {
                platform_url = "/portal";
            }
            else if (platf == "Integrační platforma")
            {
                platform_url = "/ip";
            }
            else if (platf == "Reporty")
            {
                platform_url = "/reports";
            }

            if (env == "test" && usr == "tescosw" && platf == "MEPIS portál")
            {
                res = "https://mepistest.mepis.loc/api/v02/as/auth/login?clientName=MW_LOC&authConfigName=ADFS";
            }
            else if (env == "test" && usr == "tescosw" && platf == "Integrační platforma")
            {
                res = "https://ip.mepis.loc/ip/api/v02/as/auth/login?clientName=MW&authConfigName=MEPIS_IP_DEV";
            }
            else
            {
                res = env_url + platform_url + "/api/v02/as/auth/login?clientName=MW&" + user_url;
            }

            return res;
        }
    }
}
