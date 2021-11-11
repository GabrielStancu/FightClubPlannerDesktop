using BusinessLayer.ViewModels;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface IIsolationBubbleAdder
    {
        Task<bool> AddBubble(IAddIsolationBubbleViewModel model);
    }
}