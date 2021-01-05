using System.IO;
using System.Windows;
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
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        /// <summary>
        /// Initializes a new instance of the MainWindow class with an argument passed.
        /// </summary>
        public MainWindow(string arg = "")
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

#if DEBUG
            if (arg == "") arg = TEMP_FILEPATH;
#else
            if (arg == "") return;
#endif

            BinaryReader br = new BinaryReader(File.OpenRead(arg));

            var file = new UassetLib.UassetFile();
            file.ReadUasset(ref br);
        }
    }
}