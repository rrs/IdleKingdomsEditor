using HexGridControl;
using IdleKingdomsEditor.Models;
using IdleKingdomsEditor.ViewModels;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace IdleKingdomsEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private void Application_Startup(object sender, StartupEventArgs _)
        {
            try
            {
                var savedRoutes = new SavedRoute[0];
                var userDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var editorDir = Path.Combine(userDir, Constants.IdleKingdomsUserFolder);
                var savedRoutesPath = Path.Combine(editorDir, Constants.SavedRoutesFileName);

                if (File.Exists(Constants.SavedRoutesFilePath))
                {
                    savedRoutes = JsonConvert.DeserializeObject<SavedRoute[]>(File.ReadAllText(Constants.SavedRoutesFilePath));
                }
                else if (File.Exists(savedRoutesPath))
                {
                    savedRoutes = JsonConvert.DeserializeObject<SavedRoute[]>(File.ReadAllText(savedRoutesPath));
                }

                var vm = new MainViewModel(savedRoutes);

                var w = new MainWindow
                {
                    DataContext = vm
                };

                w.ShowDialog();
            }
            catch(Exception e)
            {
                Logger.Error(e);
                MessageBox.Show(e.ToString());
            }
            
        }
    }
}
