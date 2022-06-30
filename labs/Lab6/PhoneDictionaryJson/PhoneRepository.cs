using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using IPhoneDictionary;

namespace PhoneDictionaryJson
{
   public class PhoneRepository : IPhoneDictionary.IPhoneDictionary
    {

        private List<Phone> phones;
        private string dataFilePath;    

        public PhoneRepository(string dataFilePath) {
            this.phones = new List<Phone>();
            this.dataFilePath = dataFilePath;
        }

        public Phone Create(Phone phone)
        {
            phones = FindAll();
            int lastID = phones.Count;
            phone.Id = lastID + 1;
            phones.Add(phone);
            Save();
            return phone;
        }

        public Phone Delete(string surname)
        {
            phones = FindAll();
            Phone phone = phones.Find(item => item.Surname == surname);
            phones.Remove(phone);
            Save();
            return phone;
        }

        public List<Phone> FindAll()
        {
            using (FileStream fs = new FileStream(dataFilePath, FileMode.OpenOrCreate))
            {
                this.phones = JsonSerializer.Deserialize<List<Phone>>(fs);
            }
            return this.phones;
        }

        public void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using (FileStream fs = new FileStream(dataFilePath, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                JsonSerializer.Serialize(fs, phones, options);
            }
        }

        public Phone Update(string surname, string newNumber)
        {
            phones = FindAll();
            Phone phone = phones.Find(item => item.Surname == surname);
            phone.Number = newNumber;
            Save();
            return phone;
        }
    }
}
