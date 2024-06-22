using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsBook
{
    public static class UserSession
    {
        public static string UserID { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string Role { get; set; }
        public static bool Isadmin { get; set; }
        public static bool isexit { get; set; }
        // 其他需要保存的信息
    }

}
