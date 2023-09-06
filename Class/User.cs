using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _29MoneyCalculator.Clases
{
    public class User
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_last_name { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public char User_Gender { get; set; }
        public DateTime User_Birth { get; set; }
    }
}
