using BusinessLayer.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        CustomMessageBoxViewModel _model;
        public CustomMessageBoxResult Result;
        public CustomMessageBox(string title, string message, string btn1Text, string btn2Text, string btn3Text, bool allButtons)
        {
            InitializeComponent();
            _model = new CustomMessageBoxViewModel()
            {
                Title = title,
                Message = message,
                Button1Text = btn1Text,
                Button2Text = btn2Text,
                Button3Text = btn3Text
            };
            
            if(!allButtons)
            {
                Btn1.Visibility = Visibility.Hidden;
                Btn3.Visibility = Visibility.Hidden;
            }

            DataContext = _model;
        }

        private void OnHeaderGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnBtn1Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.FirstOption;
            Close();
        }

        private void OnBtn2Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.SecondOption;
            Close();
        }

        private void OnBtn3Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.CancelOption;
            Close();
        }
    }
}
