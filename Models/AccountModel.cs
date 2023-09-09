using _29_Money_Calculator.BD;
using _29MoneyCalculator.Class;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29MoneyCalculator.Models
{
    public class AccountModel
    {
        private ConxDB conxDB;

        public AccountModel()
        {
            conxDB = new ConxDB();
        }

        public List<Account> GetAccounts(int user_id)
        {
            List<Account> accounts = new List<Account>();
            NpgsqlConnection connection = conxDB.Connect();
            string query = "SELECT title_account,description_account,earnings,taxes,bills,leisure FROM accounts WHERE user_id=@user_id";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@user_id", user_id);
            NpgsqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
               Account account = new()
                {
                    TitleAccount = reader.GetString(0),
                    DescriptionAccount = reader.GetString(1),
                    Earnings = reader.GetDecimal(2),
                    Taxes = reader.GetDecimal(3),
                    Bills = reader.GetDecimal(4),
                    Leisure = reader.GetDecimal(5),
                };
                accounts.Add(account);
            }
            conxDB.Disconnect();
            return accounts;
        }
    }
}
