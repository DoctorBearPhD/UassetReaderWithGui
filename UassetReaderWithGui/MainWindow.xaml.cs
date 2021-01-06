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
            "DA_KEN_Setup";
        public string TEMP_FILEPATH => executingAssembly + "/test_stuff/" + tempFileName + ".uasset";
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
            // Pass the starting arg to the data service.
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<IDataService>().SetArg(arg);

            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}