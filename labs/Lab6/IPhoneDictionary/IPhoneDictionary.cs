using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPhoneDictionary
{
    public interface IPhoneDictionary
    {
        List<Phone> FindAll();
        Phone Create(Phone phone);
        Phone Delete(string surname);
        Phone Update(string surname, string newNumber);
        void Save();
    }
}
