using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class SubSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Adjustment { get; set; }
        public int BaseSkillId { get; set; }

        public SubSkill()
        {
        }

        internal SubSkill(DataAccess.Dto.SubSkill skill) : this(skill, true)
        {
        }

        internal SubSkill(DataAccess.Dto.SubSkill skill, bool deepObjects)
        {
            Id = skill.Id;
            Name = skill.Name;
            Adjustment = skill.Adjustment;
            BaseSkillId = skill.BaseSkillId;
        }
    }
}
