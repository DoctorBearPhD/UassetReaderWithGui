using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace UassetReaderWithGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string[] Args;

        public void StartWithArgs(object sender, StartupEventArgs e)
        {
            Args = e.Args;

            MainWindow main;

            if (Args.Length == 0)
            {
                main = new MainWindow();
                main.Show();
                return;
            }

            if (Args.Length > 1)
                throw new ArgumentException("Too many arguments! Maximum of one argument (the file name) is allowed.");

            if (!File.Exists(Args[0])) throw new FileNotFoundException($"Args provided: {Args}");


            main = new MainWindow(Args[0]);
            main.Show();
        }

    }

    public static class PackagedProgram
    {
        [STAThread]
        public static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
            App.Main();
        }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyName = new AssemblyName(args.Name);

            var path = assemblyName.Name + ".dll";
            if (assemblyName.CultureInfo.Equals(System.Globalization.CultureInfo.InvariantCulture) == false)
            {
                path = $@"{assemblyName.CultureInfo}\{path}";
            }

            using (var s = executingAssembly.GetManifestResourceStream(path))
            {
                if (s == null) return null;

                var assRawBytes = new byte[s.Length];
                s.Read(assRawBytes, 0, assRawBytes.Length);
                return Assembly.Load(assRawBytes);
            }
        }
    }
}
