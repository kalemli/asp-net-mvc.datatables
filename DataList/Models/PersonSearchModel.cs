using DataList.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataList.Models
{
    public class PersonSearchModel : ISearchModel
    {
        public string Code { get; set; }
        public string Fullname { get; set; }
        public string Workplace { get; set; }
        public string Address { get; set; }
    }
}