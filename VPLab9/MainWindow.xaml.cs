using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
        string filePath = "";
        ObservableCollection<ToyModel> toys = new ObservableCollection<ToyModel>();

        public MainWindow()
        {
            InitializeComponent();
            toysDataGrid.ItemsSource = toys;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    filePath = openFileDialog.FileName;

                    var lines = System.IO.File.ReadAllLines(filePath);

                    if (toys.Count() > 0)
                    {
                        toys.Clear();
                    }
                    foreach (var line in lines)
                    {
                        var values = line.Split('|');

                        if (values.Length == 5)
                        {
                            ToyModel toy = new ToyModel
                            {
                                Name = values[0],
                                ManufacturerCountry = values[1],
                                TypeOfToy = values[2],
                                Price = int.Parse(values[3]),
                                ImagePath = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + values[4]
                            };
                            
                            toys.Add(toy);
                        }
                    }

                    menuItemSave.IsEnabled = true;
                    menuItemSaveAs.IsEnabled = true;
                    menuItemCreateChart.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var toy in toys)
                    {
                        sw.WriteLine($"{toy.Name}|{toy.ManufacturerCountry}|{toy.TypeOfToy}|{toy.Price.ToString()}|{System.IO.Path.GetFileName(toy.ImagePath)}");
                    }
                }

                MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string newFilePath = saveFileDialog.FileName;

                    using (StreamWriter sw = new StreamWriter(newFilePath))
                    {
                        foreach (var toy in toys)
                        {
                            sw.WriteLine($"{toy.Name}|{toy.ManufacturerCountry}|{toy.TypeOfToy}|{toy.Price.ToString()}|{System.IO.Path.GetFileName(toy.ImagePath)}");
                        }
                    }

                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddToyWindow addToyWindow = new AddToyWindow();
            addToyWindow.ShowDialog();

            ToyModel newToy = addToyWindow.NewToy;
            if (newToy != null)
            {
                toys.Add(newToy);

                menuItemSave.IsEnabled = true;
                menuItemSaveAs.IsEnabled = true;
                menuItemCreateChart.IsEnabled = true;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ToyModel toy = toysDataGrid.SelectedItem as ToyModel;

            if (toy != null)
            {
                int index = toys.IndexOf(toy);

                if (index != -1)
                {
                    AddToyWindow addToyWindow = new AddToyWindow(toy);
                    addToyWindow.ShowDialog();

                    toys[index] = addToyWindow.NewToy;
                }
            }
        }

        private void CreateChart_Click(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow(toys);
            chartWindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (toysDataGrid.SelectedItem != null)
                {
                    var selectedRow = toysDataGrid.SelectedItem as ToyModel;
                    toys.Remove(selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
