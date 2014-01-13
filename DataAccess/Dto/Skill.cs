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

        public static Skill Get(int id)
        {
            Skill skill = null;

            using (var data = new PcgStorageEntities())
            {
                var characterSkill = data.skills.SingleOrDefault(p => p.Id == id);
                if (characterSkill != null) skill = new Skill(characterSkill);
            }

            return skill;
        }
        public static List<Skill> All(int characterCardId)
        {
            var skills = new List<Skill>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.skills.Where(s => s.CharacterCardId == characterCardId);
                skills.AddRange(all.Select(a => new Skill(a)));
            }

            return skills;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = this.ToEntity();
                data.skills.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var skill = data.skills.SingleOrDefault(s => s.Id == Id);
                if (skill != null)
                {
                    skill.CharacterCardId = CharacterCardId;
                    skill.Dice = Dice;
                    skill.Name = Name;
                    skill.PossibleAddons = PossibleAddons;

                    data.SaveChanges();
                }
            }
        }
        public void Delete() // TODO: Remember foreign relations
        {
            using (var data = new PcgStorageEntities())
            {
                var skill = data.skills.SingleOrDefault(s => s.Id == Id);
                if (skill != null)
                {
                    data.skills.Remove(skill);
                    data.SaveChanges();
                }
            }
        }

        public Skill()
        {
        }

        internal Skill(skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Dice = skill.Dice;
            CharacterCardId = skill.CharacterCardId;
            PossibleAddons = skill.PossibleAddons;
        }
        internal skill ToEntity()
        {
            var skill = new skill
            {
                CharacterCardId = this.CharacterCardId,
                Dice = this.Dice,
                Name = this.Name,
                PossibleAddons = this.PossibleAddons
            };

            return skill;
        }


        
    }
}
