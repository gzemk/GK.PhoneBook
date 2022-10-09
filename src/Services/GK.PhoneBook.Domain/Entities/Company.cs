using GK.PhoneBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Domain.Entities
{
    public class Company :  BaseEntity
    {
        public string Name { get; set; }    
        public int EmployeeCount { get; set; }  // No of Employees 
    }
}
