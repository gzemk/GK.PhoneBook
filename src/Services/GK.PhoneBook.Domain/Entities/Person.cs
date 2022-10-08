using GK.PhoneBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.PhoneBook.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
