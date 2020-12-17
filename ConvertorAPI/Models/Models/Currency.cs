using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string CurrencyName { get; set; }
    }
}
