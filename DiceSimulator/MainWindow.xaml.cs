using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.IO;

namespace DiceSimulator
{
    public partial class MainWindow : Window
    {
        public string CharacterFilePath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadCharacterButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileBrowserAndSetFilePath();
            // ChangeLoadFileButtonColorToDefault();
            // ChangeControlButtonsToGreen();
        }

        public void OpenFileBrowserAndSetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SetFilePathOfTextFile(openFileDialog);
            }
        }

        public void SetFilePathOfTextFile(OpenFileDialog openFileDialog)
        {
            this.CharacterFilePath = openFileDialog.FileName;
        }

        public void SetCharacterStatsFromFile(string filePath)
        {
            int linesInTextFile = File.ReadLines(filePath).Count();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    // create instance of character class and populate fields
                }
            }
        }
    }
}
