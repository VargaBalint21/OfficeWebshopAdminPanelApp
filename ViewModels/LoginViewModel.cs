using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OfficeWebshopAdminPanelApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeWebshopAdminPanelApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string statusMessage;

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            if (await _authService.LoginAsync(Email, Password))
            {
                StatusMessage = "Login successful!";
                // Navigate to Dashboard
            }
            else
            {
                StatusMessage = "Login failed!";
            }
        }
    }
}
