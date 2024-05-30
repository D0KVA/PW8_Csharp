using Microsoft.Win32;
using Newtonsoft.Json;
using SerializeDeserializeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace PW8_Csharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                string textToSerialize = tbX.Text;
                string jsonFilePath = saveFileDialog.FileName;
                Json.SerializeToFile(textToSerialize, jsonFilePath);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                string jsonFilePath = openFileDialog.FileName;
                string txt = Json.DeserializeFromFile<string>(jsonFilePath);
                if (!string.IsNullOrEmpty(txt))
                {
                    tbX.Text = txt;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Theme = "zxcTheme";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            App.Theme = "NekoTheme";
        }
    }
}
