using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAutoLogin
{
    class GlobalSettings
    {
        public static List<string> EmailAddress = new List<string>(){"http://mail.163.com/"
                                                                    ,"http://mail.126.com/"
                                                                    ,"https://mail.qq.com/"};

        public static List<string> EmailAddressTypeStr = new List<string>()
        {
            "163邮箱",
            "126邮箱",
            "qq邮箱"
        };

        public  const string JsonDir = "./settings/";
        public const string JsonFileName = "info.json";
    }
}
