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
        public void CreateUser(User user)
        {
            userModel.CreateUser(user);
        }
    }
}
