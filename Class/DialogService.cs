using _29MoneyCalculator.Class.Interfaces;

namespace _29MoneyCalculator.Class
{
    internal class DialogService : IDialogService
    {
        public async Task<bool> DisplayConfirm(string title, string message, string accept, string decline)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, decline);
        }   
    }
}
