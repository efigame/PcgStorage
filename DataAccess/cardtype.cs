//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class cardtype
    {
        public cardtype()
        {
            this.cards = new HashSet<card>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<card> cards { get; set; }
    }
}
