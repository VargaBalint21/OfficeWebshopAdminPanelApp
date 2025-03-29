using OfficeWebshopAdminPanelApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.Input;

namespace OfficeWebshopAdminPanelApp.ViewModels
{
    public class ProductEditViewModel : INotifyPropertyChanged
    {
        public ProductModel SelectedProduct { get; }

        public ICommand SaveProductCommand { get; }

        public ProductEditViewModel(ProductModel product)
        {
            SelectedProduct = product;
            SaveProductCommand = new RelayCommand(SaveProduct);
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

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
