namespace _29MoneyCalculator.Class.Interfaces
{
    internal interface IDialogService
    {
        Task<bool> DisplayConfirm(string title,string message,string accept,string decline);
    }
}
