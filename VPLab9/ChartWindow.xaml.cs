using LiveCharts.Wpf;
using LiveCharts;
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
using System.Collections.ObjectModel;

namespace VPLab9
{
    /// <summary>
    /// Логика взаимодействия для ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        public ObservableCollection<ToyModel> toys { get; set; }

        public ChartWindow(ObservableCollection<ToyModel> toys)
        {
            InitializeComponent();
            int kids = toys.Count(p => p.TypeOfToy == "For toddlers");
            int male = toys.Count(p => p.TypeOfToy == "For boys");
            int female = toys.Count(p => p.TypeOfToy == "For girls");

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Kids",
                    Values = new ChartValues<int> { kids }
                },
                new ColumnSeries
                {
                    Title = "Male",
                    Values = new ChartValues<int> { male }
                },
                new ColumnSeries
                {
                    Title = "Female",
                    Values = new ChartValues<int> { female }
                }
            };

            Labels = new[] { "Kids", "Male", "Female" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
