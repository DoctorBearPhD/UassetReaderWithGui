using System.IO;
using System.Windows;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel;

namespace UassetReaderWithGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
#if DEBUG
        public string executingAssembly = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public string tempFileName =
            //"old_reader_stuff\\ExtraGauge";
            //"RYU_CommandList_2020";
            "DA_Z0A_VS2";
            //"BP_CharaSelectActor";
        public string TEMP_FILEPATH => executingAssembly + "\\test_stuff\\" + tempFileName + ".uasset";
#endif

        
        /// <summary>
        /// Initializes a new instance of the MainWindow class with or without an argument passed.
        /// </summary>
        public MainWindow(string arg = "")
        {
#if DEBUG
            if (arg == "") arg = TEMP_FILEPATH;
#else
            if (arg == "") return;
#endif
            
            var vmLocator = App.Current.Resources["Locator"] as ViewModelLocator; // manually initialize the ViewModelLocator, or else it isn't loaded when we need it
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<IDataService>().SetArg(arg); // pass starting arg to the DataService so it can get the file when asked

            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}