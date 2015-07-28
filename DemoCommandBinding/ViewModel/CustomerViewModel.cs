using DemoCommandBinding.Command;
using DemoCommandBinding.Common;
using DemoCommandBinding.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCommandBinding.ViewModel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        #region Fields and Properties

        // This property will be bound to GridView's ItemsDataSource property for providing data
        private ObservableCollection<Customer> customers;

        // This property will be bound to button's Command property for deleting item
        public IDelegateCommand DeleteCommand { protected set; get; }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                if (customers != value)
                {
                    customers = value;
                    OnPropertyChanged("Customers");
                }
            }
        }

        #endregion

        #region Constructor
        public CustomerViewModel()
        {
            // create a DeleteCommand instance
            this.DeleteCommand = new DelegateCommand(ExecuteDeleteCommand);

            // Get data source
            Customers = InitializeSampleData.GetData();
        }
        #endregion


        #region Execute and CanExecute methods

        void ExecuteDeleteCommand(object param)
        {
            int id = (Int32)param;
            Customer cus = GetCustomerById(id);
            if (cus != null)
            {
                Customers.Remove(cus);
            }
        }

        #endregion

        // Get the deleting item by Id property
        private Customer GetCustomerById(int id)
        {
            return Customers.First(x => x.Id == id);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
