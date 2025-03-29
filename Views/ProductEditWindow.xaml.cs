using OfficeWebshopAdminPanelApp.Models;
using OfficeWebshopAdminPanelApp.ViewModels;
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

namespace OfficeWebshopAdminPanelApp.Views
{
    /// <summary>
    /// Interaction logic for ProductEditWindow.xaml
    /// </summary>
    public partial class ProductEditWindow : Window
    {
        public ProductEditWindow(ProductModel product)
        {
            InitializeComponent();
            var productEditViewModel = new ProductEditViewModel(product);
            this.DataContext = productEditViewModel;
        }
    }
}
