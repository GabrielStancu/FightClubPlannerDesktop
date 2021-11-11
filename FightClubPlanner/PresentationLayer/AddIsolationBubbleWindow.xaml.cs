using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AddIsolationBubbleWindow.xaml
    /// </summary>
    public partial class AddIsolationBubbleWindow : Window
    {
        IAddIsolationBubbleViewModel _model;
        IIsolationBubbleAdder _adder;
        public AddIsolationBubbleWindow(IAddIsolationBubbleViewModel model,
            IIsolationBubbleAdder adder)
        {
            InitializeComponent();
            _model = model;
            _adder = adder;
            DataContext = _model;
        }

        private void OnHeaderGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private async void OnAddBubbleButtonClicke(object sender, RoutedEventArgs e)
        {
            bool added = await _adder.AddBubble(_model);

            if(added)
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox(string.Empty, "Isolation Bubble added!", string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
            else
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox(string.Empty, "Isolation Bubble already exists!", string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
            
            IsolationBubbleTextBox.Text = string.Empty;
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
