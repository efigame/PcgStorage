using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class CharacterSkill
    {
        public int Id { get; set; }
        public int PartyCharacterId { get; set; }
        public int SkillId { get; set; }
        public int SelectedAdjustment { get; set; }

        public static CharacterSkill Get(int id)
        {
            CharacterSkill characterSkill = null;

            using (var data = new PcgStorageEntities())
            {
                var character = data.characterskills.SingleOrDefault(p => p.Id == id);
                if (character != null) characterSkill = new CharacterSkill(character);
            }

            return characterSkill;
        }
        public static List<CharacterSkill> All(int partyCharacterId)
        {
            var characterSkills = new List<CharacterSkill>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterskills.Where(p => p.PartyCharacterId == partyCharacterId).ToList();
                characterSkills.AddRange(all.Select(a => new CharacterSkill(a)));
            }

            return characterSkills;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.characterskills.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterSkill = data.characterskills.SingleOrDefault(p => p.Id == Id);
                if (characterSkill != null)
                {
                    characterSkill.PartyCharacterId = PartyCharacterId;
                    characterSkill.SelectedAdjustment = SelectedAdjustment;
                    characterSkill.SkillId = SkillId;
                    
                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var party = data.characterskills.SingleOrDefault(p => p.Id == Id);
                if (party != null)
                {
                    data.characterskills.Remove(party);
                    data.SaveChanges();
                }
            }
        }

        public CharacterSkill()
        {
        }

        internal CharacterSkill(characterskill characterSkill)
        {
            Id = characterSkill.Id;
            PartyCharacterId = characterSkill.PartyCharacterId;
            SelectedAdjustment = characterSkill.SelectedAdjustment;
            SkillId = characterSkill.SkillId;
        }
        internal characterskill ToEntity()
        {
            var characterSkill = new characterskill
            {
                PartyCharacterId = this.PartyCharacterId,
                SelectedAdjustment = this.SelectedAdjustment,
                SkillId = this.SkillId
            };

            return characterSkill;
        }
    }
}
