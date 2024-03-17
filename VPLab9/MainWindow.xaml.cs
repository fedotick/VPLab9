using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
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

namespace VPLab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ToyModel> toys = new ObservableCollection<ToyModel>();

        public MainWindow()
        {
            InitializeComponent();
            toysDataGrid.ItemsSource = toys;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddToyWindow addToyWindow = new AddToyWindow();
            addToyWindow.ShowDialog();

            ToyModel newToy = addToyWindow.NewToy;
            if (newToy != null)
            {
                toys.Add(newToy);
            }

        }
    }
}
