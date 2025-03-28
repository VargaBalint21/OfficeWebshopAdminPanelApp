using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OfficeWebshopAdminPanelApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Event that notifies the UI of property changes
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called to notify the UI that a property has changed
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}