using OfficeWebshopAdminPanelApp.ViewModels;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;

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

    }
}
