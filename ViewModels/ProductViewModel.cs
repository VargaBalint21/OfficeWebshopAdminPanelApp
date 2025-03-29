using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using OfficeWebshopAdminPanelApp.Models;
using OfficeWebshopAdminPanelApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OfficeWebshopAdminPanelApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private ObservableCollection<ProductModel> _products;
        public ObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectProductCommand { get; }

        private readonly HttpClient _httpClient;

        public ProductViewModel()
        {
            _httpClient = new HttpClient();
            _products = new ObservableCollection<ProductModel>();
            SelectProductCommand = new RelayCommand<ProductModel>(SelectProduct);
        }

        private void SelectProduct(ProductModel product)
        {
            // Navigate to the product editing page
            var productEditWindow = new ProductEditWindow(product);
            productEditWindow.Show();
        }

        public async Task LoadProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://127.0.0.1:8000/api/products"); // Adjust API URL as needed
                var products = JsonConvert.DeserializeObject<List<ProductModel>>(response);
                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show($"Error fetching products: {ex.Message}");
            }
        }
    }

}
