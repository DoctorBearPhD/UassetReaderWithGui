using GalaSoft.MvvmLight;
using UassetLib;
using UassetReaderWithGui.Model;

namespace UassetReaderWithGui.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        ////private UassetFile _uassetFile;
        ////public  UassetFile UassetFile { get => _uassetFile; set => Set(ref _uassetFile, value); }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}