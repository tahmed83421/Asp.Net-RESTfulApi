//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asp.Net_RESTfulApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MarketAnalyze
    {
        public int ID { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }
        public string DeliveryTime { get; set; }
        public string Supplier { get; set; }
        public string Warranty { get; set; }
        public Nullable<int> QuotationId { get; set; }
        public string Comment { get; set; }
    }
}
