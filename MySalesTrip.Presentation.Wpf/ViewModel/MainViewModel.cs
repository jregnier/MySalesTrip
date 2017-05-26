using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainView
    {
        private List<ITabbedContent> _contentItems;

        public MainViewModel(IEnumerable<ITabbedContent> contentItems)
        {
            _contentItems = contentItems.OrderBy(x => x.Sequence).ToList();
        }

        public List<ITabbedContent> ContentItems
        {
            get { return _contentItems; }
            set { _contentItems = value; }
        }

        public string Name { get => "My Sales App"; } 
    }
}