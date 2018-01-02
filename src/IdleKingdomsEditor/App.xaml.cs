using HexGridControl;
using IdleKingdomsEditor.Models;
using IdleKingdomsEditor.ViewModels;
using Newtonsoft.Json;
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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var savedRoutes = new SavedRoute[0];
            try
            {
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
            }
            catch { }

            var vm = new MainViewModel(savedRoutes);

            var w = new MainWindow
            {
                DataContext = vm
            };

            w.ShowDialog();
        }
    }
}
