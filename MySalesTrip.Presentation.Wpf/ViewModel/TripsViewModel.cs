using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    public class TripsViewModel : ViewModelBase, ITabbedContent
    {
        /// <inheritdoc />
        public string Header => "Trips";

        /// <inheritdoc />
        public int Sequence => 1;
    }
}
