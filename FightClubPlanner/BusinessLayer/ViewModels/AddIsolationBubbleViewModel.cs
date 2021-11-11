using BusinessLayer.ViewModels;

namespace BusinessLayer.ViewModels
{
    public class AddIsolationBubbleViewModel : BaseViewModel, IAddIsolationBubbleViewModel
    {
        private string _bubbleName;
        public string BubbleName
        {
            get => _bubbleName;
            set
            {
                _bubbleName = value;
                SetProperty<string>(ref _bubbleName, value);
            }
        }
    }
}
