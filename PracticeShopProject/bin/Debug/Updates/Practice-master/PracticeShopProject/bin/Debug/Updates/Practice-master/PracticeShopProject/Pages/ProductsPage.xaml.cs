using PracticeShopProject.Model;
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
using PracticeShopProject.Entities;
using System.Reflection;
using PracticeShopProject.Classes;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using PracticeShopProject.Windows;

namespace PracticeShopProject.Pages
{
    public partial class ProductsPage : Page
    {
        WebClient client = new WebClient();
        public ProductsPage()
        {
            InitializeComponent();
            productList = DB.entities.Product.ToList();
            ListViewProducts.ItemsSource = productList;
        }
        List<Product> productList = new List<Product>();

        string CurrentVersionApp = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string VersionApp = client.DownloadString("https://raw.githubusercontent.com/NeGaPuPe/Practice/master/PracticeShopProject/Resources/Version/VersionApp.txt").Replace("\n", "");
            if (CurrentVersionApp.Contains(VersionApp))
            {
                MessageBox.Show("Версия актуальна."); 
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Версия вашего приложения устарела, хотите обновить его?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    InstallWindow installWindow = new InstallWindow();
                    installWindow.Show();
                }
            }
        }
    }
}