using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            try
            {
                imagePreview.Source = new BitmapImage(new Uri(toy.ImagePath));
            }
            catch
            {
                imagePreview.Source = null;
            }
            
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
                DateTime now = DateTime.Now;

                string imagePath = openFileDialog.FileName;
                string extension = System.IO.Path.GetExtension(imagePath);
                string projectFolderPath = AppDomain.CurrentDomain.BaseDirectory;
                string imageFolderPath = System.IO.Path.Combine(projectFolderPath, "Images");
                string newImagePath = System.IO.Path.Combine(@"Images", now.ToString("yyyyMMdd_HHmmss") + extension);

                if (!Directory.Exists(imageFolderPath))
                {
                    Directory.CreateDirectory(imageFolderPath);
                }

                try
                {
                    File.Copy(imagePath, newImagePath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}");
                }

                BitmapImage bitmap = new BitmapImage(new Uri(projectFolderPath + newImagePath));
                imagePreview.Source = bitmap;
                labelBrowse.Content = "";
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string? imagePath = null;
            
            if (imagePreview.Source != null)
            {
                imagePath = ((BitmapImage)imagePreview.Source).UriSource.LocalPath;
            }
            
            NewToy = new ToyModel
            {
                Name = textBoxName.Text,
                ManufacturerCountry = textBoxManufacturerCountry.Text,
                Price = Convert.ToDouble(textBoxPrice.Text),
                TypeOfToy = comboBoxType.Text,
                ImagePath = imagePath
            };

            Close();
        }
    }
}
