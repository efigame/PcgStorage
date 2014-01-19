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
        public int SelectedAddons { get; set; }
        public List<SubSkill> SubSkills { get; set; }

        public static void Set(int partyCharacterId, int skillId, bool selectedValue)
        {
            var characterSkill = DataAccess.Dto.CharacterSkill.All(partyCharacterId).SingleOrDefault(c => c.SkillId == skillId);
            if (characterSkill != null)
            {
                characterSkill.SelectedAdjustment = selectedValue ? characterSkill.SelectedAdjustment + 1 : characterSkill.SelectedAdjustment - 1;
                characterSkill.Update();
            }
            else
            {
                characterSkill = new DataAccess.Dto.CharacterSkill
                {
                    PartyCharacterId = partyCharacterId,
                    SelectedAdjustment = 1,
                    SkillId = skillId
                };
                characterSkill.Persist();
            }
        }

        public Skill()
        {
        }

        internal Skill(DataAccess.Dto.Skill skill, int partyCharacterId) : this(skill, partyCharacterId, true)
        {
        }
        
        internal Skill(DataAccess.Dto.Skill skill, int partyCharacterId, bool deepObjects)
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

                var characterSkill = DataAccess.Dto.CharacterSkill.All(partyCharacterId).SingleOrDefault(c => c.SkillId == Id);
                if (characterSkill != null)
                    SelectedAddons = characterSkill.SelectedAdjustment;
                else
                    SelectedAddons = 0;
            }
        }
    }
}
