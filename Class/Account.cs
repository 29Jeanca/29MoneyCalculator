using _29_Money_Calculator.BD;

namespace _29MoneyCalculator.Class
{
    public class Account
    {
        public int Id { get; set; }
        public string TitleAccount { get; set; }
        public string DescriptionAccount { get; set; }
        public decimal Earnings { get; set; }
        public decimal Taxes { get; set; }
        public decimal Bills { get; set; }
        public decimal Leisure { get; set; }
        public int User_ID { get; set; }


    }
}
