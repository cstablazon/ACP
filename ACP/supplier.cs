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
    
    public partial class supplier
    {
        public string suppID { get; set; }
        public string itemTaxID { get; set; }
        public Nullable<int> payID { get; set; }
        public Nullable<int> sGroupID { get; set; }
        public string name { get; set; }
        public string rType { get; set; }
        public string agent { get; set; }
        public string RID { get; set; }
        public Nullable<bool> isDistributor { get; set; }
        public Nullable<bool> isActive { get; set; }
        public byte[] timestamp { get; set; }
        public Nullable<System.DateTime> transDate { get; set; }
        public string userID { get; set; }
    }
}
