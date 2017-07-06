using GalaSoft.MvvmLight;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainView
    {
        private readonly List<ITabbedContent> _contentItems;
        private readonly ISnackbarMessageQueue _messageQueue;
        private bool _isFlyoutOpen;
        private ITabbedContent _selectedContent;

        public MainViewModel(
            IEnumerable<ITabbedContent> contentItems,
            ISnackbarMessageQueue messageQueue)
        {
            _contentItems = contentItems.OrderBy(x => x.Sequence).ToList();
            _messageQueue = messageQueue;
        }

        public List<ITabbedContent> ContentItems
        {
            get { return _contentItems; }
        }

        public bool IsFlyoutOpen
        {
            get { return _isFlyoutOpen; }
            set
            {
                if (value == _isFlyoutOpen)
                {
                    return;
                }

                _isFlyoutOpen = value;
                RaisePropertyChanged(() => IsFlyoutOpen);
            }
        }

        public ISnackbarMessageQueue MessageQueue
        {
            get { return _messageQueue; }
        }

        public string Name { get => "My Sales App"; }

        public ITabbedContent SelectedContent
        {
            get { return _selectedContent; }
            set
            {
                if (value == _selectedContent)
                {
                    return;
                }

                _selectedContent = value;
                RaisePropertyChanged(() => SelectedContent);

                if (_selectedContent != null)
                {
                    _messageQueue.Enqueue($"Manage {_selectedContent.Header}");
                    IsFlyoutOpen = false;
                }
            }
        }
    }
}