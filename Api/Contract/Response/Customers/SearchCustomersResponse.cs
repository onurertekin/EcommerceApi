﻿using Contract.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.Customers
{
    public class SearchCustomersResponse
    {
        public class Customers
        {
            public int id { get; set; }
            public string? firstName { get; set; }
            public string? lastName { get; set; }
            public string? userName { get; set; }
            public string? password { get; set; }
            public string? email { get; set; }
            public string? phoneNumber { get; set; }
            public string? gender { get; set; }
            public int status { get; set; }
            public bool isDeleted { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? UpdatedOn { get; set; }
        }
        public SearchCustomersResponse()
        {
            customers = new List<Customers>();
        }
        public List<Customers> customers { get; set; }
        public int totalCount { get; set; }

    }
}
