using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Models
{
    // This is the Base Abstract class that our Entities will inherit to obtain the ID field.
    // We will be using this in our Product Class.
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
    }
}
