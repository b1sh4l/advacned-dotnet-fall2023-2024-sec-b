//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger42915.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssignedTask
    {
        public int TaskID { get; set; }
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<System.DateTime> AssignedDateTime { get; set; }
        public Nullable<System.DateTime> CompletedDateTime { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual FoodCollectionRequest FoodCollectionRequest { get; set; }
    }
}
