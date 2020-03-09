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
using System.Windows.Shapes;

namespace Automateodessa
{
    /// <summary>
    /// Interaction logic for SiteAutomate.xaml
    /// </summary>
    public partial class SiteAutomate : Window
    {
        public bool[] checkbool;
        int flag = 0;
        public SiteAutomate()
        {
            InitializeComponent();
        }

        private void GetSitesAvailable_Click(object sender, RoutedEventArgs e)
        {
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "SiteName";
            c1.Binding = new Binding("SiteName");
            c1.Width = 110;
            SitesAvailableDataGrid.Columns.Add(c1);
            //DataGridTextColumn c2 = new DataGridTextColumn();
            //c2.Header = "IsEnabled";
            //c2.Width = 110;
            //c2.Binding = new Binding("IsEnabled");
            //SitesAvailableDataGrid.Columns.Add(c2);
            //DataGridTextColumn c3 = new DataGridTextColumn();
            //c3.Header = "StartButton";
            //c3.Width = 110;
            //c3.Binding = new Binding("StartButton");
            //SitesAvailableDataGrid.Columns.Add(c3);
            //DataGridTextColumn c4 = new DataGridTextColumn();
            //c4.Header = "StopButton";
            //c4.Width = 110;
            //c4.Binding = new Binding("StopButton");
            //SitesAvailableDataGrid.Columns.Add(c4);
            List<SitesAvailable> SitesAvailableList = new List<SitesAvailable>();
            for (int i = 0; i < 5; i++)
            {
               
                SitesAvailableDataGrid.Items.Add(new SitesAvailable() { SiteName = "asd" 
                    
                    });

            }
            checkbool = new bool[5];
            for(int i=0;i<checkbool.Length;i++)
            {
                checkbool[i] = true;
            }

            
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
          
            if (flag == 1)
            {

                Console.WriteLine("sdas");
            }
           
        }
      
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("sd");
           
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            int v = SitesAvailableDataGrid.SelectedIndex;
            
            SitesAvailable sitesAvailable = (SitesAvailable)SitesAvailableDataGrid.SelectedItem;
            checkbool[v] = false;
            StopBtn.IsEnabled = false;
            MessageBox.Show("Start clicked For " + ((SitesAvailable)SitesAvailableDataGrid.SelectedItem).SiteName.ToString());

        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stop clicked For " + ((SitesAvailable)SitesAvailableDataGrid.SelectedItem).SiteName.ToString());
        }

        private void SitesAvailableDataGrid_Selected(object sender, RoutedEventArgs e)
        {
            int v = SitesAvailableDataGrid.SelectedIndex;
            bool flag = checkbool[v];
            SitesAvailable sitesAvailable = (SitesAvailable)SitesAvailableDataGrid.SelectedItem;
            if(!flag)
            {
                StopBtn.IsEnabled = false;
            }
            else
            {
                StopBtn.IsEnabled = true;
            }
        }
    }
    public class SitesAvailable
    {
        private bool IsEnabled = true;
        public string SiteName { get; set; }
        public bool isEnabled {
            get
            {
                return IsEnabled;
            }
            set
            {
                IsEnabled = true;
            }
        }

    }
}