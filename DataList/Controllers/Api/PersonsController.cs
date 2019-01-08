using DataList.Models;
using DataList.Models.DataTables;
using DataList.Helpers;
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

        [HttpPost]
        public IHttpActionResult GetPersons(DataTableAjaxModel<PersonSearchModel> model)
        {
            var qPersons = Context.Persons.AsQueryable();
            if (!string.IsNullOrEmpty(model.search.Fullname))
                qPersons = qPersons.Where(p => 
                    (p.Firstname + " " + p.Surname + " " + p.Lastname).Contains(model.search.Fullname));
            if (!string.IsNullOrEmpty(model.search.Code))
                qPersons = qPersons.Where(p => p.Code.Contains(model.search.Code));
            if (!string.IsNullOrEmpty(model.search.Workplace))
                qPersons = qPersons.Where(p => p.Workplace.Contains(model.search.Workplace));
            if (!string.IsNullOrEmpty(model.search.Address))
                qPersons = qPersons.Where(p => p.Address.Contains(model.search.Address));

            if (model.order.Count > 0)
            {
                var order = model.order[0];
                string colName = model.columns[order.column].data;
                colName = colName.Substring(0, 1).ToUpper() + colName.Substring(1);
                qPersons = qPersons.OrderByName(colName, order.dir == "desc");
            }
            else
                qPersons = qPersons.OrderBy(p => p.Id);

            var persons = qPersons
                .Skip(model.start)
                .Take(model.length)
                .ToList();

            return Ok(new
            {
                model.draw,
                recordsTotal = Context.Persons.Count(),
                recordsFiltered = qPersons.Count(),
                data = persons
            });
        }
    }
}
