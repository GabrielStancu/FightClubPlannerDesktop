using BusinessLayer.ViewModels;

namespace BusinessLayer.Helpers
{
    public interface IFighterHealthTester
    {
        void TestFighter(IFighterMainWindowViewModel model);
    }
}