using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace VPLab9
{
    /// <summary>
    /// Логика взаимодействия для AddToyWindow.xaml
    /// </summary>
    public partial class AddToyWindow : Window
    {
        public ToyModel NewToy { get; private set; }

        public AddToyWindow()
        {
            InitializeComponent();

            this.Title += "Add";
        }

        public AddToyWindow(ToyModel toy)
        {
            InitializeComponent();

            this.Title += "Edit";
            btnAdd.Content = "Edit";

            FillingFields(toy);
        }

        private void FillingFields (ToyModel toy)
        {
            textBoxName.Text = toy.Name;
            textBoxManufacturerCountry.Text = toy.ManufacturerCountry;
            textBoxPrice.Text = toy.Price.ToString();
            comboBoxType.Text = toy.TypeOfToy;
            imagePreview.Source = new BitmapImage(new Uri(toy.ImagePath));
            
            if (imagePreview.Source != null)
            {
                labelBrowse.Content = "";
            }
        }

        private void LabelBrowse_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                imagePreview.Source = bitmap;
                labelBrowse.Content = "";
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NewToy = new ToyModel
            {
                Name = textBoxName.Text,
                ManufacturerCountry = textBoxManufacturerCountry.Text,
                Price = Convert.ToDouble(textBoxPrice.Text),
                TypeOfToy = comboBoxType.Text,
                ImagePath = ((BitmapImage)imagePreview.Source).UriSource.LocalPath
            };

            Close();
        }
    }
}
