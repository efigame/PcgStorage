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
    
    public partial class skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Primary { get; set; }
        public int Group { get; set; }
        public int Dice { get; set; }
        public int Adjustment { get; set; }
        public int CharacterCardId { get; set; }
        public int PossibleAddons { get; set; }
    
        public virtual charactercard charactercard { get; set; }
    }
}
