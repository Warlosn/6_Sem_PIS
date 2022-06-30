using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPhoneDictionary;

namespace PhoneDictionaryDB
{
    public class PhoneContext: DbContext
    {
        public PhoneContext() : base("Lab6PhoneDB") { }

        public DbSet<Phone> Phones { get; set; }
    }
}
