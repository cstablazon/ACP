//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ACP
{
    using System;
    using System.Collections.Generic;
    
    public partial class prodInvent
    {
        public int pInventID { get; set; }
        public string uomID { get; set; }
        public string itemModelID { get; set; }
        public string tdGroupID { get; set; }
        public string rsrvID { get; set; }
        public Nullable<decimal> inventCost { get; set; }
        public byte[] timestamp { get; set; }
        public Nullable<System.DateTime> transDate { get; set; }
    }
}
