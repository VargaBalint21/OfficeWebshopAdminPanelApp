using OfficeWebshopAdminPanelApp.Models;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using System.Windows;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.Input;
using OfficeWebshopAdminPanelApp.Views;

namespace OfficeWebshopAdminPanelApp.ViewModels
{
    public class ProductEditViewModel : INotifyPropertyChanged
    {
        public ProductModel SelectedProduct { get; }

        public ICommand SaveProductCommand { get; }

        public ICommand DeleteProductCommand { get; }

        public ProductEditViewModel(ProductModel product)
        {
            SelectedProduct = product;
            SaveProductCommand = new RelayCommand(SaveProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
        }

        private async void SaveProduct()
        {
            // Implement the logic to save the product and post the changes to the database
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync($"http://localhost:8000/api/products/{SelectedProduct.Id}", SelectedProduct);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Product updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update the product.");
                }
            }
        }

        private async void DeleteProduct()
        {
            var confirmDelete = MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButton.YesNo);
            if (confirmDelete == MessageBoxResult.Yes)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"http://localhost:8000/api/products/{SelectedProduct.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Product deleted successfully!");

                        // Close the ProductEditWindow (the correct window)
                        var productEditWindow = Application.Current.Windows.OfType<ProductEditWindow>().FirstOrDefault();
                        productEditWindow?.Close();

                        // Trigger a reload of the products list in MainWindow (ProductViewModel)
                        var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                        if (mainWindow != null)
                        {
                            var productViewModel = (ProductViewModel)mainWindow.DataContext;
                            await productViewModel.ReloadProductsAsync();  // Refresh products list
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the product.");
                    }
                }
            }
        }


        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
