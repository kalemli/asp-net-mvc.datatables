using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataList.Controllers.Api
{
    public class PersonsController : ApiController
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public IHttpActionResult GetPersons()
        {
            var persons = Context.Persons.ToList();

            return Ok(persons);
        }
    }
}
