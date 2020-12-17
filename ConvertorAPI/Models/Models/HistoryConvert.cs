using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Models
{
    public class HistoryConvert
    {
        [Key]
        public int Id { get; set; }
        public decimal FromAmount { get; set; }
        public int FromCurrencyId { get; set; }
        [ForeignKey("FromCurrencyId")]
        public virtual Currency FromCurrency { get; set; }
        public decimal ToAmount { get; set; }
        public int ToCurrencyId { get; set; }
        [ForeignKey("ToCurrencyId")]
        public Currency ToCurrency { get; set; }
        public DateTime DateConvert  { get; set; }
        public HistoryConvert()
        {
            DateConvert = DateTime.Now;
        }
    }
}
