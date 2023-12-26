using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using PracticeShopProject.Pages;

namespace PracticeShopProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ProductsPage());
        }

        string CurrentVersionApp = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string VersionApp = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            VersionAppTextBlock.Text = "Version: " + CurrentVersionApp;
        }
    }
}
