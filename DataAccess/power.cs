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
    
    public partial class power
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public Nullable<int> Dice { get; set; }
        public Nullable<int> Adjustment { get; set; }
        public int CharacterCardId { get; set; }
    
        public virtual charactercard charactercard { get; set; }
    }
}