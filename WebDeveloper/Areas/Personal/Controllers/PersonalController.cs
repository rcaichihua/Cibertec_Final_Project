using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;
using WebDeveloper.Models;

namespace WebDeveloper.Areas.Personal.Controllers
{
    [Authorize]
    public class PersonalController : Controller
    {
        private readonly PersonRepository _personRepository;
        public PersonalController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ActionResult Index()
        {
            return View(_personRepository.GetListDto());
        }

        public PartialViewResult EmailList(int? id)
        {
            if(!id.HasValue) return null;
            return PartialView("_EmailList",_personRepository.EmailList(id.Value));
        }
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Create", person);

            person.ModifiedDate = DateTime.Now;
            person.rowguid = Guid.NewGuid();

            person.BusinessEntity = new BusinessEntity
            {
                rowguid = person.rowguid,
                ModifiedDate = person.ModifiedDate
            };

            _personRepository.Add(person);
            return RedirectToAction("Index");
        }

        public PartialViewResult Edit(int? id)
        {
            if (!id.HasValue) return null;
            return PartialView("_Edit", _personRepository.GetPersonId(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", person);

            person.ModifiedDate = DateTime.Now;

            Person personEdit = new Person();

            personEdit = _personRepository.GetPersonId(person.BusinessEntityID);

            person.BusinessEntity = new BusinessEntity
            {
                BusinessEntityID=personEdit.BusinessEntityID,
                rowguid = personEdit.rowguid,
                ModifiedDate = person.ModifiedDate
            };

            _personRepository.UpdatePerson(person);
            return RedirectToAction("Index");
        }
    }
}