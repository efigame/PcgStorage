using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dice { get; set; }
        public int PossibleAddons { get; set; }

        public Skill()
        {
        }

        internal Skill(DataAccess.Dto.Skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Dice = skill.Dice;
            PossibleAddons = skill.PossibleAddons;
        }
    }
}
