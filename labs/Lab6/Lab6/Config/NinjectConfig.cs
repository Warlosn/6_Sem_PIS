using Ninject.Modules;
using PhoneDictionaryJson;
using IPhoneDictionary;
using PhoneDictionaryDB;
using Ninject.Web.Common;


namespace Lab6.Config
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            //Bind<IPhoneDictionary.IPhoneDictionary>().To<PhoneDictionaryJson.PhoneRepository>().WithConstructorArgument("dataFilePath", "D:\\GitHub\\6_Sem_PIS\\labs\\Lab6\\Lab6\\App_Data\\data.json");

            Bind<IPhoneDictionary.IPhoneDictionary>().To<PhoneDictionaryDB.PhoneRepository>().InRequestScope().WithConstructorArgument("context", new PhoneContext());
        }//intransient(требование),insingleton,inthread
    }
}