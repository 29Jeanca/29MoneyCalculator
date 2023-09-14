using _29MoneyCalculator.Class.Interfaces;

namespace _29MoneyCalculator.Class
{
    internal class DialogService : IDialogService
    {
        public  Task<bool> DisplayConfirm(string title, string message, string accept, string decline)
        {
            return  Application.Current.MainPage.DisplayAlert(title, message, accept, decline);
        }   
    }
}
