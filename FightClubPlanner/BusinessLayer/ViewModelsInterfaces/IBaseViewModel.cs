using System.ComponentModel;

namespace BusinessLayer.ViewModels
{
    public interface IBaseViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}