using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.JsonToModel
{
    public class Root
    {
        public Rates rates { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
    }
}
