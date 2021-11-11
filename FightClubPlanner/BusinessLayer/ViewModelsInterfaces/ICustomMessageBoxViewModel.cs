namespace BusinessLayer.ViewModels
{
    public interface ICustomMessageBoxViewModel
    {
        string Button1Text { get; set; }
        string Button2Text { get; set; }
        string Button3Text { get; set; }
        string Message { get; set; }
        string Title { get; set; }
    }
}