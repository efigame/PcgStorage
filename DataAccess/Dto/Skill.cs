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
        public int Dice { get; set; }
        public int CharacterCardId { get; set; }
        public int PossibleAddons { get; set; }

        internal Skill(DataAccess.skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Dice = skill.Dice;
            CharacterCardId = skill.CharacterCardId;
            PossibleAddons = skill.PossibleAddons;
        }
    }
}
