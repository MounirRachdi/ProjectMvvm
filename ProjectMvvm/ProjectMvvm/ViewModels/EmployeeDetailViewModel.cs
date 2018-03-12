using ProjectMvvm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMvvm.ViewModels
{
    public class EmployeeDetailViewModel :  BaseViewModel
    {
        public Employee employee { get; set; }
        public EmployeeDetailViewModel(Employee emp)
        {
            employee = emp;
        }
    }
}
