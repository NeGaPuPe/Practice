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
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Net.Http;

namespace PracticeShopProject.Pages
{
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            productList = DB.entities.Product.ToList();
            ListViewProducts.ItemsSource = productList;
            SearchTextBox.TextChanged += Sorting;
            AscendingSortButton.Checked += Sorting;
            DescendingSortButton.Checked += Sorting;
        }
        List<Product> productList = new List<Product>();

        public void Sorting(object sender, EventArgs e)
        {
            var product = DB.entities.Product.ToList();

            if (SearchTextBox.Text != "")
            {
                product = product.Where(x => x.Name.ToString().ToLower().Contains(SearchTextBox.Text.ToLower()) || x.Price.ToString().ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            if (AscendingSortButton.IsChecked == true)
            {
                product = product.OrderBy(x => x.Price).ToList();
            }

            if (DescendingSortButton.IsChecked == true)
            {
                product = product.OrderByDescending(x => x.Price).ToList();
            }
            ListViewProducts.ItemsSource = product;
        }
    }
}