using OfficeWebshopAdminPanelApp.ViewModels;
using System.Windows;

namespace OfficeWebshopAdminPanelApp.Views
{
    public partial class ProductAddWindow : Window
    {
        public ProductAddWindow()
        {
            InitializeComponent();

            // Create an instance of ProductAddViewModel without passing any arguments
            var productAddViewModel = new ProductAddViewModel();

            // Set the DataContext of the window to the ViewModel
            this.DataContext = productAddViewModel;
        }
    }
}
