using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataList.Models
{
    [Table("Persons", Schema = "Hospital")]
    public class Person
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Workplace { get; set; }
        public string Address { get; set; }
    }
}