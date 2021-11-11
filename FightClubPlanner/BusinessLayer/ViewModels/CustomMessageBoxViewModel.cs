namespace BusinessLayer.ViewModels
{
    public class CustomMessageBoxViewModel : BaseViewModel, ICustomMessageBoxViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetProperty<string>(ref _title, value);
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                SetProperty<string>(ref _message, value);
            }
        }

        private string _button1Text;
        public string Button1Text
        {
            get => _button1Text;
            set
            {
                _button1Text = value;
                SetProperty<string>(ref _button1Text, value);
            }
        }

        private string _button2Text;
        public string Button2Text
        {
            get => _button2Text;
            set
            {
                _button2Text = value;
                SetProperty<string>(ref _button2Text, value);
            }
        }

        private string _button3Text;
        public string Button3Text
        {
            get => _button3Text;
            set
            {
                _button3Text = value;
                SetProperty<string>(ref _button3Text, value);
            }
        }
    }
}
