using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Primary { get; set; }
        public int Group { get; set; }
        public int Dice { get; set; }
        public int Adjustment { get; set; }
        public int CharacterCardId { get; set; }

        internal Skill(DataAccess.skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Primary = skill.Primary;
            Group = skill.Group;
            Dice = skill.Dice;
            Adjustment = skill.Adjustment;
            CharacterCardId = skill.CharacterCardId;
        }
    }
}
