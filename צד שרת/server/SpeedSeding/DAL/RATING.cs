//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class RATING
    {
        public long DELIVERYID { get; set; }
        public Nullable<long> IDOFDELIVER { get; set; }
        public Nullable<int> INTEGRITYDELIVER { get; set; }
        public Nullable<int> LATE { get; set; }
        public Nullable<int> SERVISE { get; set; }
        public Nullable<int> GENERAL { get; set; }
        public Nullable<long> SamPoint { get; set; }
    
        public virtual DELIVERIES DELIVERIES { get; set; }
    }
}
