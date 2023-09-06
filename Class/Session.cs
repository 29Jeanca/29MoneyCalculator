using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29MoneyCalculator.Class
{
    public static class Session
    {
        public static int User_ID{get;set;}
        public static string User_Name{get;set;}
    
        public static void Login(int user_id, string user_name)
        {
            User_ID = user_id;
            User_Name = user_name;
        } 
    
    
    }
}
