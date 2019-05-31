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
using System.Diagnostics;
using DispetcherModels;

namespace DispetcherZadach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowTaskManager();
        }
        public void ShowTaskManager()
        {
            Process[] processList = Process.GetProcesses();
            
                List<DispetcherClass> dispetchers = new List<DispetcherClass>();
                for(int i=0; i<processList.Count();i++)
                {
                dispetchers.Add(new DispetcherClass
                {
                    Name = processList[i].ProcessName+".exe",
                    Id = processList[i].Id,
                    Memory = processList[i].PagedSystemMemorySize,
                    Description = "Отказано в доступе",
                    Processor = "Отказано в доступе",
                    Status = "Отказано в доступе",
                         UsersName = processList[i].MachineName,
                     });
                }
            MainDataGrid.IsReadOnly = true;
            MainDataGrid.ItemsSource = dispetchers;
        }

        private void ButtonDataGrid_Click(object sender, RoutedEventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            if(MainDataGrid.SelectedItem !=null)
            {
                int index = MainDataGrid.SelectedIndex;
                try
                {
                    processes[index].Kill();
                }
                catch(Exception)
                {
                    MessageBox.Show("Отказано в доступе");
                }
            }


        }
    }
}
