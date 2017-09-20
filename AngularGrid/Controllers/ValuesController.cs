using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularGrid.Models;

namespace AngularGrid.Controllers
{
    public class ValuesController : ApiController
    {
        AEPEntities _entities = null;
        public ValuesController()
        {
            _entities = new AEPEntities();
        }

        // GET api/values
        public object Get()
        {
            return _entities.Lessons.ToList();
        }

        // GET api/values/5
        public object Get(int id)
        {
            return _entities.Lessons.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/values
        public void Post(Lesson model)
        {
            _entities.Lessons.Add(model);
            _entities.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, Lesson model)
        {
            Lesson ExistingLession = _entities.Lessons.Where(x => x.Id == id).FirstOrDefault();
            ExistingLession.Description = model.Description;
            ExistingLession.Name = model.Name;
            _entities.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Lesson LessionObject = _entities.Lessons.Where(x => x.Id == id).FirstOrDefault();
            _entities.Lessons.Remove(LessionObject);
            _entities.SaveChanges();
        }
    }
}
