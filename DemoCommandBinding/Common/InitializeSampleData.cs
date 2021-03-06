﻿using DemoCommandBinding.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCommandBinding.Common
{
    public class InitializeSampleData
    {
        public static ObservableCollection<Customer> GetData()
        {
            ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();

            Customers.Add(new Customer() { Id = 1, Name = "Allen", Sex = true, Age = 25, Vip = true });
            Customers.Add(new Customer() { Id = 2, Name = "Carter", Sex = true, Age = 26, Vip = true });
            Customers.Add(new Customer() { Id = 3, Name = "Rose", Sex = true, Age = 30, Vip = false });
            Customers.Add(new Customer() { Id = 4, Name = "Daisy", Sex = false, Age = 20, Vip = false });
            Customers.Add(new Customer() { Id = 5, Name = "Mary", Sex = false, Age = 15, Vip = true });
            Customers.Add(new Customer() { Id = 6, Name = "Ray", Sex = true, Age = 39, Vip = false });
            Customers.Add(new Customer() { Id = 7, Name = "Sherry", Sex = false, Age = 55, Vip = false });
            Customers.Add(new Customer() { Id = 8, Name = "Lisa", Sex = false, Age = 32, Vip = false });
            Customers.Add(new Customer() { Id = 9, Name = "Judy", Sex = false, Age = 19, Vip = true });
            Customers.Add(new Customer() { Id = 10, Name = "Jack", Sex = true, Age = 28, Vip = false });
            Customers.Add(new Customer() { Id = 11, Name = "May", Sex = false, Age = 20, Vip = false });
            Customers.Add(new Customer() { Id = 12, Name = "Vivian", Sex = false, Age = 32, Vip = true });

            return Customers;
        }
    }
}
