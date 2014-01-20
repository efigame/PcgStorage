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
    
    public partial class partycharacter
    {
        public partycharacter()
        {
            this.characterskills = new HashSet<characterskill>();
        }
    
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int CharacterCardId { get; set; }
        public Nullable<bool> LightArmors { get; set; }
        public Nullable<bool> HeavyArmors { get; set; }
        public Nullable<bool> Weapons { get; set; }
        public Nullable<int> WeaponCards { get; set; }
        public Nullable<int> SpellCards { get; set; }
        public Nullable<int> ArmorCards { get; set; }
        public Nullable<int> ItemCards { get; set; }
        public Nullable<int> AllyCards { get; set; }
        public Nullable<int> BlessingCards { get; set; }
    
        public virtual charactercard charactercard { get; set; }
        public virtual ICollection<characterskill> characterskills { get; set; }
        public virtual party party { get; set; }
    }
}
