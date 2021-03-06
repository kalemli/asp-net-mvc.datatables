﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataList.Models.DataTables
{
    public class DataTableAjaxModel<T> where T : ISearchModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public T search { get; set; }
        public List<Order> order { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
    }

    public interface ISearchModel { }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}