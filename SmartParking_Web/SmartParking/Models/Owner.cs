//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartParking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Owner
    {
        public Owner()
        {
            this.ParkingSlots = new HashSet<ParkingSlot>();
        }
    
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerContactNum { get; set; }
    
        public virtual ICollection<ParkingSlot> ParkingSlots { get; set; }
    }
}