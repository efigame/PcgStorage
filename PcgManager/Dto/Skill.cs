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
        public List<SubSkill> SubSkills { get; set; }

        public Skill()
        {
        }

        internal Skill(DataAccess.Dto.Skill skill) : this(skill, true)
        {
        }
        
        internal Skill(DataAccess.Dto.Skill skill, bool deepObjects)
        {
            Id = skill.Id;
            Name = skill.Name;
            Dice = skill.Dice;
            PossibleAddons = skill.PossibleAddons;
            SubSkills = new List<SubSkill>();

            if (deepObjects)
            {
                var subSkills = DataAccess.Dto.SubSkill.All(Id);
                SubSkills.AddRange(subSkills.Select(s => new SubSkill(s)));
            }
        }
    }
}
