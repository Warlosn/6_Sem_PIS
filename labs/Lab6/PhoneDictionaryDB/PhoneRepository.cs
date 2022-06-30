using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPhoneDictionary;

namespace PhoneDictionaryDB
{
    public class PhoneRepository : IPhoneDictionary.IPhoneDictionary
    {
        private PhoneContext context;
        DbSet<Phone> phones;

        public PhoneRepository(PhoneContext context) {
            this.context = context;
            phones = context.Set<Phone>();
        }


        public Phone Create(Phone phone)
        {
            phones.Add(phone);
            Save();
            return phone;
        }

        public Phone Delete(string surname)
        {
            Phone phone = phones.FirstOrDefault(p => p.Surname.Equals(surname));
            phones.Remove(phone);
            Save();
            return phone;
        }

        public List<Phone> FindAll()
        {
            return phones.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Phone Update(string surname, string newNumber)
        {
            Phone phone = phones.FirstOrDefault(p => p.Surname == surname);
            if (phone != null)
            {
                phone.Number = newNumber;
                context.Entry(phone).State = EntityState.Modified;
                Save();
            }
            return phone;
        }
    }
}
