using HexGridControl;
using IdleKingdomsEditor.Models;
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
                if (File.Exists(Constants.SavedRoutesFilePath))
                {
                    savedRoutes = JsonConvert.DeserializeObject<SavedRoute[]>(File.ReadAllText(Constants.SavedRoutesFilePath));
                }
            }
            catch { }

            var vm = new MainViewModel();

            var w = new MainWindow
            {
                DataContext = vm
            };

            w.ShowDialog();
        }
    }
}
