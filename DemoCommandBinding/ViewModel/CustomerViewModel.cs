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
        private ObservableCollection<Customer> customers1;

        // This property will be bound to button's Command property for deleting item
        public IDelegateCommand DeleteCommand { protected set; get; }

        public ObservableCollection<Customer> Customers1
        {
            get
            {
                return customers1;
            }
            set
            {
                if (customers1 != value)
                {
                    customers1 = value;
                    OnPropertyChanged("Customers1");
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
            Customers1 = InitializeSampleData.GetData();
            Customers2 = InitializeSampleData.GetData();
        }



        #endregion


        #region Execute and CanExecute methods

        void ExecuteDeleteCommand(object param)
        {
            int id = (Int32)param;
            Customer cus = GetCustomerById(id);
            if (cus != null)
            {
                Customers1.Remove(cus);
            }
        }

        #endregion

        // Get the deleting item by Id property
        private Customer GetCustomerById(int id)
        {
            return Customers1.First(x => x.Id == id);
        }

        private ObservableCollection<Customer> customers2;
        public ObservableCollection<Customer> Customers2
        {
            get
            {
                return customers2;
            }
            set
            {
                if (customers2 != value)
                {
                    customers2 = value;
                    OnPropertyChanged("Customers2");
                }
            }
        }

        private DelegateCommand _customCommand;
        public DelegateCommand CustomCommand
        {
            get
            {
                if (_customCommand == null)
                    _customCommand = new DelegateCommand(ExecuteProductTapped);

                return _customCommand;
            }
        }

        private void ExecuteProductTapped(object param)
        {
            Customers2.Remove(param as Customer);
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
