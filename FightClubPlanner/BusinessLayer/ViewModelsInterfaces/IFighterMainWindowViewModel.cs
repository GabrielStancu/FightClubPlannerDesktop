using DataLayer.Models;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public interface IFighterMainWindowViewModel
    {
        Fighter Fighter { get; set; }
        ObservableCollection<Fight> Fights { get; set; }
        ObservableCollection<Invite> Invites { get; set; }
        IsolationBubble IsolationBubble { get; set; }
        ObservableCollection<IsolationBubble> IsolationBubbles { get; set; }
        bool IsPositive { get; set; }
        bool RegisterTestEnable { get; set; }
        bool SelfTestEnable { get; set; }
        Invite SelectedInvite { get; set; }
        ObservableCollection<CovidTest> Tests { get; set; }
        ObservableCollection<Tournament> Tournaments { get; set; }
    }
}