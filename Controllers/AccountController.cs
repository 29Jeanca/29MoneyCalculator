using _29MoneyCalculator.Class;
using _29MoneyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29MoneyCalculator.Controllers
{
    public class AccountController
    {
        private AccountModel accountModel;

        public AccountController()
        {
            accountModel = new AccountModel();
        }
        public void AddAccount(int user_id, Account account)
        {
            accountModel.AddAccount(user_id, account);
        }
    }
}
