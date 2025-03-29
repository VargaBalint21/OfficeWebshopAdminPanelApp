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
using Newtonsoft.Json;

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
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var requestContent = JsonConvert.SerializeObject(SelectedProduct);
                    Console.WriteLine("Request Content: " + requestContent); // Log request content

                    var response = await httpClient.PutAsJsonAsync($"http://localhost:8000/api/products/{SelectedProduct.Id}", SelectedProduct);

                    var responseContent = await response.Content.ReadAsStringAsync(); // Log response content
                    Console.WriteLine("Response: " + responseContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Product updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update the product. Error: {response.StatusCode}\nDetails: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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
