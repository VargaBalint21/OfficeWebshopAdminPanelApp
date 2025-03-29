using OfficeWebshopAdminPanelApp.Models;
using OfficeWebshopAdminPanelApp.ViewModels;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace OfficeWebshopAdminPanelApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var productViewModel = new ProductViewModel();
            this.DataContext = productViewModel;

            // Load products asynchronously
            productViewModel.LoadProductsAsync();
        }

        private void OnProductDoubleClick(object sender, RoutedEventArgs e)
        {
            if (sender is ListViewItem item && item.DataContext is ProductModel product)
            {
                var productViewModel = (ProductViewModel)this.DataContext;
                productViewModel.SelectProductCommand.Execute(product);
            }
        }

    }
}
