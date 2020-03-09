using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System;


namespace Automateodessa
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            DataContext = new DbDirectoryItemSource();
        }


        private void CmbDirectory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            List<string> DbFilesList = new List<string>();
            string DirectorySelected = CmbDirectory.SelectedItem.ToString();
            if (DirectorySelected != null)
            {
                foreach (string i in Directory.GetFiles(DirectorySelected))
                {
                    DbFilesList.Add(Path.GetFileName(i));
                }
                CmbDatabasefile.ItemsSource = DbFilesList;
            }
            else
            {
                CmbDatabasefile.ItemsSource = "Please choose the Directory Path";
            }
        }
        public static async Task CopyFileAsync(string sourceFile, string destinationFile)
        {
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4092, FileOptions.Asynchronous | FileOptions.SequentialScan))
            using (var destinationStream = new FileStream(destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4092, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await sourceStream.CopyToAsync(destinationStream);
        }
        public void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            string SelectedDbFile = CmbDirectory.SelectedItem.ToString() + @"/" + CmbDatabasefile.SelectedItem.ToString();
            CopyFileAsync(SelectedDbFile, @"D:\Driivers.iso");
            Output_Window.Text = ConfigurationManager.AppSettings["Username"];
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
      
    }

    public class DbDirectoryItemSource
    {
        public List<string> CmbContent { get; set; }

        public DbDirectoryItemSource()
        {
            CmbContent = new List<string>();
            foreach(var i in Directory.GetDirectories(@"E:/"))
            {
               CmbContent.Add(i);
            }
        }
    }
  
}
