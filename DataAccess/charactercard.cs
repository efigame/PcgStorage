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
    
    public partial class charactercard
    {
        public charactercard()
        {
            this.partycharacters = new HashSet<partycharacter>();
            this.skills = new HashSet<skill>();
            this.powers = new HashSet<power>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseHandSize { get; set; }
        public bool BaseLightArmors { get; set; }
        public bool BaseHeavyArmors { get; set; }
        public bool BaseWeapons { get; set; }
        public int BaseWeaponCards { get; set; }
        public int BaseSpellCards { get; set; }
        public int BaseArmorCards { get; set; }
        public int BaseItemCards { get; set; }
        public int BaseAllyCards { get; set; }
        public int BaseBlessingCards { get; set; }
    
        public virtual ICollection<partycharacter> partycharacters { get; set; }
        public virtual ICollection<skill> skills { get; set; }
        public virtual ICollection<power> powers { get; set; }
    }
}
