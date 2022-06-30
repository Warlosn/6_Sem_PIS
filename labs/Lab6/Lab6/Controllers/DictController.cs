using System.Web.Mvc;
using PhoneDictionaryJson;
using System.Web;
using IPhoneDictionary;

namespace Lab6.Controllers
{
    public class DictController : Controller
    {
        private IPhoneDictionary.IPhoneDictionary phones;

        public DictController(IPhoneDictionary.IPhoneDictionary phones) {
            this.phones = phones;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.phones = phones.FindAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(string surname, string number)
        {
            Phone phone = new Phone();
            phone.Surname = surname;
            phone.Number = number;
            phones.Create(phone);
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        public ActionResult Update()
        {
            ViewBag.phones = phones.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(string surname, string number)
        {
            phones.Update(surname, number);
            return Redirect("~/Dict/Index");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            ViewBag.phones = phones.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(string surname)
        {
            phones.Delete(surname);
            return Redirect("~/Dict/Index");
        }
    }
}