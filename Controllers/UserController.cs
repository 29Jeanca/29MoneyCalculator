using _29MoneyCalculator.Clases;
using _29MoneyCalculator.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _29MoneyCalculator.Controladores
{
    public class UserController
    {
        private UserModel userModel;

        public UserController()
        {
            userModel = new UserModel();
        }
        public bool CreateUser(User user)
        {
           return userModel.CreateUser(user);
        }
        public bool ValidateUser(string email, string password)
        {
            return userModel.ValidateUser(email, password);
        }
        public (int, string) UserInformation(string email)
        {
            return userModel.UserInformation(email);
        }
    }
}
