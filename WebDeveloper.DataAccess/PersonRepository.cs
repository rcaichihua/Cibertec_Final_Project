using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.DataAccess
{
    public class PersonRepository : BaseDataAccess<Person>
    {
        public IEnumerable<PersonModelView> GetListDto()
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Person>,List<PersonModelView>>(dbContext.Person.OrderByDescending(x => x.ModifiedDate)).Take(10);
            }
        }

        public IEnumerable<EmailAddress> EmailList(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.EmailAddress.Where(em=> em.BusinessEntityID==id).ToList();
            }
        }

        public Person GetPersonId(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Person.Where(em => em.BusinessEntityID == id).SingleOrDefault();
            }
        }

        public int UpdatePerson(Person person)
        {
            using (var dbContext = new WebContextDb())
            {
                var eCS = dbContext.Entry(person);
                eCS.State = EntityState.Modified;

                eCS.Property(x => x.rowguid).IsModified = false;
                eCS.Property(x => x.Demographics).IsModified = false;
                return dbContext.SaveChanges();
            }
        }
    }
}
