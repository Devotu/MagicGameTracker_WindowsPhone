using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;

namespace MagicGameTracker.View
{
    public partial class ExportView : UserControl
    {
        public ExportView()
        {
            InitializeComponent();
        }

        private void bExportData_Click(object sender, RoutedEventArgs e)
        {
            writeFile();

            MessageBox.Show("Data export initated");
        }

        private async void writeFile()
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Magic Game Tracker SQLite", new List<string>() { ".mgt" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "ExportedDB";

            string OutputText = "error";

            savePicker.PickSaveFileAndContinue();

            
        }
    }
}
