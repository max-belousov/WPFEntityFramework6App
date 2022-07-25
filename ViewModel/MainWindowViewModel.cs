using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFEntityFramework6App.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        private Customer _selectedCustomer;
        private ObservableCollection<Customer> _customers;
        private MSSQLOnlineShopdbEntities _db;


        public MainWindowViewModel()
        {
            _customers = new ObservableCollection<Customer>(); //Добавление данных для тестирования
            _db = new MSSQLOnlineShopdbEntities();
            _db.Customer.Load();
            _customers = _db.Customer.Local;
        }

        public Customer SelectedCustomer
        {
            get
            {
                return this._selectedCustomer;
            }

            set
            {
                this._selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this._customers;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
