using DataLayer.Models;

namespace BusinessLayer.ViewModels
{
    public interface ILoginViewModel
    {
        User User { get; set; }
        string Username { get; set; }
    }
}