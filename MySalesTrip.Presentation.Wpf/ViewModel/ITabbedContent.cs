namespace MySalesTrip.Presentation.Wpf.ViewModel
{
    /// <summary>
    /// Defines a tabbed item.
    /// </summary>
    public interface ITabbedContent
    {
        /// <summary>
        /// Gets the header of the tab.
        /// </summary>
        string Header { get; }

        /// <summary>
        /// Gets the sequence of the tab item is in.
        /// </summary>
        int Sequence { get; }
    }
}
