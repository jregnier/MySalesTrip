using System.Threading.Tasks;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    /// <summary>
    /// Indicates that the view model needs to load data.
    /// </summary>
    public interface ILoadData
    {
        /// <summary>
        /// Loads data for the view model.
        /// </summary>
        /// <returns></returns>
        Task LoadData();
    }
}
