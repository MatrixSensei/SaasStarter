using Saas.Models;
using Saas.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantResources.Models
{
    // The Product class will inherit from BaseEntity Class and implement the IMustHaveTenant interface,
    // which in turn adds the TenantId property to the class. This follows a simple DDD pattern for creating
    // the class where all the properties of the Entity have a private setter and have a constructor that
    // can create objects by accepting the name, description, and rate properties.
    public class Product : BaseEntity, IMustHaveTenant
    {
        public Product(string name, string description, int rate)
        {
            Name = name;
            Description = description;
            Rate = rate;
        }
        protected Product()
        {
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Rate { get; private set; }
        public string TenantId { get; set; }
    }
}
