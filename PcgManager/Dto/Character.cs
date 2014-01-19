using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcgManager.Dto
{
    public class Character
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int CharacterCardId { get; set; }
        public string Name { get; set; }
        public int HandSize { get; set; }
        public bool LightArmors { get; set; }
        public bool HeavyArmors { get; set; }
        public bool Weapons { get; set; }
        public int WeaponCards { get; set; }
        public int SpellCards { get; set; }
        public int ArmorCards { get; set; }
        public int ItemCards { get; set; }
        public int AllyCards { get; set; }
        public int BlessingCards { get; set; }

        public List<Skill> Skills { get; set; }
        public List<Power> Powers { get; set; }

        // TODO: Add character skills

        public void Persist()
        {
            var partyCharacter = new DataAccess.Dto.PartyCharacter();
            partyCharacter.PartyId = PartyId;
            partyCharacter.CharacterCardId = CharacterCardId;

            partyCharacter.Persist();

            Id = partyCharacter.Id;
        }

        public void Delete()
        {
            var partyCharacter = DataAccess.Dto.PartyCharacter.Get(Id);
            partyCharacter.Delete();
        }

        public Character()
        {
        }

        internal Character(DataAccess.Dto.PartyCharacter partyCharacter) : this(partyCharacter, true)
        {
        }
        internal Character(DataAccess.Dto.PartyCharacter partyCharacter, bool deepObjects)
        {
            Id = partyCharacter.Id;
            PartyId = partyCharacter.PartyId;
            CharacterCardId = partyCharacter.CharacterCardId;
            Skills = new List<Skill>();
            Powers = new List<Power>();

            if (deepObjects)
            {
                var characterCard = DataAccess.Dto.CharacterCard.Get(partyCharacter.CharacterCardId);
                Name = characterCard.Name;
                HandSize = characterCard.BaseHandSize;
                LightArmors = characterCard.BaseLightArmors;
                HeavyArmors = characterCard.BaseHeavyArmors;
                Weapons = characterCard.BaseWeapons;
                WeaponCards = characterCard.BaseWeaponCards;
                SpellCards = characterCard.BaseSpellCards;
                ArmorCards = characterCard.BaseArmorCards;
                ItemCards = characterCard.BaseItemCards;
                AllyCards = characterCard.BaseAllyCards;
                BlessingCards = characterCard.BaseBlessingCards;

                var powers = DataAccess.Dto.Power.All(CharacterCardId);
                Powers.AddRange(powers.Select(p => new Power(p)));

                var skills = DataAccess.Dto.Skill.All(CharacterCardId);
                Skills.AddRange(skills.Select(s => new Skill(s, Id)));
            }
        }
    }
}
